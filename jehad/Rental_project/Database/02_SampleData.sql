/* =====================================================================
   بيانات تجريبية لنظام إدارة العقارات والإيجارات
   تُشغَّل بعد إنشاء قاعدة RentalDB (السكربت 01_RentalDB.sql)
   افتحه في SSMS من File > Open > File ثم اضغط Execute (F5)

   التواريخ محسوبة نسبةً إلى يوم التشغيل، لذلك تظهر التنبيهات (متأخرات + عقود قرب الانتهاء) دائماً عند العرض.

   حسابات الدخول التجريبية:
     admin    / Admin@123   (مدير)
     employee / Emp@123     (موظف)
     staff    / Staff@123   (موظف)
   ===================================================================== */
-- الإعدادات المطلوبة للأعمدة المحسوبة والفهارس المرشّحة (SSMS يضبطها تلقائياً، و sqlcmd لا يضبطها)
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO
GO
USE RentalDB;
GO
-- لا تُضاف البيانات مرتين
IF DB_NAME() <> N'RentalDB' OR EXISTS (SELECT 1 FROM dbo.Property)
BEGIN
    RAISERROR(N'القاعدة RentalDB غير موجودة أو تحتوي عقارات بالفعل. لم تُضف البيانات التجريبية.', 16, 1);
    SET NOEXEC ON;
END
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRAN;

/* ---------- المستخدمون (كلمات المرور مشفّرة PBKDF2-SHA256 مثل التطبيق تماماً) ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE Username = N'admin')
    INSERT dbo.[User] (Username, FullName, PasswordHash, PasswordSalt, Role) VALUES
    (N'admin', N'مدير النظام', 0x6539926B59C538A5579C0E80C3274278F10E4830FAAAF933E16BF2C2940A9C84, 0xA8620D31B06FC3189E4FBC5DA0BD5D7C, N'Manager');
IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE Username = N'employee')
    INSERT dbo.[User] (Username, FullName, PasswordHash, PasswordSalt, Role) VALUES
    (N'employee', N'جهاد سالم', 0x43FEBD9389C0FC48C858CC10AC96B05DC309016AE50EA83D12F04DD791629FA1, 0x8CDE19F41BD56FA3942B539E3EB43DF4, N'Employee');

IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE Username = N'staff')
    INSERT dbo.[User] (Username, FullName, PasswordHash, PasswordSalt, Role) VALUES
    (N'staff', N'سالمة علي الككلي', 0xF922636927EDC29596CB92006D9BEFE955C4BECEAE2D3921C1B987137D476E57, 0xA3CF50F1F58E1FE39BE36226705F8049, N'Employee');

DECLARE @mgr INT = (SELECT TOP 1 UserId FROM dbo.[User] WHERE Role = N'Manager' ORDER BY UserId);
DECLARE @emp INT = ISNULL((SELECT UserId FROM dbo.[User] WHERE Username = N'employee'), @mgr);

/* ---------- العقارات ---------- */
INSERT dbo.Property (Name, PropertyType, City, Address, Notes) VALUES
 (N'عمارة النور',       N'عمارة سكنية',  N'يفرن',   N'حي القلعة - بجانب المسجد العتيق', N'4 طوابق'),
 (N'مجمع الواحة التجاري', N'مجمع تجاري',  N'يفرن',   N'الطريق الرئيسي - وسط المدينة', NULL),
 (N'عمارة الزيتون',     N'عمارة سكنية',  N'غريان',  N'حي الأصابعة', NULL),
 (N'فيلا الياسمين',     N'فيلا',         N'طرابلس', N'حي الأندلس', N'فيلا بحديقة'),
 (N'مخزن الشرقية',      N'أخرى',         N'يفرن',   N'المنطقة الصناعية', N'معطّل: معروض للبيع');

