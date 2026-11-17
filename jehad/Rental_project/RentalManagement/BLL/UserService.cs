using RentalManagement.DAL;

namespace RentalManagement.BLL;

/// <summary>الدخول والمستخدمين والصلاحيات.</summary>
public static class UserService
{
    /// <summary>أول تشغيل: لا يوجد أي مستخدم، فيُنشأ حساب المدير من التطبيق.</summary>
    public static bool NeedsFirstRun() => UserDal.Count() == 0;

    public static AppUser? Login(string username, string password)
    {
        var r = UserDal.GetByUsername(username.Trim());
        if (r == null || !(bool)r["IsActive"] ||
            !PasswordHasher.Verify(password, (byte[])r["PasswordHash"], (byte[])r["PasswordSalt"]))
            return null;

        Session.Current = new AppUser
        {
            UserId = (int)r["UserId"],
            Username = (string)r["Username"],
            DisplayName = (string)r["FullName"],
            Role = Enum.Parse<UserRole>((string)r["Role"])
        };
        UserDal.TouchLogin(Session.UserId);
        AuditDal.Log("Login", "User", Session.UserId, null);
        return Session.Current;
    }

    public static void Logout()
    {
        if (Session.Current != null) AuditDal.Log("Logout", "User", Session.UserId, null);
        Session.Current = null;
    }

    public static void CreateFirstManager(string username, string fullName, string password)
    {
        if (!NeedsFirstRun()) throw new AppException("تم إنشاء حساب المدير مسبقاً.");
        if (string.IsNullOrWhiteSpace(username)) throw new AppException("الرجاء إدخال اسم المستخدم.");
        if (string.IsNullOrWhiteSpace(fullName)) throw new AppException("الرجاء إدخال الاسم الكامل.");
        PasswordHasher.Validate(password);
        var (hash, salt) = PasswordHasher.Hash(password);
        UserDal.Insert(username.Trim(), fullName.Trim(), hash, salt, nameof(UserRole.Manager), true);
    }

    public static DataTable GetAll()
    {
        Session.Demand(Session.IsManager);
        return UserDal.GetAll();
    }

    public static void Save(int? id, string username, string fullName, UserRole role, bool active, string? password)
    {
        Session.Demand(Session.IsManager);
        if (string.IsNullOrWhiteSpace(username)) throw new AppException("الرجاء إدخال اسم المستخدم.");
        if (string.IsNullOrWhiteSpace(fullName)) throw new AppException("الرجاء إدخال الاسم الكامل.");

        if (id is null)
        {
            PasswordHasher.Validate(password ?? "");
            var (hash, salt) = PasswordHasher.Hash(password!);
            int newId = UserDal.Insert(username.Trim(), fullName.Trim(), hash, salt, role.ToString(), active);
            AuditDal.Log("AddUser", "User", newId, username);
            return;
        }

        if ((role != UserRole.Manager || !active) && UserDal.ActiveManagersExcept(id.Value) == 0)
            throw new AppException("يجب أن يبقى في النظام مدير واحد فعّال على الأقل.");
        if (id == Session.UserId && !active) throw new AppException("لا يمكنك تعطيل حسابك الحالي.");

        UserDal.Update(id.Value, username.Trim(), fullName.Trim(), role.ToString(), active);
        AuditDal.Log("EditUser", "User", id, username);
    }

    public static void ResetPassword(int userId, string password)
    {
        Session.Demand(Session.IsManager);
        PasswordHasher.Validate(password);
        var (hash, salt) = PasswordHasher.Hash(password);
        UserDal.SetPassword(userId, hash, salt);
        AuditDal.Log("ResetPassword", "User", userId, null);
    }

    public static void ChangeOwnPassword(string current, string password)
    {
        var r = UserDal.GetByUsername(Session.Current!.Username)!;
        if (!PasswordHasher.Verify(current, (byte[])r["PasswordHash"], (byte[])r["PasswordSalt"]))
            throw new AppException("كلمة المرور الحالية غير صحيحة.");
        PasswordHasher.Validate(password);
        var (hash, salt) = PasswordHasher.Hash(password);
        UserDal.SetPassword(Session.UserId, hash, salt);
        AuditDal.Log("ChangePassword", "User", Session.UserId, null);
    }
}
