/* =====================================================================
   نظام إدارة العقارات والإيجارات وتتبع دفعات المستأجرين - SQL Server
   Real Estate & Rental Management System - database schema
   شغّله في SSMS (File > Open > File ثم Execute). احفظ الملف بترميز UTF-8.
   ===================================================================== */
-- الإعدادات المطلوبة للأعمدة المحسوبة والفهارس المرشّحة (SSMS يضبطها تلقائياً، و sqlcmd لا يضبطها)
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO
USE master;
GO
IF DB_ID(N'RentalDB') IS NULL
    CREATE DATABASE RentalDB COLLATE Arabic_CI_AS;
GO
USE RentalDB;
GO
-- حماية: إذا لم تُنشأ القاعدة لأي سبب، يتوقف السكربت بدل إنشاء الجداول في قاعدة أخرى (مثل master)
IF DB_NAME() <> N'RentalDB'
BEGIN
    RAISERROR(N'لم يتم إنشاء قاعدة RentalDB أو الانتقال إليها. توقف التنفيذ.', 16, 1);
    SET NOEXEC ON;
END
GO

/* ---------- 1. Users ---------- */
CREATE TABLE dbo.[User] (
    UserId       INT IDENTITY(1,1) CONSTRAINT PK_User PRIMARY KEY,
    Username     NVARCHAR(50)  NOT NULL CONSTRAINT UQ_User_Username UNIQUE,
    FullName     NVARCHAR(150) NOT NULL,
    PasswordHash VARBINARY(64) NOT NULL,   -- PBKDF2-SHA256 computed in C#, never plain text
    PasswordSalt VARBINARY(32) NOT NULL,
    Role         NVARCHAR(20)  NOT NULL
                 CONSTRAINT CK_User_Role CHECK (Role IN (N'Manager', N'Employee')),
    IsActive     BIT NOT NULL CONSTRAINT DF_User_Active DEFAULT 1,
    LastLogin    DATETIME2 NULL
);

/* ---------- 2. Properties and units ---------- */
CREATE TABLE dbo.Property (
    PropertyId   INT IDENTITY(1,1) CONSTRAINT PK_Property PRIMARY KEY,
    Name         NVARCHAR(150) NOT NULL CONSTRAINT UQ_Property_Name UNIQUE,
    PropertyType NVARCHAR(30)  NOT NULL,
    City         NVARCHAR(60)  NOT NULL,
    Address      NVARCHAR(250) NULL,
    Notes        NVARCHAR(500) NULL,
    IsActive     BIT NOT NULL CONSTRAINT DF_Property_Active DEFAULT 1,
    CreatedAt    DATETIME2 NOT NULL CONSTRAINT DF_Property_Created DEFAULT SYSDATETIME()
);

CREATE TABLE dbo.Unit (
    UnitId       INT IDENTITY(1,1) CONSTRAINT PK_Unit PRIMARY KEY,
    PropertyId   INT NOT NULL CONSTRAINT FK_Unit_Property REFERENCES dbo.Property(PropertyId),
    UnitNo       NVARCHAR(20)  NOT NULL,
    UnitType     NVARCHAR(30)  NOT NULL,
    FloorNo      INT NULL,
    Area         DECIMAL(10,2) NULL CONSTRAINT CK_Unit_Area CHECK (Area IS NULL OR Area > 0),
    Rooms        INT NULL CONSTRAINT CK_Unit_Rooms CHECK (Rooms IS NULL OR Rooms >= 0),
    MonthlyRent  DECIMAL(18,3) NOT NULL CONSTRAINT CK_Unit_Rent CHECK (MonthlyRent >= 0),   -- suggested rent
    Status       NVARCHAR(20)  NOT NULL CONSTRAINT DF_Unit_Status DEFAULT N'Vacant'
                 CONSTRAINT CK_Unit_Status CHECK (Status IN (N'Vacant', N'Rented', N'Maintenance')),
    Notes        NVARCHAR(300) NULL,
    CONSTRAINT UQ_Unit UNIQUE (PropertyId, UnitNo)      -- unit number is unique inside its property
);
CREATE INDEX IX_Unit_Status ON dbo.Unit(Status) INCLUDE (PropertyId);

