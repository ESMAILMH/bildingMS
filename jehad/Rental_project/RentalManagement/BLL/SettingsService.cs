using RentalManagement.DAL;

namespace RentalManagement.BLL;

/// <summary>إعدادات المكتب والنسخ الاحتياطي (للمدير فقط).</summary>
public static class SettingsService
{
    public static void Save(string officeName, string? phone, string? address, int alertDays)
    {
        Session.Demand(Session.IsManager);
        if (string.IsNullOrWhiteSpace(officeName)) throw new AppException("الرجاء إدخال اسم المكتب.");
        if (alertDays is < 1 or > 365) throw new AppException("أيام التنبيه يجب أن تكون بين 1 و 365.");
        AppSettings.OfficeName = officeName.Trim();
        AppSettings.OfficePhone = phone?.Trim() ?? "";
        AppSettings.OfficeAddress = address?.Trim() ?? "";
        AppSettings.ContractAlertDays = alertDays;
        AppSettings.Save();
        AuditDal.Log("Settings", "Settings", null, $"AlertDays={alertDays}");
    }

    /// <summary>
    /// نسخة احتياطية كاملة من قاعدة البيانات (FR-30).
    /// ملاحظة: المسار يُكتب بواسطة خدمة SQL Server نفسها، لذلك يجب أن يكون مجلداً على جهاز الخادم تملك الخدمة صلاحية الكتابة فيه.
    /// </summary>
    public static string Backup(string folder)
    {
        Session.Demand(Session.IsManager);
        if (string.IsNullOrWhiteSpace(folder)) throw new AppException("الرجاء اختيار مجلد النسخة الاحتياطية.");
        string db = new SqlConnectionStringBuilder(AppSettings.ConnectionString).InitialCatalog;
        string file = Path.Combine(folder, $"{db}_{DateTime.Now:yyyyMMdd_HHmm}.bak");
        Db.Execute($"BACKUP DATABASE [{db.Replace("]", "]]")}] TO DISK = @f WITH INIT, NAME = N'RentalDB backup'",
            Db.P("@f", file));
        AuditDal.Log("Backup", "Database", null, file);
        return file;
    }
}
