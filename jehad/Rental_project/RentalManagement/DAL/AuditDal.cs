namespace RentalManagement.DAL;

/// <summary>سجل العمليات (AuditLog).</summary>
public static class AuditDal
{
    public static void Log(string action, string entity, int? entityId, string? details,
                           SqlConnection? c = null, SqlTransaction? t = null)
    {
        if (Session.Current == null) return;
        const string sql = @"INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
                             VALUES (@u, @a, @e, @id, @d)";
        var ps = new[] { Db.P("@u", Session.UserId), Db.P("@a", action), Db.P("@e", entity), Db.P("@id", entityId),
                         Db.P("@d", details is { Length: > 500 } ? details[..500] : details) };
        if (c != null) Db.Execute(c, t, sql, ps);
        else Db.Execute(sql, ps);
    }

    /// <summary>أسماء العمليات بالعربي لعرضها في السجل.</summary>
    private const string ActionText = @"CASE l.Action
            WHEN N'Login' THEN N'تسجيل دخول' WHEN N'Logout' THEN N'تسجيل خروج'
            WHEN N'AddUser' THEN N'إضافة مستخدم' WHEN N'EditUser' THEN N'تعديل مستخدم'
            WHEN N'ResetPassword' THEN N'إعادة تعيين كلمة مرور' WHEN N'ChangePassword' THEN N'تغيير كلمة المرور'
            WHEN N'AddProperty' THEN N'إضافة عقار' WHEN N'EditProperty' THEN N'تعديل عقار'
            WHEN N'AddUnit' THEN N'إضافة وحدة' WHEN N'EditUnit' THEN N'تعديل وحدة'
            WHEN N'AddTenant' THEN N'إضافة مستأجر' WHEN N'EditTenant' THEN N'تعديل مستأجر'
            WHEN N'CreateContract' THEN N'إبرام عقد' WHEN N'RenewContract' THEN N'تجديد عقد'
            WHEN N'EndContract' THEN N'إنهاء عقد' WHEN N'TerminateContract' THEN N'فسخ عقد'
            WHEN N'RecordPayment' THEN N'تسجيل دفعة' WHEN N'CancelPayment' THEN N'إلغاء إيصال'
            WHEN N'AddPhoto' THEN N'إضافة صورة' WHEN N'DeletePhoto' THEN N'حذف صورة'
            WHEN N'Settings' THEN N'تعديل الإعدادات' WHEN N'Backup' THEN N'نسخ احتياطي'
            ELSE l.Action END";

    public static DataTable Search(int? userId, DateTime from, DateTime to) => Db.Query($@"
        SELECT l.LogId AS Id, l.CreatedAt AS [الوقت], u.FullName AS [المستخدم],
               {ActionText} AS [العملية], l.EntityName AS [الكيان], l.EntityId AS [المعرّف], l.Details AS [التفاصيل]
        FROM dbo.AuditLog l
        JOIN dbo.[User] u ON u.UserId = l.UserId
        WHERE l.CreatedAt >= @from AND l.CreatedAt < DATEADD(DAY, 1, @to) AND (@u IS NULL OR l.UserId = @u)
        ORDER BY l.LogId DESC",
        Db.P("@from", from.Date), Db.P("@to", to.Date), Db.P("@u", userId));
}