DECLARE @p1 INT = (SELECT PropertyId FROM dbo.Property WHERE Name = N'عمارة النور');
DECLARE @p2 INT = (SELECT PropertyId FROM dbo.Property WHERE Name = N'مجمع الواحة التجاري');
DECLARE @p3 INT = (SELECT PropertyId FROM dbo.Property WHERE Name = N'عمارة الزيتون');
DECLARE @p4 INT = (SELECT PropertyId FROM dbo.Property WHERE Name = N'فيلا الياسمين');

/* ---------- الوحدات ---------- */
INSERT dbo.Unit (PropertyId, UnitNo, UnitType, FloorNo, Area, Rooms, MonthlyRent) VALUES
 (@p1, N'101', N'شقة', 1, 120, 3, 800),
 (@p1, N'102', N'شقة', 1, 110, 3, 750),
 (@p1, N'201', N'شقة', 2, 140, 4, 950),
 (@p1, N'202', N'شقة', 2, 140, 4, 950),
 (@p1, N'301', N'شقة', 3, 130, 3, 900),
 (@p2, N'S1',  N'محل', 0,  45, NULL, 1200),
 (@p2, N'S2',  N'محل', 0,  60, NULL, 1500),
 (@p2, N'S3',  N'محل', 0,  40, NULL, 1100),
 (@p2, N'O1',  N'مكتب', 1, 35, 2, 600),
 (@p2, N'O2',  N'مكتب', 1, 35, 2, 600),
 (@p3, N'A1',  N'شقة', 1, 100, 2, 650),
 (@p3, N'A2',  N'شقة', 1, 100, 2, 650),
 (@p3, N'B1',  N'مخزن', 0, 80, NULL, 400),
 (@p4, N'V1',  N'فيلا', 0, 350, 6, 2500);
UPDATE dbo.Unit SET Status = N'Maintenance', Notes = N'صيانة سباكة' WHERE PropertyId = @p3 AND UnitNo = N'A2';
-- عقار معطّل (أرشفة بتغيير الحالة) بوحدة شاغرة
DECLARE @p5 INT = (SELECT PropertyId FROM dbo.Property WHERE Name = N'مخزن الشرقية');
INSERT dbo.Unit (PropertyId, UnitNo, UnitType, FloorNo, Area, MonthlyRent) VALUES (@p5, N'W1', N'مخزن', 0, 200, 900);
UPDATE dbo.Property SET IsActive = 0 WHERE PropertyId = @p5;

/* ---------- المستأجرون ---------- */
INSERT dbo.Tenant (FullName, NationalId, Phone, Phone2, Address) VALUES
 (N'أحمد محمد سالم',         N'119870001234', N'0911111111', NULL,          N'يفرن'),
 (N'خالد علي الزروق',        N'119900005678', N'0922222222', N'0915555555', N'يفرن'),
 (N'شركة الأفق للتجارة',     N'REG-2020-555', N'0913333333', NULL,          N'يفرن'),
 (N'سالم عمر الهادي',        N'119850009999', N'0924444444', NULL,          N'طرابلس'),
 (N'فاطمة إبراهيم الصغير',   N'219920003333', N'0916666666', NULL,          N'يفرن'),
 (N'مكتب الرواد للمحاماة',   N'REG-2018-120', N'0927777777', NULL,          N'يفرن'),
 (N'محمود الهادي بن علي',    N'119880004444', N'0918888888', NULL,          N'غريان'),
 (N'يوسف ناصر القماطي',      N'119950002222', N'0929999999', NULL,          N'غريان'),
 (N'مصطفى سالم القاضي',     N'119830007777', N'0911212121', NULL,          N'يفرن');

DECLARE @today DATE = CAST(SYSDATETIME() AS DATE);
DECLARE @c INT, @s DATE, @e DATE;
DECLARE @t TABLE (ContractId INT, PaidCount INT);   -- كم قسطاً سُدّد من كل عقد

DECLARE @u INT, @tn INT;

