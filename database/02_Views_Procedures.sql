/* =====================================================================
   الملف 2 من 3: العروض (Views) والإجراءات المخزنة (Stored Procedures)
   ===================================================================== */
USE RentalDB;
GO

/* =============================== VIEWS =============================== */

-- حالة الوحدات مع المستأجر الحالي (تقرير العقارات والوحدات + الوحدات الشاغرة)
CREATE OR ALTER VIEW dbo.vw_UnitOccupancy
AS
SELECT  p.PropertyID, p.PropertyName, p.City,
        u.UnitID, u.UnitNumber, u.UnitType, u.FloorNo, u.Area, u.DefaultRent, u.Status,
        c.ContractID, c.ContractNumber, c.EndDate,
        t.TenantID, t.FullName AS TenantName, t.Phone AS TenantPhone
FROM    dbo.Units u
JOIN    dbo.Properties p ON p.PropertyID = u.PropertyID
LEFT JOIN dbo.Contracts c ON c.UnitID = u.UnitID AND c.Status = N'Active'
LEFT JOIN dbo.Tenants   t ON t.TenantID = c.TenantID;
GO

-- العقود مع كل التفاصيل والأرصدة
CREATE OR ALTER VIEW dbo.vw_ContractDetails
AS
SELECT  c.ContractID, c.ContractNumber, c.Status, c.StartDate, c.EndDate,
        c.MonthlyRent, c.PaymentFrequency, c.DepositAmount,
        DATEDIFF(DAY, CAST(GETDATE() AS DATE), c.EndDate) AS DaysLeft,
        p.PropertyName, u.UnitID, u.UnitNumber, u.UnitType,
        t.TenantID, t.FullName AS TenantName, t.NationalID, t.Phone,
        ISNULL(s.TotalDue, 0)  AS TotalDue,
        ISNULL(s.TotalPaid, 0) AS TotalPaid,
        ISNULL(s.TotalDue, 0) - ISNULL(s.TotalPaid, 0) AS Balance
FROM    dbo.Contracts c
JOIN    dbo.Units u      ON u.UnitID = c.UnitID
JOIN    dbo.Properties p ON p.PropertyID = u.PropertyID
JOIN    dbo.Tenants t    ON t.TenantID = c.TenantID
OUTER APPLY (SELECT SUM(i.Amount) AS TotalDue, SUM(i.PaidAmount) AS TotalPaid
             FROM dbo.Installments i WHERE i.ContractID = c.ContractID) s;
GO

-- الأقساط المتأخرة (BR-05) — تنبيه FR-22 وتقرير المتأخرات
CREATE OR ALTER VIEW dbo.vw_OverdueInstallments
AS
SELECT  i.InstallmentID, i.InstallmentNo, i.DueDate, i.Amount, i.PaidAmount,
        i.Amount - i.PaidAmount AS Remaining,
        DATEDIFF(DAY, i.DueDate, CAST(GETDATE() AS DATE)) AS DaysLate,
        c.ContractID, c.ContractNumber,
        p.PropertyName, u.UnitNumber,
        t.TenantID, t.FullName AS TenantName, t.Phone
FROM    dbo.Installments i
JOIN    dbo.Contracts c  ON c.ContractID = i.ContractID
JOIN    dbo.Units u      ON u.UnitID = c.UnitID
JOIN    dbo.Properties p ON p.PropertyID = u.PropertyID
JOIN    dbo.Tenants t    ON t.TenantID = c.TenantID
WHERE   i.PaidAmount < i.Amount
  AND   i.DueDate < CAST(GETDATE() AS DATE);
GO

-- العقود النشطة التي تنتهي خلال عدد الأيام المحدد في الإعدادات (أو انتهت ولم تُغلق) — FR-23
CREATE OR ALTER VIEW dbo.vw_ExpiringContracts
AS
SELECT  d.*
FROM    dbo.vw_ContractDetails d
CROSS JOIN dbo.Settings s
WHERE   d.Status = N'Active'
  AND   d.DaysLeft <= s.ContractAlertDays;   -- DaysLeft سالب = منتهٍ ولم يُغلق
