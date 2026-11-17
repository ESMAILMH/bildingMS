namespace RentalManagement.DAL;

/// <summary>المستأجرون (Tenant).</summary>
public static class TenantDal
{
    public static DataTable Tenants(string? search) => Db.Query(@"
        SELECT t.TenantId AS Id, t.IsActive, t.FullName AS [الاسم], t.NationalId AS [الرقم الوطني / السجل],
               t.Phone AS [الهاتف], t.Phone2 AS [هاتف آخر], t.Address AS [العنوان],
               (SELECT COUNT(*) FROM dbo.Contract c WHERE c.TenantId = t.TenantId AND c.Status = N'Active') AS [عقود نشطة],
               ISNULL((SELECT SUM(o.Remaining) FROM dbo.vw_OverdueInstallments o WHERE o.TenantId = t.TenantId), 0) AS [متأخرات],
               CASE t.IsActive WHEN 1 THEN N'فعّال' ELSE N'معطّل' END AS [الحالة]
        FROM dbo.Tenant t
        WHERE @s IS NULL OR t.FullName LIKE N'%' + @s + N'%' OR t.NationalId LIKE N'%' + @s + N'%'
              OR t.Phone LIKE N'%' + @s + N'%' OR t.Phone2 LIKE N'%' + @s + N'%'
        ORDER BY t.FullName", Db.P("@s", search));

    public static DataTable TenantList() => Db.Query(@"
        SELECT TenantId AS Id, FullName + N' (' + NationalId + N')' AS Name
        FROM dbo.Tenant WHERE IsActive = 1 ORDER BY FullName");

    /// <summary>كل المستأجرين (حتى المعطّلين) لكشف الحساب.</summary>
    public static DataTable AllTenantList() => Db.Query(@"
        SELECT TenantId AS Id, FullName + N' (' + NationalId + N')' AS Name FROM dbo.Tenant ORDER BY FullName");

    public static DataRow? Tenant(int id) => Db.Row("SELECT * FROM dbo.Tenant WHERE TenantId=@id", Db.P("@id", id));

    public static int SaveTenant(int? id, string fullName, string nationalId, string phone, string? phone2, string? email,
                                 string? address, string? notes, bool active)
    {
        var ps = new[] { Db.P("@n", fullName), Db.P("@nid", nationalId), Db.P("@ph", phone), Db.P("@ph2", phone2),
                         Db.P("@e", email), Db.P("@ad", address), Db.P("@no", notes), Db.P("@a", active), Db.P("@id", id) };
        if (id is null)
            return Convert.ToInt32(Db.Scalar(@"
                INSERT dbo.Tenant (FullName, NationalId, Phone, Phone2, Email, Address, Notes, IsActive)
                OUTPUT INSERTED.TenantId VALUES (@n, @nid, @ph, @ph2, @e, @ad, @no, @a)", ps));
        Db.Execute(@"UPDATE dbo.Tenant SET FullName=@n, NationalId=@nid, Phone=@ph, Phone2=@ph2, Email=@e, Address=@ad,
                     Notes=@no, IsActive=@a WHERE TenantId=@id", ps);
        return id.Value;
    }

    public static int ActiveContracts(int tenantId) =>
        Db.Int("SELECT COUNT(*) FROM dbo.Contract WHERE TenantId=@t AND Status=N'Active'", Db.P("@t", tenantId));
}