/* ---------- 3. Tenants ---------- */
CREATE TABLE dbo.Tenant (
    TenantId     INT IDENTITY(1,1) CONSTRAINT PK_Tenant PRIMARY KEY,
    FullName     NVARCHAR(150) NOT NULL,
    NationalId   NVARCHAR(30)  NOT NULL CONSTRAINT UQ_Tenant_NationalId UNIQUE,  -- national no. / passport / company reg.
    Phone        NVARCHAR(30)  NOT NULL,
    Phone2       NVARCHAR(30)  NULL,
    Email        NVARCHAR(100) NULL,
    Address      NVARCHAR(250) NULL,
    Notes        NVARCHAR(500) NULL,
    IsActive     BIT NOT NULL CONSTRAINT DF_Tenant_Active DEFAULT 1,
    CreatedAt    DATETIME2 NOT NULL CONSTRAINT DF_Tenant_Created DEFAULT SYSDATETIME()
);
CREATE INDEX IX_Tenant_Name ON dbo.Tenant(FullName);

/* ---------- 4. Lease contracts ---------- */
CREATE TABLE dbo.Contract (
    ContractId   INT IDENTITY(1,1) CONSTRAINT PK_Contract PRIMARY KEY,
    ContractNo   AS (N'C-' + RIGHT(N'00000' + CAST(ContractId AS NVARCHAR(10)), 5)) PERSISTED,
    UnitId       INT NOT NULL CONSTRAINT FK_Contract_Unit   REFERENCES dbo.Unit(UnitId),
    TenantId     INT NOT NULL CONSTRAINT FK_Contract_Tenant REFERENCES dbo.Tenant(TenantId),
    StartDate    DATE NOT NULL,
    EndDate      DATE NOT NULL,
    MonthlyRent  DECIMAL(18,3) NOT NULL CONSTRAINT CK_Contract_Rent CHECK (MonthlyRent > 0),
    PaymentCycle INT NOT NULL CONSTRAINT CK_Contract_Cycle CHECK (PaymentCycle IN (1, 3, 6, 12)),  -- months per installment
    Deposit      DECIMAL(18,3) NOT NULL CONSTRAINT DF_Contract_Deposit DEFAULT 0
                 CONSTRAINT CK_Contract_Deposit CHECK (Deposit >= 0),
    Status       NVARCHAR(20) NOT NULL CONSTRAINT DF_Contract_Status DEFAULT N'Active'
                 CONSTRAINT CK_Contract_Status CHECK (Status IN (N'Active', N'Ended', N'Terminated')),
    ClosedDate   DATE NULL,
    CloseReason  NVARCHAR(300) NULL,
    Notes        NVARCHAR(500) NULL,
    RenewedFrom  INT NULL CONSTRAINT FK_Contract_Renewed REFERENCES dbo.Contract(ContractId),
    CreatedBy    INT NOT NULL CONSTRAINT FK_Contract_User REFERENCES dbo.[User](UserId),
    CreatedAt    DATETIME2 NOT NULL CONSTRAINT DF_Contract_Created DEFAULT SYSDATETIME(),
    CONSTRAINT CK_Contract_Dates CHECK (EndDate > StartDate),
    CONSTRAINT CK_Contract_Closed CHECK (Status = N'Active' OR ClosedDate IS NOT NULL)
);
-- BR-01: a unit can have only ONE active contract at any time
CREATE UNIQUE INDEX UX_Contract_OneActivePerUnit ON dbo.Contract(UnitId) WHERE Status = N'Active';
CREATE INDEX IX_Contract_Tenant  ON dbo.Contract(TenantId) INCLUDE (Status);
CREATE INDEX IX_Contract_EndDate ON dbo.Contract(EndDate) INCLUDE (Status);

/* ---------- 5. Installments (payment schedule, generated with the contract) ---------- */
CREATE TABLE dbo.Installment (
    InstallmentId INT IDENTITY(1,1) CONSTRAINT PK_Installment PRIMARY KEY,
    ContractId    INT NOT NULL CONSTRAINT FK_Installment_Contract REFERENCES dbo.Contract(ContractId),
    InstallmentNo INT NOT NULL,
    DueDate       DATE NOT NULL,
    Amount        DECIMAL(18,3) NOT NULL CONSTRAINT CK_Installment_Amount CHECK (Amount > 0),
    -- المدفوع والمتبقي والحالة لا تُخزَّن: تُحسب من الدفعات في العرض vw_InstallmentBalance
    CONSTRAINT UQ_Installment UNIQUE (ContractId, InstallmentNo)
);
CREATE INDEX IX_Installment_Due ON dbo.Installment(DueDate) INCLUDE (ContractId, Amount);