/* ---------- العقود (عبر الإجراء المخزن: يولّد الأقساط ويغيّر حالة الوحدة) ---------- */
-- 1) عمارة النور 101 — أحمد: شهري، بدأ قبل 5 أشهر لمدة سنة، سُدّد قسطان فقط (تظهر متأخرات)
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p1 AND UnitNo = N'101';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'119870001234';
SET @s = DATEADD(MONTH, -5, @today); SET @e = DATEADD(DAY, -1, DATEADD(YEAR, 1, @s));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 800, 1, 800, NULL, @emp, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 2);

-- 2) عمارة النور 201 — خالد: نصف سنوي لمدة سنتين، بدأ قبل شهرين، القسط الأول مسدد
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p1 AND UnitNo = N'201';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'119900005678';
SET @s = DATEADD(MONTH, -2, @today); SET @e = DATEADD(DAY, -1, DATEADD(YEAR, 2, @s));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 950, 6, 950, NULL, @emp, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 1);

-- 3) مجمع الواحة S1 — شركة الأفق: ربع سنوي، ينتهي بعد 20 يوماً (تنبيه قرب الانتهاء)، كل الأقساط مسددة
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p2 AND UnitNo = N'S1';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'REG-2020-555';
SET @e = DATEADD(DAY, 20, @today); SET @s = DATEADD(DAY, 1, DATEADD(YEAR, -1, @e));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 1200, 3, 2400, NULL, @mgr, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 4);

-- 4) مجمع الواحة O1 — مكتب الرواد: شهري، بدأ قبل 3 أشهر، كل ما استحق مسدد
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p2 AND UnitNo = N'O1';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'REG-2018-120';
SET @s = DATEADD(MONTH, -3, @today); SET @e = DATEADD(DAY, -1, DATEADD(YEAR, 1, @s));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 600, 1, 600, NULL, @emp, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 4);

-- 5) فيلا الياسمين — سالم: سنوي، بدأ قبل شهر، القسط الأول مسدد
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p4 AND UnitNo = N'V1';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'119850009999';
SET @s = DATEADD(MONTH, -1, @today); SET @e = DATEADD(DAY, -1, DATEADD(YEAR, 1, @s));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 2500, 12, 5000, NULL, @mgr, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 1);

-- 6) عمارة الزيتون A1 — محمود: شهري، ينتهي بعد 10 أيام، عليه قسطان متأخران
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p3 AND UnitNo = N'A1';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'119880004444';
SET @e = DATEADD(DAY, 10, @today); SET @s = DATEADD(DAY, 1, DATEADD(MONTH, -6, @e));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 650, 1, 650, NULL, @emp, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 4);

-- 7) مجمع الواحة S2 — فاطمة: عقد قديم انتهى (يظهر في السجل)، ثم الوحدة شاغرة
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p2 AND UnitNo = N'S2';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'219920003333';
SET @s = DATEADD(MONTH, -14, @today); SET @e = DATEADD(DAY, -1, DATEADD(YEAR, 1, @s));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 1500, 3, 3000, NULL, @mgr, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 4);
EXEC dbo.sp_CloseContract @c, 0, @e, N'انتهاء المدة', @mgr;

-- 8) مجمع الواحة S3 — يوسف: شهري لسنة بدأ قبل 8 أشهر، سُدّدت 3 أقساط، ثم فُسخ قبل شهرين (يُفسخ بعد تسجيل الدفعات)
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p2 AND UnitNo = N'S3';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'119950002222';
SET @s = DATEADD(MONTH, -8, @today); SET @e = DATEADD(DAY, -1, DATEADD(YEAR, 1, @s));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 1100, 1, 1100, NULL, @emp, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 3);
DECLARE @terminated INT = @c;

-- 9) مجمع الواحة O2 — مصطفى: انتهت مدته قبل 5 أيام ولم يُغلق بعد (تنبيه)، كل الأقساط مسددة
SELECT @u = UnitId FROM dbo.Unit WHERE PropertyId = @p2 AND UnitNo = N'O2';
SELECT @tn = TenantId FROM dbo.Tenant WHERE NationalId = N'119830007777';
SET @e = DATEADD(DAY, -5, @today); SET @s = DATEADD(DAY, 1, DATEADD(YEAR, -1, @e));
EXEC dbo.sp_CreateContract @u, @tn, @s, @e, 600, 6, 600, NULL, @emp, NULL, @c OUTPUT;
INSERT @t VALUES (@c, 2);

