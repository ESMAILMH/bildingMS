namespace RentalManagement.Security;

/// <summary>أدوار المستخدمين كما في قاعدة البيانات (Role).</summary>
public enum UserRole
{
    Manager,   // مدير: كل الصلاحيات + المستخدمون، الإعدادات، فسخ العقود، إلغاء الإيصالات، سجل العمليات
    Employee   // موظف: المشغّل اليومي (العقارات، المستأجرون، العقود، الدفعات، التقارير)
}

public sealed class AppUser
{
    public int UserId { get; init; }
    public string Username { get; init; } = "";
    public string DisplayName { get; init; } = "";
    public UserRole Role { get; init; }
}

/// <summary>المستخدم الحالي وصلاحياته (تُفحص عند كل شاشة وكل عملية).</summary>
public static class Session
{
    public static AppUser? Current { get; set; }

    public static int UserId => Current?.UserId ?? throw new AppException("لا يوجد مستخدم مسجل.");

    public static bool IsManager => Current?.Role == UserRole.Manager;

    /// <summary>أي مستخدم مسجّل (مدير أو موظف) يستطيع العمليات اليومية.</summary>
    public static bool CanOperate => Current != null;

    public static void Demand(bool allowed)
    {
        if (!allowed) throw new AppException("ليست لديك صلاحية لتنفيذ هذه العملية.");
    }
}
