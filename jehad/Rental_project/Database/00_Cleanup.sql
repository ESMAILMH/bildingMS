/* =====================================================================
   تنظيف: يحذف جداول النظام التي أُنشئت بالخطأ في قاعدة master
   (يحدث عندما يفشل إنشاء RentalDB في التشغيل الأول).
   شغّله مرة واحدة فقط إذا ظهرت أخطاء "There is already an object named ...".
   ===================================================================== */
USE master;
GO
DROP PROCEDURE IF EXISTS dbo.sp_RenewContract, dbo.sp_CloseContract, dbo.sp_CancelPayment, dbo.sp_RecordPayment,
                         dbo.sp_CreateContract, dbo.sp_GenerateInstallments;
DROP VIEW IF EXISTS dbo.vw_OverdueInstallments, dbo.vw_ContractSummary, dbo.vw_InstallmentBalance;
DROP TABLE IF EXISTS dbo.AuditLog, dbo.Payment, dbo.Installment, dbo.Contract, dbo.Tenant, dbo.Unit, dbo.Property, dbo.[User];
GO
PRINT N'تم التنظيف. شغّل الآن 01_RentalDB.sql';