/* ---------- الدفعات: سداد أول N أقساط من كل عقد في تاريخ استحقاقها ---------- */
DECLARE @inst INT, @amt DECIMAL(18,3), @due DATE, @pay INT, @i INT = 0, @method NVARCHAR(20);
DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
    SELECT i.InstallmentId, i.Amount, i.DueDate
    FROM dbo.Installment i JOIN @t x ON x.ContractId = i.ContractId
    WHERE i.InstallmentNo <= x.PaidCount AND i.DueDate <= @today
    ORDER BY i.DueDate;
OPEN cur;
FETCH NEXT FROM cur INTO @inst, @amt, @due;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @i += 1;
    SET @method = CASE WHEN @i % 3 = 0 THEN N'Transfer' WHEN @i % 5 = 0 THEN N'Cheque' ELSE N'Cash' END;
    EXEC dbo.sp_RecordPayment @inst, @amt, @due, @method, NULL, NULL, @emp, @pay OUTPUT;
    FETCH NEXT FROM cur INTO @inst, @amt, @due;
END
CLOSE cur; DEALLOCATE cur;

-- دفعة جزئية على القسط الثالث من العقد الأول (300 من 800)
SELECT @inst = i.InstallmentId, @due = i.DueDate
FROM dbo.Installment i JOIN dbo.Contract c ON c.ContractId = i.ContractId
JOIN dbo.Unit u ON u.UnitId = c.UnitId
WHERE u.PropertyId = @p1 AND u.UnitNo = N'101' AND c.Status = N'Active' AND i.InstallmentNo = 3;
EXEC dbo.sp_RecordPayment @inst, 300, @due, N'Transfer', N'TRX-7781', N'دفعة جزئية', @emp, @pay OUTPUT;

-- فسخ العقد 8 قبل شهرين (المدير): تُحذف أقساطه المستقبلية غير المسددة، وتبقى المتأخرة ديناً
DECLARE @closeDate DATE = DATEADD(MONTH, -2, @today);
EXEC dbo.sp_CloseContract @terminated, 1, @closeDate, N'رغبة المستأجر في الإخلاء', @mgr;

-- إيصال خاطئ: سُجّل القسط الثاني لمكتب الرواد نقداً بالخطأ، فألغاه المدير وسُجّل من جديد بتحويل مصرفي
DECLARE @o1 INT = (SELECT c.ContractId FROM dbo.Contract c JOIN dbo.Unit u ON u.UnitId = c.UnitId
                   WHERE u.PropertyId = @p2 AND u.UnitNo = N'O1' AND c.Status = N'Active');
SELECT @inst = i.InstallmentId, @due = i.DueDate FROM dbo.Installment i WHERE i.ContractId = @o1 AND i.InstallmentNo = 2;
DECLARE @wrong INT = (SELECT MAX(PaymentId) FROM dbo.Payment WHERE InstallmentId = @inst);
EXEC dbo.sp_CancelPayment @wrong, N'خطأ في طريقة الدفع', @mgr;
EXEC dbo.sp_RecordPayment @inst, 600, @due, N'Transfer', N'TRX-9902', N'بدل الإيصال الملغى', @emp, @pay OUTPUT;

-- مستأجر معطّل: فاطمة (انتهى عقدها ولم تعد مستأجرة)
UPDATE dbo.Tenant SET IsActive = 0 WHERE NationalId = N'219920003333';

COMMIT;
GO
SET NOEXEC OFF;
GO
PRINT N'تمت إضافة البيانات التجريبية. ادخل بـ admin / Admin@123 أو employee / Emp@123 أو staff / Staff@123';