GO

-- كشف حساب المستأجر: حركات مدينة (أقساط) ودائنة (دفعات) — FR-26 (6)
CREATE OR ALTER VIEW dbo.vw_TenantStatement
AS
SELECT  c.TenantID, c.ContractID, c.ContractNumber,
        i.DueDate AS TxDate, N'قسط رقم ' + CAST(i.InstallmentNo AS NVARCHAR(10)) AS Description,
        i.Amount AS Debit, CAST(0 AS DECIMAL(12,2)) AS Credit, 1 AS SortOrder
FROM    dbo.Installments i
JOIN    dbo.Contracts c ON c.ContractID = i.ContractID
UNION ALL
SELECT  c.TenantID, c.ContractID, c.ContractNumber,
        pay.PaymentDate, N'دفعة - إيصال ' + pay.ReceiptNumber,
        0, pay.Amount, 2
FROM    dbo.Payments pay
JOIN    dbo.Installments i ON i.InstallmentID = pay.InstallmentID
JOIN    dbo.Contracts c    ON c.ContractID = i.ContractID;
GO

/* ========================= STORED PROCEDURES ========================= */

/* ---------------------------------------------------------------------
   إبرام عقد جديد + توليد الأقساط + تغيير حالة الوحدة (معاملة واحدة)
   FR-12, FR-13, FR-14, BR-02, BR-04
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_CreateContract
    @UnitID            INT,
    @TenantID          INT,
    @StartDate         DATE,
    @EndDate           DATE,
    @MonthlyRent       DECIMAL(12,2),
    @PaymentFrequency  TINYINT,
    @DepositAmount     DECIMAL(12,2) = 0,
    @Notes             NVARCHAR(500) = NULL,
    @CreatedBy         INT,
    @NewContractID     INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @EndDate <= @StartDate
        THROW 50001, N'تاريخ نهاية العقد يجب أن يكون بعد تاريخ البداية.', 1;

    BEGIN TRANSACTION;

        -- قفل صف الوحدة لمنع إبرام عقدين في نفس اللحظة
        DECLARE @UnitStatus NVARCHAR(20);
        SELECT @UnitStatus = Status FROM dbo.Units WITH (UPDLOCK, HOLDLOCK) WHERE UnitID = @UnitID;

        IF @UnitStatus IS NULL
            THROW 50002, N'الوحدة غير موجودة.', 1;
        IF @UnitStatus <> N'Vacant'
            THROW 50003, N'لا يمكن إبرام عقد على وحدة غير شاغرة.', 1;

        INSERT INTO dbo.Contracts (UnitID, TenantID, StartDate, EndDate, MonthlyRent,
                                   PaymentFrequency, DepositAmount, Notes, CreatedBy)
        VALUES (@UnitID, @TenantID, @StartDate, @EndDate, @MonthlyRent,
                @PaymentFrequency, @DepositAmount, @Notes, @CreatedBy);

        SET @NewContractID = SCOPE_IDENTITY();

        -- توليد الأقساط: كل قسط يغطي @PaymentFrequency شهراً، والأخير بالتناسب
        DECLARE @DueDate   DATE = @StartDate,
                @StopDate  DATE = DATEADD(DAY, 1, @EndDate),
                @No        INT  = 1,
                @Months    INT;

        WHILE @DueDate < @StopDate
        BEGIN
            SET @Months = DATEDIFF(MONTH, @DueDate, @StopDate);
            IF @Months > @PaymentFrequency SET @Months = @PaymentFrequency;
            IF @Months < 1 SET @Months = 1;

            INSERT INTO dbo.Installments (ContractID, InstallmentNo, DueDate, Amount)
            VALUES (@NewContractID, @No, @DueDate, @MonthlyRent * @Months);

            SET @No += 1;
            SET @DueDate = DATEADD(MONTH, @PaymentFrequency * (@No - 1), @StartDate);
        END

        UPDATE dbo.Units SET Status = N'Rented' WHERE UnitID = @UnitID;

    COMMIT TRANSACTION;
END
GO

/* ---------------------------------------------------------------------
   تسجيل دفعة على قسط — FR-18, FR-19, FR-21, BR-06
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_RecordPayment
    @InstallmentID  INT,
    @Amount         DECIMAL(12,2),
    @PaymentDate    DATE,
    @PaymentMethod  NVARCHAR(20),
    @ReferenceNo    NVARCHAR(50) = NULL,
    @Notes          NVARCHAR(300) = NULL,
    @ReceivedBy     INT,
    @NewPaymentID   INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @Amount <= 0
        THROW 50010, N'مبلغ الدفعة يجب أن يكون أكبر من صفر.', 1;

    BEGIN TRANSACTION;

        DECLARE @Remaining DECIMAL(12,2);
        SELECT @Remaining = Amount - PaidAmount
        FROM   dbo.Installments WITH (UPDLOCK, HOLDLOCK)
        WHERE  InstallmentID = @InstallmentID;

        IF @Remaining IS NULL
            THROW 50011, N'القسط غير موجود.', 1;
        IF @Amount > @Remaining
            THROW 50012, N'المبلغ أكبر من المتبقي على القسط.', 1;

        INSERT INTO dbo.Payments (InstallmentID, PaymentDate, Amount, PaymentMethod, ReferenceNo, Notes, ReceivedBy)
        VALUES (@InstallmentID, @PaymentDate, @Amount, @PaymentMethod, @ReferenceNo, @Notes, @ReceivedBy);

        SET @NewPaymentID = SCOPE_IDENTITY();

        UPDATE dbo.Installments
        SET    PaidAmount = PaidAmount + @Amount
        WHERE  InstallmentID = @InstallmentID;

    COMMIT TRANSACTION;
END
GO

/* ---------------------------------------------------------------------
   إنهاء أو فسخ عقد — FR-15, FR-14
   @Terminate = 0 : انتهاء طبيعي  |  1 : فسخ مبكر (يحذف الأقساط المستقبلية غير المدفوعة)
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_CloseContract
    @ContractID  INT,
    @CloseDate   DATE,
    @Terminate   BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

        DECLARE @UnitID INT;
        SELECT @UnitID = UnitID FROM dbo.Contracts WITH (UPDLOCK)
        WHERE  ContractID = @ContractID AND Status = N'Active';

        IF @UnitID IS NULL
            THROW 50020, N'العقد غير موجود أو ليس نشطاً.', 1;

        IF @Terminate = 1
            DELETE FROM dbo.Installments
            WHERE  ContractID = @ContractID AND DueDate > @CloseDate AND PaidAmount = 0;

        UPDATE dbo.Contracts
        SET    Status = CASE WHEN @Terminate = 1 THEN N'Terminated' ELSE N'Ended' END,
               ClosedDate = @CloseDate
        WHERE  ContractID = @ContractID;

        UPDATE dbo.Units SET Status = N'Vacant' WHERE UnitID = @UnitID;

    COMMIT TRANSACTION;
END
GO

/* ---------------------------------------------------------------------
   تجديد عقد: يغلق القديم ويُنشئ جديداً يبدأ بعده مباشرة — FR-16
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_RenewContract
    @OldContractID     INT,
    @NewEndDate        DATE,
    @NewMonthlyRent    DECIMAL(12,2),
    @PaymentFrequency  TINYINT,
    @CreatedBy         INT,
    @NewContractID     INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @UnitID INT, @TenantID INT, @OldEnd DATE, @Deposit DECIMAL(12,2), @NewStart DATE;

    SELECT @UnitID = UnitID, @TenantID = TenantID, @OldEnd = EndDate, @Deposit = DepositAmount
    FROM   dbo.Contracts WHERE ContractID = @OldContractID AND Status = N'Active';

    IF @UnitID IS NULL
        THROW 50030, N'العقد غير موجود أو ليس نشطاً.', 1;

    SET @NewStart = DATEADD(DAY, 1, @OldEnd);

    BEGIN TRANSACTION;
        EXEC dbo.sp_CloseContract @ContractID = @OldContractID, @CloseDate = @OldEnd, @Terminate = 0;
        EXEC dbo.sp_CreateContract @UnitID = @UnitID, @TenantID = @TenantID,
             @StartDate = @NewStart, @EndDate = @NewEndDate, @MonthlyRent = @NewMonthlyRent,
             @PaymentFrequency = @PaymentFrequency, @DepositAmount = @Deposit,
             @Notes = N'تجديد للعقد السابق', @CreatedBy = @CreatedBy, @NewContractID = @NewContractID OUTPUT;
    COMMIT TRANSACTION;
END
GO

/* ---------------------------------------------------------------------
   ملخص الشاشة الرئيسية (Dashboard) — FR-24
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_DashboardSummary
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        (SELECT COUNT(*) FROM dbo.Properties)                              AS PropertiesCount,
        (SELECT COUNT(*) FROM dbo.Units)                                   AS UnitsCount,
        (SELECT COUNT(*) FROM dbo.Units WHERE Status = N'Rented')          AS RentedUnits,
        (SELECT COUNT(*) FROM dbo.Units WHERE Status = N'Vacant')          AS VacantUnits,
        (SELECT COUNT(*) FROM dbo.Contracts WHERE Status = N'Active')      AS ActiveContracts,
        (SELECT COUNT(*) FROM dbo.vw_OverdueInstallments)                  AS OverdueCount,
        (SELECT ISNULL(SUM(Remaining), 0) FROM dbo.vw_OverdueInstallments) AS OverdueAmount,
        (SELECT COUNT(*) FROM dbo.vw_ExpiringContracts)                    AS ExpiringCount,
        (SELECT ISNULL(SUM(Amount), 0) FROM dbo.Payments
          WHERE PaymentDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS CollectedThisMonth;
END
GO

/* ---------------------------------------------------------------------
   البحث الشامل — FR-25
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_GlobalSearch
    @Term NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Like NVARCHAR(102) = N'%' + @Term + N'%';

    SELECT N'مستأجر' AS ResultType, TenantID AS ID, FullName AS Title,
           N'هاتف: ' + Phone + N' | رقم وطني: ' + NationalID AS Details
    FROM   dbo.Tenants
    WHERE  FullName LIKE @Like OR NationalID LIKE @Like OR Phone LIKE @Like
    UNION ALL
    SELECT N'عقد', ContractID, ContractNumber + N' - ' + TenantName,
           PropertyName + N' / وحدة ' + UnitNumber
    FROM   dbo.vw_ContractDetails
    WHERE  ContractNumber LIKE @Like OR TenantName LIKE @Like
    UNION ALL
    SELECT N'وحدة', UnitID, PropertyName + N' / وحدة ' + UnitNumber, UnitType + N' - ' + Status
    FROM   dbo.vw_UnitOccupancy
    WHERE  UnitNumber LIKE @Like OR PropertyName LIKE @Like;
END
GO

/* ---------------------------------------------------------------------
   تقرير الإيرادات المحصلة خلال فترة — FR-26 (7)
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_RevenueReport
    @FromDate DATE,
    @ToDate   DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT  pay.ReceiptNumber, pay.PaymentDate, pay.Amount, pay.PaymentMethod,
            d.ContractNumber, d.TenantName, d.PropertyName, d.UnitNumber,
            usr.FullName AS ReceivedByName
    FROM    dbo.Payments pay
    JOIN    dbo.Installments i      ON i.InstallmentID = pay.InstallmentID
    JOIN    dbo.vw_ContractDetails d ON d.ContractID = i.ContractID
    JOIN    dbo.Users usr           ON usr.UserID = pay.ReceivedBy
    WHERE   pay.PaymentDate BETWEEN @FromDate AND @ToDate
    ORDER BY pay.PaymentDate, pay.PaymentID;
END
GO
