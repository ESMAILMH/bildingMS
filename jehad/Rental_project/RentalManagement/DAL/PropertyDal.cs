namespace RentalManagement.DAL;

/// <summary>العقارات (Property) ووحداتها (Unit).</summary>
public static class PropertyDal
{
    private const string ActiveText = "CASE {0} WHEN 1 THEN N'فعّال' ELSE N'معطّل' END";

    // ------------------------------------------------------------ العقارات
    public static DataTable Properties(string? search) => Db.Query($@"
        SELECT p.PropertyId AS Id, p.IsActive, p.Name AS [العقار], p.PropertyType AS [النوع], p.City AS [المدينة],
               p.Address AS [العنوان],
               (SELECT COUNT(*) FROM dbo.Unit u WHERE u.PropertyId = p.PropertyId) AS [عدد الوحدات],
               (SELECT COUNT(*) FROM dbo.Unit u WHERE u.PropertyId = p.PropertyId AND u.Status = N'Rented') AS [مؤجرة],
               (SELECT COUNT(*) FROM dbo.Unit u WHERE u.PropertyId = p.PropertyId AND u.Status = N'Vacant') AS [شاغرة],
               (SELECT COUNT(*) FROM dbo.Photo ph WHERE ph.PropertyId = p.PropertyId) AS [الصور],
               {string.Format(ActiveText, "p.IsActive")} AS [الحالة]
        FROM dbo.Property p
        WHERE @s IS NULL OR p.Name LIKE N'%' + @s + N'%' OR p.City LIKE N'%' + @s + N'%' OR p.Address LIKE N'%' + @s + N'%'
        ORDER BY p.Name", Db.P("@s", search));

    public static DataTable PropertyList() =>
        Db.Query("SELECT PropertyId AS Id, Name FROM dbo.Property WHERE IsActive = 1 ORDER BY Name");

    public static DataRow? Property(int id) => Db.Row("SELECT * FROM dbo.Property WHERE PropertyId=@id", Db.P("@id", id));

    public static int SaveProperty(int? id, string name, string type, string city, string? address, string? notes, bool active)
    {
        var ps = new[] { Db.P("@n", name), Db.P("@t", type), Db.P("@c", city), Db.P("@ad", address), Db.P("@no", notes),
                         Db.P("@a", active), Db.P("@id", id) };
        if (id is null)
            return Convert.ToInt32(Db.Scalar(@"INSERT dbo.Property (Name, PropertyType, City, Address, Notes, IsActive)
                                               OUTPUT INSERTED.PropertyId VALUES (@n, @t, @c, @ad, @no, @a)", ps));
        Db.Execute(@"UPDATE dbo.Property SET Name=@n, PropertyType=@t, City=@c, Address=@ad, Notes=@no, IsActive=@a
                     WHERE PropertyId=@id", ps);
        return id.Value;
    }

    public static int RentedUnits(int propertyId) =>
        Db.Int("SELECT COUNT(*) FROM dbo.Unit WHERE PropertyId=@p AND Status=N'Rented'", Db.P("@p", propertyId));

    // ------------------------------------------------------------ الوحدات
    public static DataTable Units(int? propertyId, string? status, string? search) => Db.Query($@"
        SELECT u.UnitId AS Id, u.PropertyId, u.Status, p.Name AS [العقار], u.UnitNo AS [رقم الوحدة], u.UnitType AS [النوع],
               u.FloorNo AS [الطابق], u.Area AS [المساحة م²], u.Rooms AS [الغرف], u.MonthlyRent AS [الإيجار الشهري],
               {Labels.Sql(Labels.SqlUnitStatus, "u.Status")} AS [الحالة],
               t.FullName AS [المستأجر الحالي], c.EndDate AS [ينتهي العقد في],
               (SELECT COUNT(*) FROM dbo.Photo ph WHERE ph.UnitId = u.UnitId) AS [الصور], u.Notes AS [ملاحظات]
        FROM dbo.Unit u
        JOIN dbo.Property p ON p.PropertyId = u.PropertyId
        LEFT JOIN dbo.Contract c ON c.UnitId = u.UnitId AND c.Status = N'Active'
        LEFT JOIN dbo.Tenant t ON t.TenantId = c.TenantId
        WHERE (@p IS NULL OR u.PropertyId = @p) AND (@st IS NULL OR u.Status = @st)
          AND (@s IS NULL OR u.UnitNo LIKE N'%' + @s + N'%' OR p.Name LIKE N'%' + @s + N'%' OR t.FullName LIKE N'%' + @s + N'%')
        ORDER BY p.Name, u.UnitNo",
        Db.P("@p", propertyId), Db.P("@st", status), Db.P("@s", search));

    /// <summary>عدد الوحدات في كل حالة (لأزرار التبويب في صفحة الوحدات).</summary>
    public static Dictionary<string, int> CountByStatus(int? propertyId) =>
        Db.Query("SELECT Status, COUNT(*) AS N FROM dbo.Unit WHERE @p IS NULL OR PropertyId=@p GROUP BY Status",
                Db.P("@p", propertyId))
            .AsEnumerable().ToDictionary(r => (string)r["Status"], r => (int)r["N"]);

    /// <summary>الوحدات الشاغرة فقط (لإبرام عقد جديد) بالشكل «العقار - رقم الوحدة».</summary>
    public static DataTable VacantUnitList(int? propertyId = null) => Db.Query(@"
        SELECT u.UnitId AS Id, p.Name + N' - ' + u.UnitType + N' ' + u.UnitNo AS Name, u.MonthlyRent
        FROM dbo.Unit u JOIN dbo.Property p ON p.PropertyId = u.PropertyId
        WHERE u.Status = N'Vacant' AND p.IsActive = 1 AND (@p IS NULL OR u.PropertyId = @p)
        ORDER BY p.Name, u.UnitNo", Db.P("@p", propertyId));

    public static DataRow? Unit(int id) => Db.Row(@"
        SELECT u.*, p.Name AS PropertyName FROM dbo.Unit u JOIN dbo.Property p ON p.PropertyId = u.PropertyId
        WHERE u.UnitId=@id", Db.P("@id", id));

    public static int SaveUnit(int? id, int propertyId, string unitNo, string type, int? floor, decimal? area, int? rooms,
                               decimal rent, string status, string? notes)
    {
        var ps = new[] { Db.P("@p", propertyId), Db.P("@no", unitNo), Db.P("@t", type), Db.P("@f", floor), Db.P("@ar", area),
                         Db.P("@r", rooms), Db.Money("@rent", rent), Db.P("@st", status), Db.P("@n", notes), Db.P("@id", id) };
        if (id is null)
            return Convert.ToInt32(Db.Scalar(@"
                INSERT dbo.Unit (PropertyId, UnitNo, UnitType, FloorNo, Area, Rooms, MonthlyRent, Status, Notes)
                OUTPUT INSERTED.UnitId VALUES (@p, @no, @t, @f, @ar, @r, @rent, @st, @n)", ps));
        Db.Execute(@"UPDATE dbo.Unit SET PropertyId=@p, UnitNo=@no, UnitType=@t, FloorNo=@f, Area=@ar, Rooms=@r,
                     MonthlyRent=@rent, Status=@st, Notes=@n WHERE UnitId=@id", ps);
        return id.Value;
    }
}