/* ---------- 6. Payments (each payment = one receipt) ---------- */
CREATE TABLE dbo.Payment (
    PaymentId     INT IDENTITY(1,1) CONSTRAINT PK_Payment PRIMARY KEY,
    ReceiptNo     AS (N'R-' + RIGHT(N'000000' + CAST(PaymentId AS NVARCHAR(10)), 6)) PERSISTED,
    InstallmentId INT NOT NULL CONSTRAINT FK_Payment_Installment REFERENCES dbo.Installment(InstallmentId),
    PaymentDate   DATE NOT NULL,
    Amount        DECIMAL(18,3) NOT NULL CONSTRAINT CK_Payment_Amount CHECK (Amount > 0),
    Method        NVARCHAR(20) NOT NULL
                  CONSTRAINT CK_Payment_Method CHECK (Method IN (N'Cash', N'Transfer', N'Cheque')),
    ReferenceNo   NVARCHAR(50)  NULL,   -- cheque / transfer number
    Notes         NVARCHAR(300) NULL,
    ReceivedBy    INT NOT NULL CONSTRAINT FK_Payment_User REFERENCES dbo.[User](UserId),
    CreatedAt     DATETIME2 NOT NULL CONSTRAINT DF_Payment_Created DEFAULT SYSDATETIME(),
    IsCancelled   BIT NOT NULL CONSTRAINT DF_Payment_Cancelled DEFAULT 0,      -- receipts are never deleted
    CancelledBy   INT NULL CONSTRAINT FK_Payment_Canceller REFERENCES dbo.[User](UserId),
    CancelReason  NVARCHAR(300) NULL,
    CONSTRAINT CK_Payment_Cancel CHECK (IsCancelled = 0 OR CancelledBy IS NOT NULL)
);
CREATE INDEX IX_Payment_Installment ON dbo.Payment(InstallmentId) INCLUDE (Amount, IsCancelled);
CREATE INDEX IX_Payment_Date ON dbo.Payment(PaymentDate) INCLUDE (Amount, IsCancelled);

/* ---------- 6b. Photos of properties and units ---------- */
-- كل صورة تخص عقاراً أو وحدة (واحداً منهما فقط)، وتُحفظ مصغّرة (أقصى بُعد 1600 بكسل) بحد أقصى 2 ميغابايت
CREATE TABLE dbo.Photo (
    PhotoId    INT IDENTITY(1,1) CONSTRAINT PK_Photo PRIMARY KEY,
    PropertyId INT NULL CONSTRAINT FK_Photo_Property REFERENCES dbo.Property(PropertyId),
    UnitId     INT NULL CONSTRAINT FK_Photo_Unit     REFERENCES dbo.Unit(UnitId),
    Image      VARBINARY(MAX) NOT NULL,
    Caption    NVARCHAR(150) NULL,
    CreatedBy  INT NOT NULL CONSTRAINT FK_Photo_User REFERENCES dbo.[User](UserId),
    CreatedAt  DATETIME2 NOT NULL CONSTRAINT DF_Photo_Created DEFAULT SYSDATETIME(),
    CONSTRAINT CK_Photo_Owner CHECK ((PropertyId IS NOT NULL AND UnitId IS NULL) OR (PropertyId IS NULL AND UnitId IS NOT NULL)),
    CONSTRAINT CK_Photo_Size  CHECK (DATALENGTH(Image) <= 2097152)
);
CREATE INDEX IX_Photo_Property ON dbo.Photo(PropertyId) WHERE PropertyId IS NOT NULL;
CREATE INDEX IX_Photo_Unit     ON dbo.Photo(UnitId)     WHERE UnitId IS NOT NULL;

/* ---------- 7. Audit log ---------- */
CREATE TABLE dbo.AuditLog (
    LogId      BIGINT IDENTITY(1,1) CONSTRAINT PK_AuditLog PRIMARY KEY,
    UserId     INT NOT NULL CONSTRAINT FK_Audit_User REFERENCES dbo.[User](UserId),
    Action     NVARCHAR(50)  NOT NULL,
    EntityName NVARCHAR(50)  NOT NULL,
    EntityId   INT NULL,
    Details    NVARCHAR(500) NULL,
    CreatedAt  DATETIME2 NOT NULL CONSTRAINT DF_Audit_Created DEFAULT SYSDATETIME()
);
CREATE INDEX IX_Audit_Created ON dbo.AuditLog(CreatedAt DESC);
GO

