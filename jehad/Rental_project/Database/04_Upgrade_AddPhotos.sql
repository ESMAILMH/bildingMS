/* =====================================================================
   ترقية قاعدة موجودة: إضافة جدول الصور (Photo) دون حذف أي بيانات.
   لمن أنشأ RentalDB قبل إضافة ميزة الصور. آمن لو شُغّل أكثر من مرة.
   بعده يمكن تشغيل 03_SampleImages.sql (اختياري) لإضافة الصور التوضيحية.
   ===================================================================== */
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO
USE RentalDB;
GO
IF DB_NAME() <> N'RentalDB'
BEGIN
    RAISERROR(N'القاعدة RentalDB غير موجودة. شغّل RentalDB_Full.sql أولاً.', 16, 1);
    SET NOEXEC ON;
END
GO
IF OBJECT_ID(N'dbo.Photo', N'U') IS NULL
BEGIN
    -- كل صورة تخص عقاراً أو وحدة (واحداً منهما فقط)، بحد أقصى 2 ميغابايت
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
    PRINT N'تمت إضافة جدول الصور Photo.';
END
ELSE
    PRINT N'جدول الصور موجود بالفعل، لا حاجة للترقية.';
GO
SET NOEXEC OFF;
GO
