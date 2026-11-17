namespace RentalManagement.DAL;

/// <summary>جدول المستخدمين (User).</summary>
public static class UserDal
{
    public static int Count() => Db.Int("SELECT COUNT(*) FROM dbo.[User]");

    public static DataRow? GetByUsername(string username) => Db.Row(@"
        SELECT UserId, Username, FullName, PasswordHash, PasswordSalt, Role, IsActive
        FROM dbo.[User] WHERE Username = @u", Db.P("@u", username));

    public static DataRow? Get(int id) => Db.Row("SELECT * FROM dbo.[User] WHERE UserId = @id", Db.P("@id", id));

    public static DataTable GetAll() => Db.Query($@"
        SELECT u.UserId AS Id, u.Role, u.IsActive, u.Username AS [اسم المستخدم], u.FullName AS [الاسم],
               {Labels.Sql(Labels.SqlRole, "u.Role")} AS [الصلاحية],
               u.LastLogin AS [آخر دخول],
               CASE u.IsActive WHEN 1 THEN N'فعّال' ELSE N'معطّل' END AS [الحالة]
        FROM dbo.[User] u
        ORDER BY u.Username");

    public static int Insert(string username, string fullName, byte[] hash, byte[] salt, string role, bool active) =>
        Convert.ToInt32(Db.Scalar(@"
            INSERT dbo.[User] (Username, FullName, PasswordHash, PasswordSalt, Role, IsActive)
            OUTPUT INSERTED.UserId VALUES (@u, @n, @h, @s, @r, @a)",
            Db.P("@u", username), Db.P("@n", fullName), Db.Binary("@h", hash), Db.Binary("@s", salt),
            Db.P("@r", role), Db.P("@a", active)));

    public static void Update(int id, string username, string fullName, string role, bool active) =>
        Db.Execute("UPDATE dbo.[User] SET Username=@u, FullName=@n, Role=@r, IsActive=@a WHERE UserId=@id",
            Db.P("@u", username), Db.P("@n", fullName), Db.P("@r", role), Db.P("@a", active), Db.P("@id", id));

    public static void SetPassword(int id, byte[] hash, byte[] salt) =>
        Db.Execute("UPDATE dbo.[User] SET PasswordHash=@h, PasswordSalt=@s WHERE UserId=@id",
            Db.Binary("@h", hash), Db.Binary("@s", salt), Db.P("@id", id));

    public static void TouchLogin(int id) =>
        Db.Execute("UPDATE dbo.[User] SET LastLogin = SYSDATETIME() WHERE UserId=@id", Db.P("@id", id));

    public static int ActiveManagersExcept(int id) =>
        Db.Int("SELECT COUNT(*) FROM dbo.[User] WHERE Role=N'Manager' AND IsActive=1 AND UserId<>@id", Db.P("@id", id));
}