/* ---------- 8. Views (balances are computed, never stored) ---------- */
-- each installment with what was paid on it (non-cancelled receipts), what remains, and its status
CREATE VIEW dbo.vw_InstallmentBalance AS
SELECT  i.InstallmentId, i.ContractId, i.InstallmentNo, i.DueDate, i.Amount,
        ISNULL(p.Paid, 0)            AS PaidAmount,
        i.Amount - ISNULL(p.Paid, 0) AS Remaining,
        CASE WHEN ISNULL(p.Paid, 0) >= i.Amount THEN N'Paid'
             WHEN ISNULL(p.Paid, 0) > 0         THEN N'Partial'
             ELSE N'Unpaid' END      AS Status
FROM dbo.Installment i
OUTER APPLY (SELECT SUM(pay.Amount) AS Paid FROM dbo.Payment pay
             WHERE pay.InstallmentId = i.InstallmentId AND pay.IsCancelled = 0) p;
GO

-- every contract with its unit, tenant, totals and remaining days
CREATE VIEW dbo.vw_ContractSummary AS
SELECT  c.ContractId, c.ContractNo, c.UnitId, c.TenantId, c.Status, c.StartDate, c.EndDate,
        c.MonthlyRent, c.PaymentCycle, c.Deposit, c.ClosedDate,
        u.UnitNo, u.UnitType, p.PropertyId, p.Name AS PropertyName,
        t.FullName AS TenantName, t.Phone AS TenantPhone, t.NationalId,
        DATEDIFF(DAY, CAST(SYSDATETIME() AS DATE), c.EndDate) AS DaysLeft,
        ISNULL(s.TotalAmount, 0) AS TotalAmount,
        ISNULL(s.TotalPaid, 0)   AS TotalPaid,
        ISNULL(s.TotalAmount, 0) - ISNULL(s.TotalPaid, 0) AS Balance,
        ISNULL(s.OverdueAmount, 0) AS OverdueAmount
FROM dbo.Contract c
JOIN dbo.Unit u     ON u.UnitId = c.UnitId
JOIN dbo.Property p ON p.PropertyId = u.PropertyId
JOIN dbo.Tenant t   ON t.TenantId = c.TenantId
OUTER APPLY (
    SELECT SUM(b.Amount) AS TotalAmount, SUM(b.PaidAmount) AS TotalPaid,
           SUM(CASE WHEN b.DueDate < CAST(SYSDATETIME() AS DATE) THEN b.Remaining ELSE 0 END) AS OverdueAmount
    FROM dbo.vw_InstallmentBalance b WHERE b.ContractId = c.ContractId
) s;
GO

-- BR-05: an installment is overdue when its due date has passed and it is not fully paid
CREATE VIEW dbo.vw_OverdueInstallments AS
SELECT  i.InstallmentId, i.ContractId, i.InstallmentNo, i.DueDate, i.Amount, i.PaidAmount, i.Remaining,
        DATEDIFF(DAY, i.DueDate, CAST(SYSDATETIME() AS DATE)) AS DaysLate,
        c.ContractNo, c.Status AS ContractStatus, u.UnitNo, p.PropertyId, p.Name AS PropertyName,
        t.TenantId, t.FullName AS TenantName, t.Phone AS TenantPhone
FROM dbo.vw_InstallmentBalance i
JOIN dbo.Contract c ON c.ContractId = i.ContractId
JOIN dbo.Unit u     ON u.UnitId = c.UnitId
JOIN dbo.Property p ON p.PropertyId = u.PropertyId
JOIN dbo.Tenant t   ON t.TenantId = c.TenantId
WHERE i.Remaining > 0
  AND i.DueDate < CAST(SYSDATETIME() AS DATE);
GO

/* ---------- 9. Stored procedures (each business operation = one transaction) ---------- */
-- internal: builds the payment schedule of a contract (BR-04)
-- each installment covers PaymentCycle months; the last one is prorated by the remaining months
CREATE PROCEDURE dbo.sp_GenerateInstallments
    @ContractId INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @start DATE, @stop DATE, @rent DECIMAL(18,3), @cycle INT;
    SELECT @start = StartDate, @stop = DATEADD(DAY, 1, EndDate), @rent = MonthlyRent, @cycle = PaymentCycle
    FROM dbo.Contract WHERE ContractId = @ContractId;

    DECLARE @no INT = 1, @due DATE = @start, @months INT;
    WHILE @due < @stop
    BEGIN
        SET @months = DATEDIFF(MONTH, @due, @stop);
        IF @months > @cycle SET @months = @cycle;
        IF @months < 1 SET @months = 1;
        INSERT dbo.Installment (ContractId, InstallmentNo, DueDate, Amount)
        VALUES (@ContractId, @no, @due, @rent * @months);
        SET @no += 1;
        SET @due = DATEADD(MONTH, @cycle * (@no - 1), @start);   -- always from the start date (no month-end drift)
    END
