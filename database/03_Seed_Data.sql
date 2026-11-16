/* =====================================================================
   الملف 3 من 3: بيانات تجريبية (للاختبار والعرض أمام لجنة المناقشة)
   ===================================================================== */
USE RentalDB;
GO

-- إعدادات المكتب
IF NOT EXISTS (SELECT 1 FROM dbo.Settings)
    INSERT INTO dbo.Settings (SettingsID, OfficeName, OfficePhone, OfficeAddress, ContractAlertDays)
    VALUES (1, N'مكتب الأمانة للعقارات', N'091-0000000', N'يفرن - الشارع الرئيسي', 30);

-- المستخدمون: admin / Admin@123  ،  employee / Emp@123
DECLARE @s1 NVARCHAR(36) = CONVERT(NVARCHAR(36), NEWID()),
        @s2 NVARCHAR(36) = CONVERT(NVARCHAR(36), NEWID());

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = N'admin')
    INSERT INTO dbo.Users (FullName, Username, PasswordHash, Salt, Role)
    VALUES (N'مدير النظام', N'admin', HASHBYTES('SHA2_256', @s1 + N'Admin@123'), @s1, N'Admin');

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = N'employee')
    INSERT INTO dbo.Users (FullName, Username, PasswordHash, Salt, Role)
    VALUES (N'موظف الاستقبال', N'employee', HASHBYTES('SHA2_256', @s2 + N'Emp@123'), @s2, N'Employee');
GO

-- العقارات
INSERT INTO dbo.Properties (PropertyName, PropertyType, City, Address) VALUES
 (N'عمارة النور',      N'عمارة',      N'يفرن',   N'حي القلعة'),
 (N'مجمع الواحة',      N'مجمع تجاري', N'غريان',  N'الطريق الرئيسي'),
 (N'فيلا الياسمين',    N'فيلا',       N'طرابلس', N'حي الأندلس');

-- الوحدات
INSERT INTO dbo.Units (PropertyID, UnitNumber, UnitType, FloorNo, Area, Rooms, DefaultRent) VALUES
 (1, N'101', N'شقة', 1, 120, 3, 800),
 (1, N'102', N'شقة', 1, 110, 3, 750),
 (1, N'201', N'شقة', 2, 140, 4, 950),
 (1, N'202', N'شقة', 2, 140, 4, 950),
 (2, N'S1',  N'محل', 0,  45, NULL, 1200),
 (2, N'S2',  N'محل', 0,  60, NULL, 1500),
 (2, N'O1',  N'مكتب', 1, 35, 2, 600),
 (3, N'V1',  N'فيلا', 0, 300, 6, 2500);

-- المستأجرون
INSERT INTO dbo.Tenants (FullName, NationalID, Phone, Address) VALUES
 (N'أحمد محمد سالم',     N'119870001234', N'0911111111', N'يفرن'),
 (N'خالد علي الزروق',    N'119900005678', N'0922222222', N'يفرن'),
 (N'شركة الأفق للتجارة', N'REG-2020-555', N'0913333333', N'غريان'),
 (N'سالم عمر الهادي',    N'119850009999', N'0924444444', N'طرابلس');
GO

-- العقود (تواريخ نسبية لليوم لتظهر التنبيهات دائماً عند العرض)
DECLARE @id INT, @today DATE = CAST(GETDATE() AS DATE), @d1 DATE, @d2 DATE;

-- عقد شهري بدأ قبل 5 أشهر لمدة سنة (سيظهر عليه أقساط متأخرة)
SET @d1 = DATEADD(MONTH, -5, @today); SET @d2 = DATEADD(DAY, -1, DATEADD(YEAR, 1, @d1));
EXEC dbo.sp_CreateContract 1, 1, @d1, @d2, 800, 1, 800, NULL, 1, @id OUTPUT;

-- عقد ربع سنوي ينتهي بعد ~20 يوماً (سيظهر في تنبيه قرب الانتهاء)
SET @d2 = DATEADD(DAY, 20, @today); SET @d1 = DATEADD(DAY, 1, DATEADD(YEAR, -1, @d2));
EXEC dbo.sp_CreateContract 5, 3, @d1, @d2, 1200, 3, 2400, NULL, 1, @id OUTPUT;

-- عقد سنوي جديد
SET @d1 = DATEADD(MONTH, -1, @today); SET @d2 = DATEADD(DAY, -1, DATEADD(YEAR, 1, @d1));
EXEC dbo.sp_CreateContract 8, 4, @d1, @d2, 2500, 12, 5000, NULL, 1, @id OUTPUT;

-- عقد نصف سنوي
SET @d1 = DATEADD(MONTH, -2, @today); SET @d2 = DATEADD(DAY, -1, DATEADD(YEAR, 2, @d1));
EXEC dbo.sp_CreateContract 3, 2, @d1, @d2, 950, 6, 950, NULL, 1, @id OUTPUT;
GO

-- دفعات: سداد أول قسطين من العقد 1 + جزء من الثالث، وسداد كامل العقد 2 ما عدا الأخير
DECLARE @p INT, @today DATE = CAST(GETDATE() AS DATE), @inst INT, @amt DECIMAL(12,2), @due DATE;

DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
    SELECT InstallmentID, Amount, DueDate FROM dbo.Installments
    WHERE (ContractID = 1 AND InstallmentNo <= 2)
       OR (ContractID = 2 AND InstallmentNo <= 3)
       OR (ContractID = 3 AND InstallmentNo = 1)
       OR (ContractID = 4 AND InstallmentNo = 1);
OPEN cur;
FETCH NEXT FROM cur INTO @inst, @amt, @due;
WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC dbo.sp_RecordPayment @inst, @amt, @due, N'Cash', NULL, NULL, 2, @p OUTPUT;
    FETCH NEXT FROM cur INTO @inst, @amt, @due;
END
CLOSE cur; DEALLOCATE cur;

-- دفعة جزئية على القسط الثالث من العقد 1
SELECT @inst = InstallmentID, @due = DueDate FROM dbo.Installments WHERE ContractID = 1 AND InstallmentNo = 3;
EXEC dbo.sp_RecordPayment @inst, 300, @due, N'BankTransfer', N'TRX-7781', NULL, 2, @p OUTPUT;
GO

-- تحقق سريع
EXEC dbo.sp_DashboardSummary;
SELECT * FROM dbo.vw_OverdueInstallments;
SELECT * FROM dbo.vw_ExpiringContracts;
