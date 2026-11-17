namespace RentalManagement.Common;

/// <summary>عنصر قائمة منسدلة: قيمة مخزنة في القاعدة + نص عربي.</summary>
public sealed record ListItem(string Value, string Text)
{
    public override string ToString() => Text;
}

/// <summary>النصوص العربية للقيم المخزنة في قاعدة البيانات.</summary>
public static class Labels
{
    public static readonly ListItem[] Roles =
    {
        new("Manager", "مدير"),
        new("Employee", "موظف"),
    };

    public static readonly ListItem[] UnitStatuses =
    {
        new("Vacant", "شاغرة"),
        new("Rented", "مؤجرة"),
        new("Maintenance", "تحت الصيانة"),
    };

    public static readonly ListItem[] ContractStatuses =
    {
        new("Active", "نشط"),
        new("Ended", "منتهٍ"),
        new("Terminated", "مفسوخ"),
    };

    public static readonly ListItem[] PaymentMethods =
    {
        new("Cash", "نقداً"),
        new("Transfer", "تحويل مصرفي"),
        new("Cheque", "صك"),
    };

    /// <summary>دورية الدفع: عدد الأشهر التي يغطيها كل قسط.</summary>
    public static readonly ListItem[] PaymentCycles =
    {
        new("1", "شهري"),
        new("3", "ربع سنوي (كل 3 أشهر)"),
        new("6", "نصف سنوي (كل 6 أشهر)"),
        new("12", "سنوي"),
    };

    public static readonly string[] PropertyTypes = { "عمارة سكنية", "عمارة تجارية", "مجمع تجاري", "فيلا", "منزل", "أخرى" };

    public static readonly string[] UnitTypes = { "شقة", "محل", "مكتب", "مخزن", "فيلا", "أخرى" };

    public static string Of(IEnumerable<ListItem> items, string? value) =>
        items.FirstOrDefault(i => i.Value == value)?.Text ?? value ?? "";

    public static ListItem[] WithAll(IEnumerable<ListItem> items) =>
        new[] { new ListItem("", "— الكل —") }.Concat(items).ToArray();

    // تعبيرات SQL لعرض القيم بالعربي داخل الاستعلامات
    public const string SqlUnitStatus =
        "CASE {0} WHEN N'Vacant' THEN N'شاغرة' WHEN N'Rented' THEN N'مؤجرة' ELSE N'تحت الصيانة' END";

    public const string SqlContractStatus =
        "CASE {0} WHEN N'Active' THEN N'نشط' WHEN N'Ended' THEN N'منتهٍ' ELSE N'مفسوخ' END";

    public const string SqlInstallmentStatus =
        "CASE {0} WHEN N'Paid' THEN N'مسدد' WHEN N'Partial' THEN N'مسدد جزئياً' ELSE N'غير مسدد' END";

    public const string SqlPaymentMethod =
        "CASE {0} WHEN N'Cash' THEN N'نقداً' WHEN N'Transfer' THEN N'تحويل مصرفي' ELSE N'صك' END";

    public const string SqlPaymentCycle =
        "CASE {0} WHEN 1 THEN N'شهري' WHEN 3 THEN N'ربع سنوي' WHEN 6 THEN N'نصف سنوي' ELSE N'سنوي' END";

    public const string SqlRole =
        "CASE {0} WHEN N'Manager' THEN N'مدير' ELSE N'موظف' END";

    public static string Sql(string template, string column) => string.Format(template, column);
}