END;
GO

CREATE PROCEDURE dbo.sp_CreateContract
    @UnitId INT, @TenantId INT, @StartDate DATE, @EndDate DATE, @MonthlyRent DECIMAL(18,3),
    @PaymentCycle INT, @Deposit DECIMAL(18,3), @Notes NVARCHAR(500) = NULL, @UserId INT,
    @RenewedFrom INT = NULL, @ContractId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    IF @EndDate <= @StartDate THROW 50004, N'End date must be after start date.', 1;
    IF @PaymentCycle NOT IN (1, 3, 6, 12) THROW 50011, N'Invalid payment cycle.', 1;
    BEGIN TRAN;
        DECLARE @status NVARCHAR(20);
        SELECT @status = Status FROM dbo.Unit WITH (UPDLOCK, ROWLOCK) WHERE UnitId = @UnitId;
        IF @status IS NULL          THROW 50001, N'Unit not found.', 1;
        IF @status <> N'Vacant'     THROW 50002, N'Unit is not vacant.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.Tenant WHERE TenantId = @TenantId AND IsActive = 1)
                                    THROW 50003, N'Tenant not found or inactive.', 1;
        INSERT dbo.Contract (UnitId, TenantId, StartDate, EndDate, MonthlyRent, PaymentCycle, Deposit, Notes, RenewedFrom, CreatedBy)
        VALUES (@UnitId, @TenantId, @StartDate, @EndDate, @MonthlyRent, @PaymentCycle, @Deposit, @Notes, @RenewedFrom, @UserId);
        SET @ContractId = SCOPE_IDENTITY();
        EXEC dbo.sp_GenerateInstallments @ContractId;
        UPDATE dbo.Unit SET Status = N'Rented' WHERE UnitId = @UnitId;
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@UserId, N'CreateContract', N'Contract', @ContractId, CONCAT(N'UnitId=', @UnitId, N', TenantId=', @TenantId));
    COMMIT;
END;
GO

CREATE PROCEDURE dbo.sp_RecordPayment
    @InstallmentId INT, @Amount DECIMAL(18,3), @Date DATE, @Method NVARCHAR(20),
    @ReferenceNo NVARCHAR(50) = NULL, @Notes NVARCHAR(300) = NULL, @UserId INT, @PaymentId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        DECLARE @remaining DECIMAL(18,3), @contractId INT;
        -- قفل صف القسط حتى لا تُسجَّل دفعتان عليه في اللحظة نفسها
        SELECT @contractId = ContractId FROM dbo.Installment WITH (UPDLOCK, ROWLOCK) WHERE InstallmentId = @InstallmentId;
        IF @contractId IS NULL                    THROW 50005, N'Installment not found.', 1;
        SELECT @remaining = Remaining FROM dbo.vw_InstallmentBalance WHERE InstallmentId = @InstallmentId;
        IF @Amount <= 0 OR @Amount > @remaining   THROW 50006, N'Amount must be > 0 and <= remaining.', 1;
        INSERT dbo.Payment (InstallmentId, PaymentDate, Amount, Method, ReferenceNo, Notes, ReceivedBy)
        VALUES (@InstallmentId, @Date, @Amount, @Method, @ReferenceNo, @Notes, @UserId);
        SET @PaymentId = SCOPE_IDENTITY();
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@UserId, N'RecordPayment', N'Contract', @contractId, CONCAT(N'PaymentId=', @PaymentId, N', Amount=', @Amount));
    COMMIT;
END;
GO

-- receipts are not deleted: a manager cancels a wrong receipt; the view then stops counting it (balance restored)
CREATE PROCEDURE dbo.sp_CancelPayment
    @PaymentId INT, @Reason NVARCHAR(300), @ManagerId INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE UserId = @ManagerId AND Role = N'Manager' AND IsActive = 1)
            THROW 50008, N'Only a manager can do this operation.', 1;
        DECLARE @inst INT, @cancelled BIT;
        SELECT @inst = InstallmentId, @cancelled = IsCancelled
        FROM dbo.Payment WITH (UPDLOCK) WHERE PaymentId = @PaymentId;
        IF @inst IS NULL OR @cancelled = 1 THROW 50009, N'Receipt not found or already cancelled.', 1;
        UPDATE dbo.Payment SET IsCancelled = 1, CancelledBy = @ManagerId, CancelReason = @Reason WHERE PaymentId = @PaymentId;
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@ManagerId, N'CancelPayment', N'Payment', @PaymentId, @Reason);
    COMMIT;
