/* =====================================================================
   نظام إدارة العقارات والإيجارات - سكربت إنشاء قاعدة البيانات
   الملف 1 من 3: الجداول والقيود والفهارس
   التشغيل: SQL Server 2016 أو أحدث (يشمل Express و LocalDB)
   ===================================================================== */

IF DB_ID(N'RentalDB') IS NULL
    CREATE DATABASE RentalDB COLLATE Arabic_CI_AS;
GO
USE RentalDB;
GO

/* ---------------------------------------------------------------------
   1) المستخدمون
   كلمة المرور تُخزن كـ SHA2_256( Salt + Password ) بترميز UTF-16 (NVARCHAR)
   وفي C#:  SHA256.HashData(Encoding.Unicode.GetBytes(salt + password))
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Users (
    UserID        INT IDENTITY(1,1)  NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
    FullName      NVARCHAR(100)      NOT NULL,
    Username      NVARCHAR(50)       NOT NULL CONSTRAINT UQ_Users_Username UNIQUE,
    PasswordHash  VARBINARY(32)      NOT NULL,
    Salt          NVARCHAR(36)       NOT NULL,
    Role          NVARCHAR(20)       NOT NULL CONSTRAINT CK_Users_Role CHECK (Role IN (N'Admin', N'Employee')),
    IsActive      BIT                NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT (1),
    CreatedAt     DATETIME2(0)       NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT (SYSDATETIME())
);
GO

/* ---------------------------------------------------------------------
   2) إعدادات المكتب (صف واحد فقط)
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Settings (
    SettingsID          TINYINT        NOT NULL CONSTRAINT PK_Settings PRIMARY KEY
                                       CONSTRAINT CK_Settings_Single CHECK (SettingsID = 1),
    OfficeName          NVARCHAR(150)  NOT NULL,
    OfficePhone         NVARCHAR(30)   NULL,
    OfficeAddress       NVARCHAR(200)  NULL,
    ContractAlertDays   INT            NOT NULL CONSTRAINT DF_Settings_AlertDays DEFAULT (30)
                                       CONSTRAINT CK_Settings_AlertDays CHECK (ContractAlertDays BETWEEN 1 AND 365),
    Currency            NVARCHAR(10)   NOT NULL CONSTRAINT DF_Settings_Currency DEFAULT (N'د.ل')
);
GO

/* ---------------------------------------------------------------------
   3) العقارات
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Properties (
    PropertyID     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Properties PRIMARY KEY,
    PropertyName   NVARCHAR(100)     NOT NULL,
    PropertyType   NVARCHAR(30)      NOT NULL
                   CONSTRAINT CK_Properties_Type CHECK (PropertyType IN (N'عمارة', N'فيلا', N'مجمع تجاري', N'منزل', N'أرض', N'أخرى')),
    City           NVARCHAR(50)      NOT NULL,
    Address        NVARCHAR(200)     NULL,
    Description    NVARCHAR(500)     NULL,
    CreatedAt      DATETIME2(0)      NOT NULL CONSTRAINT DF_Properties_CreatedAt DEFAULT (SYSDATETIME())
);
GO

/* ---------------------------------------------------------------------
   4) الوحدات (شقة / محل / مكتب ...) التابعة للعقار
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Units (
    UnitID        INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Units PRIMARY KEY,
    PropertyID    INT               NOT NULL CONSTRAINT FK_Units_Properties REFERENCES dbo.Properties(PropertyID),
    UnitNumber    NVARCHAR(20)      NOT NULL,
    UnitType      NVARCHAR(20)      NOT NULL
                  CONSTRAINT CK_Units_Type CHECK (UnitType IN (N'شقة', N'محل', N'مكتب', N'مخزن', N'فيلا', N'أخرى')),
    FloorNo       INT               NULL,
    Area          DECIMAL(8,2)      NULL CONSTRAINT CK_Units_Area CHECK (Area IS NULL OR Area > 0),
    Rooms         TINYINT           NULL,
    DefaultRent   DECIMAL(12,2)     NOT NULL CONSTRAINT CK_Units_Rent CHECK (DefaultRent >= 0),
    Status        NVARCHAR(20)      NOT NULL CONSTRAINT DF_Units_Status DEFAULT (N'Vacant')
                  CONSTRAINT CK_Units_Status CHECK (Status IN (N'Vacant', N'Rented', N'Maintenance')),
    Notes         NVARCHAR(300)     NULL,
    CONSTRAINT UQ_Units_Property_Number UNIQUE (PropertyID, UnitNumber)
);
GO

/* ---------------------------------------------------------------------
   5) المستأجرون
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Tenants (
    TenantID      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Tenants PRIMARY KEY,
    FullName      NVARCHAR(100)     NOT NULL,
    NationalID    NVARCHAR(20)      NOT NULL CONSTRAINT UQ_Tenants_NationalID UNIQUE,
    Phone         NVARCHAR(20)      NOT NULL,
    AltPhone      NVARCHAR(20)      NULL,
    Email         NVARCHAR(100)     NULL,
    Address       NVARCHAR(200)     NULL,
    Notes         NVARCHAR(300)     NULL,
    CreatedAt     DATETIME2(0)      NOT NULL CONSTRAINT DF_Tenants_CreatedAt DEFAULT (SYSDATETIME())
);
GO

/* ---------------------------------------------------------------------
   6) عقود الإيجار
   PaymentFrequency = عدد الأشهر في كل دفعة: 1 شهري، 3 ربع سنوي، 6 نصف سنوي، 12 سنوي
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Contracts (
    ContractID        INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Contracts PRIMARY KEY,
    ContractNumber    AS (N'C-' + RIGHT(N'000000' + CAST(ContractID AS NVARCHAR(10)), 6)) PERSISTED,
    UnitID            INT               NOT NULL CONSTRAINT FK_Contracts_Units   REFERENCES dbo.Units(UnitID),
    TenantID          INT               NOT NULL CONSTRAINT FK_Contracts_Tenants REFERENCES dbo.Tenants(TenantID),
    StartDate         DATE              NOT NULL,
    EndDate           DATE              NOT NULL,
    MonthlyRent       DECIMAL(12,2)     NOT NULL CONSTRAINT CK_Contracts_Rent CHECK (MonthlyRent > 0),
    PaymentFrequency  TINYINT           NOT NULL CONSTRAINT CK_Contracts_Freq CHECK (PaymentFrequency IN (1, 3, 6, 12)),
    DepositAmount     DECIMAL(12,2)     NOT NULL CONSTRAINT DF_Contracts_Deposit DEFAULT (0)
                                        CONSTRAINT CK_Contracts_Deposit CHECK (DepositAmount >= 0),
    Status            NVARCHAR(20)      NOT NULL CONSTRAINT DF_Contracts_Status DEFAULT (N'Active')
                      CONSTRAINT CK_Contracts_Status CHECK (Status IN (N'Active', N'Ended', N'Terminated')),
    ClosedDate        DATE              NULL,
    Notes             NVARCHAR(500)     NULL,
    CreatedBy         INT               NOT NULL CONSTRAINT FK_Contracts_Users REFERENCES dbo.Users(UserID),
    CreatedAt         DATETIME2(0)      NOT NULL CONSTRAINT DF_Contracts_CreatedAt DEFAULT (SYSDATETIME()),
    CONSTRAINT CK_Contracts_Dates CHECK (EndDate > StartDate)
);
GO
-- قاعدة العمل BR-01: عقد نشط واحد فقط لكل وحدة (فهرس فريد مُرشَّح)
CREATE UNIQUE INDEX UX_Contracts_OneActivePerUnit ON dbo.Contracts(UnitID) WHERE Status = N'Active';
CREATE INDEX IX_Contracts_Tenant  ON dbo.Contracts(TenantID);
CREATE INDEX IX_Contracts_EndDate ON dbo.Contracts(EndDate) INCLUDE (Status);
GO

/* ---------------------------------------------------------------------
   7) جدول الأقساط (يُولَّد تلقائياً عند إبرام العقد)
   PaidAmount: قيمة مشتقة يحدّثها إجراء تسجيل الدفعة داخل معاملة (لتسريع الاستعلامات)
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Installments (
    InstallmentID   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Installments PRIMARY KEY,
    ContractID      INT               NOT NULL CONSTRAINT FK_Installments_Contracts REFERENCES dbo.Contracts(ContractID),
    InstallmentNo   INT               NOT NULL,
    DueDate         DATE              NOT NULL,
    Amount          DECIMAL(12,2)     NOT NULL CONSTRAINT CK_Installments_Amount CHECK (Amount > 0),
    PaidAmount      DECIMAL(12,2)     NOT NULL CONSTRAINT DF_Installments_Paid DEFAULT (0),
    Status          AS (CASE WHEN PaidAmount >= Amount THEN N'Paid'
                             WHEN PaidAmount > 0       THEN N'Partial'
                             ELSE N'Unpaid' END) PERSISTED,
    CONSTRAINT UQ_Installments_Contract_No UNIQUE (ContractID, InstallmentNo),
    CONSTRAINT CK_Installments_Paid CHECK (PaidAmount >= 0 AND PaidAmount <= Amount)   -- BR-06
);
GO
CREATE INDEX IX_Installments_DueDate ON dbo.Installments(DueDate) INCLUDE (Amount, PaidAmount, ContractID);
GO

/* ---------------------------------------------------------------------
   8) الدفعات (كل دفعة = إيصال قبض)
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Payments (
    PaymentID       INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Payments PRIMARY KEY,
    ReceiptNumber   AS (N'R-' + RIGHT(N'000000' + CAST(PaymentID AS NVARCHAR(10)), 6)) PERSISTED,
    InstallmentID   INT               NOT NULL CONSTRAINT FK_Payments_Installments REFERENCES dbo.Installments(InstallmentID),
    PaymentDate     DATE              NOT NULL CONSTRAINT DF_Payments_Date DEFAULT (CAST(GETDATE() AS DATE)),
    Amount          DECIMAL(12,2)     NOT NULL CONSTRAINT CK_Payments_Amount CHECK (Amount > 0),
    PaymentMethod   NVARCHAR(20)      NOT NULL
                    CONSTRAINT CK_Payments_Method CHECK (PaymentMethod IN (N'Cash', N'BankTransfer', N'Cheque')),
    ReferenceNo     NVARCHAR(50)      NULL,      -- رقم الصك أو الحوالة
    Notes           NVARCHAR(300)     NULL,
    ReceivedBy      INT               NOT NULL CONSTRAINT FK_Payments_Users REFERENCES dbo.Users(UserID),
    CreatedAt       DATETIME2(0)      NOT NULL CONSTRAINT DF_Payments_CreatedAt DEFAULT (SYSDATETIME())
);
GO
CREATE INDEX IX_Payments_Installment ON dbo.Payments(InstallmentID);
CREATE INDEX IX_Payments_Date        ON dbo.Payments(PaymentDate) INCLUDE (Amount);
GO