END;
GO

-- @Terminate = 0: normal end on the contract end date  |  1: early termination (manager only)
CREATE PROCEDURE dbo.sp_CloseContract
    @ContractId INT, @Terminate BIT, @CloseDate DATE, @Reason NVARCHAR(300) = NULL, @UserId INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        DECLARE @unitId INT, @endDate DATE, @startDate DATE;
        SELECT @unitId = UnitId, @endDate = EndDate, @startDate = StartDate
        FROM dbo.Contract WITH (UPDLOCK) WHERE ContractId = @ContractId AND Status = N'Active';
        IF @unitId IS NULL THROW 50007, N'Contract not found or not active.', 1;
        IF @Terminate = 1
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE UserId = @UserId AND Role = N'Manager' AND IsActive = 1)
                THROW 50008, N'Only a manager can do this operation.', 1;
            -- terminating before the start date cancels the contract (e.g. a renewal entered by mistake)
            DECLARE @beforeStart BIT = CASE WHEN @CloseDate <= @startDate THEN 1 ELSE 0 END;
            IF @CloseDate < @startDate SET @CloseDate = @startDate;
            -- future installments that were never paid are removed from the schedule
            DELETE i FROM dbo.Installment i
            WHERE i.ContractId = @ContractId
              AND (i.DueDate > @CloseDate OR @beforeStart = 1)
              AND NOT EXISTS (SELECT 1 FROM dbo.Payment p WHERE p.InstallmentId = i.InstallmentId);
        END
        ELSE
        BEGIN
            IF CAST(SYSDATETIME() AS DATE) < @endDate THROW 50012, N'Contract has not reached its end date.', 1;
            SET @CloseDate = @endDate;
        END
        UPDATE dbo.Contract
        SET Status = CASE WHEN @Terminate = 1 THEN N'Terminated' ELSE N'Ended' END,
            ClosedDate = @CloseDate, CloseReason = @Reason
        WHERE ContractId = @ContractId;
        UPDATE dbo.Unit SET Status = N'Vacant' WHERE UnitId = @unitId;
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@UserId, CASE WHEN @Terminate = 1 THEN N'TerminateContract' ELSE N'EndContract' END, N'Contract', @ContractId, @Reason);
    COMMIT;
END;
GO

-- renewal: closes the current contract on its end date and opens a new one from the next day
CREATE PROCEDURE dbo.sp_RenewContract
    @ContractId INT, @NewEndDate DATE, @MonthlyRent DECIMAL(18,3), @PaymentCycle INT, @UserId INT,
    @NewContractId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        DECLARE @unitId INT, @tenantId INT, @endDate DATE, @deposit DECIMAL(18,3);
        SELECT @unitId = UnitId, @tenantId = TenantId, @endDate = EndDate, @deposit = Deposit
        FROM dbo.Contract WITH (UPDLOCK) WHERE ContractId = @ContractId AND Status = N'Active';
        IF @unitId IS NULL THROW 50007, N'Contract not found or not active.', 1;
        DECLARE @newStart DATE = DATEADD(DAY, 1, @endDate);
        IF @NewEndDate <= @newStart THROW 50004, N'End date must be after start date.', 1;

        UPDATE dbo.Contract SET Status = N'Ended', ClosedDate = @endDate, CloseReason = N'تجديد'
        WHERE ContractId = @ContractId;
        UPDATE dbo.Unit SET Status = N'Vacant' WHERE UnitId = @unitId;

        EXEC dbo.sp_CreateContract @UnitId = @unitId, @TenantId = @tenantId, @StartDate = @newStart, @EndDate = @NewEndDate,
             @MonthlyRent = @MonthlyRent, @PaymentCycle = @PaymentCycle, @Deposit = @deposit,
             @Notes = N'تجديد لعقد سابق', @UserId = @UserId, @RenewedFrom = @ContractId, @ContractId = @NewContractId OUTPUT;
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@UserId, N'RenewContract', N'Contract', @ContractId, CONCAT(N'NewContractId=', @NewContractId));
    COMMIT;
END;
GO
-- The first Manager account is created from the application (first-run screen),
-- because the password hash and salt are generated in C#.
