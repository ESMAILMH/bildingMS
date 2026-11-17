using RentalManagement.DAL;

namespace RentalManagement.Reports;

/// <summary>المرشحات التي يحتاجها كل تقرير.</summary>
[Flags]
public enum ReportFilter
{
    None = 0, Property = 1, UnitStatus = 2, ContractStatus = 4, Tenant = 8, Contract = 16,
    Payment = 32, DateRange = 64, Days = 128, User = 256
}

public sealed class ReportFilterValues
{
    public int? PropertyId { get; init; }
    public string? UnitStatus { get; init; }
    public string? ContractStatus { get; init; }
    public int? TenantId { get; init; }
    public int? ContractId { get; init; }
    public int? PaymentId { get; init; }
    public int? UserId { get; init; }
    public DateTime From { get; init; }
    public DateTime To { get; init; }
    public int Days { get; init; } = 30;
    /// <summary>وصف المرشحات المختارة لطباعته تحت عنوان التقرير.</summary>
    public string? Description { get; init; }
}

public sealed class ReportDefinition(string title, ReportFilter filters, ReportFilter required,
                                     Func<ReportFilterValues, ReportResult> build, bool managerOnly = false)
{
    public string Title { get; } = title;
    /// <summary>المجموعة التي يظهر تحتها التقرير في قائمة التقارير.</summary>
    public string Group { get; init; } = "";
    public ReportFilter Filters { get; } = filters;
    public ReportFilter Required { get; } = required;
    public Func<ReportFilterValues, ReportResult> Build { get; } = build;
    public bool ManagerOnly { get; } = managerOnly;
    public override string ToString() => Title;
}

/// <summary>تقارير النظام (FR-26) ونماذج العقد وإيصال القبض وكشف الحساب.</summary>
public static class ReportCatalog
{
    private static readonly string[] OfficeSign = { "الموظف المختص", "المدير" };

    public static readonly ReportDefinition[] All =
    {
        // ---- عامة
        new("التقرير الإحصائي العام", ReportFilter.None, ReportFilter.None, GeneralStatistics) { Group = "عامة" },

        new("العقارات والوحدات وحالتها", ReportFilter.Property | ReportFilter.UnitStatus, ReportFilter.None,
            f => Simple("العقارات والوحدات", Drop(PropertyDal.Units(f.PropertyId, f.UnitStatus, null), "ملاحظات"), f)) { Group = "عامة" },

        new("الوحدات الشاغرة", ReportFilter.Property, ReportFilter.None,
            f => Simple("الوحدات الشاغرة", Drop(PropertyDal.Units(f.PropertyId, "Vacant", null),
                "الحالة", "المستأجر الحالي", "ينتهي العقد في", "ملاحظات"), f)) { Group = "عامة" },

        new("ملخص التحصيل حسب العقار", ReportFilter.DateRange, ReportFilter.None,
            f => Simple("ملخص التحصيل حسب العقار", WithTotal(ReportDal.CollectionByProperty(f.From, f.To)), f)) { Group = "عامة" },

        // ---- العقود
        new("سجل العقود", ReportFilter.ContractStatus | ReportFilter.Property, ReportFilter.None,
            f => Simple("سجل العقود", Drop(ContractDal.Search(f.ContractStatus, null, f.PropertyId), "الهاتف", "أيام متبقية"), f,
                "قيمة العقد", "المدفوع", "المتبقي")) { Group = "العقود" },

        new("العقود التي تنتهي قريباً", ReportFilter.Days | ReportFilter.Property, ReportFilter.None,
            f => Simple("العقود التي تنتهي قريباً", Drop(ContractDal.Expiring(f.Days, f.PropertyId), "الحالة", "قيمة العقد"), f)) { Group = "العقود" },

        new("نموذج عقد إيجار", ReportFilter.Contract, ReportFilter.Contract, f => ContractDocument(f.ContractId!.Value)) { Group = "العقود" },

        // ---- المالية
        new("الأقساط المتأخرة", ReportFilter.Property, ReportFilter.None,
            f => Simple("الأقساط المتأخرة", PaymentDal.Overdue(f.PropertyId), f, "المتبقي")) { Group = "المالية" },

        new("كشف حساب مستأجر", ReportFilter.Tenant, ReportFilter.Tenant, f => TenantStatement(f.TenantId!.Value)) { Group = "المالية" },

        new("الإيرادات المحصلة خلال فترة", ReportFilter.DateRange | ReportFilter.Property, ReportFilter.None,
            f => Simple("الإيرادات المحصلة", Drop(PaymentDal.Search(null, f.From, f.To, false, f.PropertyId), "الحالة", "ملاحظات"), f,
                "المبلغ")) { Group = "المالية" },

        new("إيصال قبض", ReportFilter.Payment, ReportFilter.Payment, f => Receipt(f.PaymentId!.Value)) { Group = "المالية" },

        // ---- الرقابة
        new("سجل العمليات", ReportFilter.User | ReportFilter.DateRange, ReportFilter.None,
            f => Simple("سجل العمليات", AuditDal.Search(f.UserId, f.From, f.To), f, signatures: false), managerOnly: true) { Group = "الرقابة" },
    };

    // ------------------------------------------------------------ مساعدات
    private static ReportResult Simple(string title, DataTable t, ReportFilterValues f, params string[] totals) =>
        Simple(title, t, f, true, totals);

    private static ReportResult Simple(string title, DataTable t, ReportFilterValues f, bool signatures, params string[] totals)
    {
        string sectionTitle = string.Join("   —   ", totals.Where(t.Columns.Contains).Select(c =>
            $"إجمالي {c}: {Ui.Money(t.AsEnumerable().Sum(r => r[c] is decimal d ? d : 0))}"));
        return new ReportResult(title, new[] { new ReportSection(sectionTitle, t) }, f.Description,
            signatures ? OfficeSign : Array.Empty<string>());
    }

    private static DataTable Drop(DataTable t, params string[] columns)
    {
        foreach (var c in columns) if (t.Columns.Contains(c)) t.Columns.Remove(c);
        return t;
    }

    /// <summary>يضيف سطر "الإجمالي" يجمع الأعمدة الرقمية (العمود الأول نص).</summary>
    private static DataTable WithTotal(DataTable t)
    {
        if (t.Rows.Count == 0) return t;
        var total = t.NewRow();
        total[0] = "الإجمالي";
        foreach (DataColumn c in t.Columns)
        {
            if (c.Ordinal == 0) continue;
            if (c.DataType == typeof(decimal)) total[c] = t.AsEnumerable().Sum(r => r[c] is decimal d ? d : 0);
            else if (c.DataType == typeof(int)) total[c] = t.AsEnumerable().Sum(r => r[c] is int i ? i : 0);
        }
        t.Rows.Add(total);
        return t;
    }

    public static DataTable KeyValue(params (string Key, string Value)[] items)
    {
        var t = new DataTable();
        t.Columns.Add("البيان");
        t.Columns.Add("القيمة");
        foreach (var (k, v) in items) t.Rows.Add(k, v);
        return t;
    }

    private static string Cycle(int months) => Labels.Of(Labels.PaymentCycles, months.ToString());

    // ------------------------------------------------------------ التقارير
    /// <summary>التقرير الإحصائي العام: صورة سريعة عن العقارات والعقود والتحصيل.</summary>
    private static ReportResult GeneralStatistics(ReportFilterValues f)
    {
        var s = ReportDal.Stats(AppSettings.ContractAlertDays);
        string N(string col) => Convert.ToInt32(s[col]).ToString("N0");
        string M(string col) => Ui.Money((decimal)s[col]);
        int units = Convert.ToInt32(s["Units"]);
        string occupancy = units == 0 ? "0%" : $"{Convert.ToInt32(s["Rented"]) * 100 / units}%";
        return new ReportResult("التقرير الإحصائي العام", new[]
        {
            new ReportSection("العقارات والوحدات", KeyValue(
                ("العقارات الفعّالة", N("Properties")), ("كل الوحدات", N("Units")), ("وحدات مؤجرة", N("Rented")),
                ("وحدات شاغرة", N("Vacant")), ("وحدات تحت الصيانة", N("Maintenance")), ("نسبة الإشغال", occupancy)), false),
            new ReportSection("المستأجرون والعقود", KeyValue(
                ("المستأجرون الفعّالون", N("Tenants")), ("العقود النشطة", N("ActiveContracts")),
                ($"عقود تنتهي خلال {AppSettings.ContractAlertDays} يوماً", N("Expiring")),
                ("عقود انتهت مدتها ولم تُغلق", N("ExpiredOpen"))), false),
            new ReportSection("التحصيل", KeyValue(
                ("الدخل الشهري المتوقع من العقود النشطة", M("MonthlyIncome")),
                ("المحصّل هذا الشهر", M("CollectedMonth")), ($"المحصّل في سنة {DateTime.Today.Year}", M("CollectedYear")),
                ("أقساط متأخرة (عدد)", N("OverdueCount")), ("قيمة المتأخرات", M("OverdueAmount")),
                ("مستأجرون متأخرون عن السداد", N("LateTenants"))), false),
        }, $"حتى تاريخ {DateTime.Today:yyyy/MM/dd}", OfficeSign);
    }

    /// <summary>كشف حساب مستأجر: بياناته، الحركات (مدين/دائن) مع الرصيد، والمتأخرات (FR-26).</summary>
    public static ReportResult TenantStatement(int tenantId)
    {
        var t = TenantDal.Tenant(tenantId) ?? throw new AppException("المستأجر غير موجود.");
        var moves = ReportDal.TenantStatement(tenantId, null);
        decimal debit = moves.AsEnumerable().Sum(r => (decimal)r[3]), credit = moves.AsEnumerable().Sum(r => (decimal)r[4]);
        var info = KeyValue(("الاسم", (string)t["FullName"]), ("الرقم الوطني / السجل", (string)t["NationalId"]),
                            ("الهاتف", (string)t["Phone"]), ("العنوان", Ui.Format(t["Address"])));
        var summary = KeyValue(("إجمالي المستحق حتى اليوم", Ui.Money(debit)), ("إجمالي المدفوع", Ui.Money(credit)),
                               ("الرصيد المتبقي عليه", Ui.Money(debit - credit)));
        var contracts = Drop(ContractDal.Search(null, null, tenantId: tenantId), "المستأجر", "الهاتف", "أيام متبقية");
        return new ReportResult("كشف حساب مستأجر", new[]
        {
            new ReportSection("", info, false),
            new ReportSection("العقود", contracts),
            new ReportSection("الحركات (الأقساط المستحقة والدفعات)", moves),
            new ReportSection("الخلاصة", summary, false),
        }, $"حتى تاريخ {DateTime.Today:yyyy/MM/dd}", new[] { "المستأجر", "الموظف المختص" });
    }

    /// <summary>نموذج عقد إيجار للطباعة والتوقيع (FR-17): البيانات، جدول الأقساط، والبنود.</summary>
    public static ReportResult ContractDocument(int contractId)
    {
        var c = ContractDal.Get(contractId) ?? throw new AppException("العقد غير موجود.");
        var start = (DateTime)c["StartDate"];
        var end = (DateTime)c["EndDate"];
        var info = KeyValue(
            ("رقم العقد", (string)c["ContractNo"]),
            ("الطرف الأول (المؤجر)", AppSettings.OfficeName),
            ("الطرف الثاني (المستأجر)", (string)c["TenantName"]),
            ("الرقم الوطني / السجل", (string)c["NationalId"]),
            ("هاتف المستأجر", (string)c["TenantPhone"]),
            ("العين المؤجرة", $"{c["UnitType"]} رقم {c["UnitNo"]} — {c["PropertyName"]}"),
            ("مدة العقد", $"من {Ui.Format(start)} إلى {Ui.Format(end)}"),
            ("الإيجار الشهري", Ui.Money((decimal)c["MonthlyRent"])),
            ("دورية الدفع", Cycle((int)c["PaymentCycle"])),
            ("مبلغ التأمين", Ui.Money((decimal)c["Deposit"])),
            ("إجمالي قيمة العقد", Ui.Money((decimal)c["TotalAmount"])),
            ("حالة العقد", Labels.Of(Labels.ContractStatuses, (string)c["Status"])));
        var schedule = Drop(ContractDal.Installments(contractId), "الحالة", "أيام التأخير");
        var terms = KeyValue(
            ("البند الأول", "يلتزم المستأجر بسداد الأقساط في مواعيد استحقاقها المبيّنة في جدول الأقساط."),
            ("البند الثاني", "يستخدم المستأجر العين المؤجرة في الغرض المتفق عليه، ولا يحق له التأجير من الباطن إلا بموافقة كتابية."),
            ("البند الثالث", "يحافظ المستأجر على العين المؤجرة ويعيدها بالحالة التي استلمها بها عند انتهاء العقد."),
            ("البند الرابع", "يُسترد مبلغ التأمين عند انتهاء العقد بعد خصم أي مستحقات أو تلفيات."),
            ("البند الخامس", "يجوز تجديد العقد باتفاق الطرفين قبل انتهاء مدته، ويُحرّر عقد جديد بالشروط المتفق عليها."));
        return new ReportResult("عقد إيجار", new[]
        {
            new ReportSection("بيانات العقد", info, false),
            new ReportSection("جدول الأقساط", schedule),
            new ReportSection("البنود", terms, false),
        }, $"حُرّر بتاريخ {DateTime.Today:yyyy/MM/dd}", new[] { "الطرف الأول (المؤجر)", "الطرف الثاني (المستأجر)" });
    }

    /// <summary>إيصال قبض لدفعة (FR-20): المبلغ رقماً وكتابةً.</summary>
    public static ReportResult Receipt(int paymentId)
    {
        var p = PaymentDal.Get(paymentId) ?? throw new AppException("الإيصال غير موجود.");
        decimal amount = (decimal)p["Amount"];
        decimal remaining = (decimal)p["InstallmentAmount"] - (decimal)p["InstallmentPaid"];
        string method = Labels.Of(Labels.PaymentMethods, (string)p["Method"])
                        + (p["ReferenceNo"] is string r ? $" — رقم {r}" : "");
        var rows = new List<(string, string)>
        {
            ("رقم الإيصال", (string)p["ReceiptNo"]),
            ("التاريخ", Ui.Format(p["PaymentDate"])),
            ("استلمنا من السيد/ة", (string)p["TenantName"]),
            ("مبلغاً وقدره", Ui.Money(amount)),
            ("المبلغ كتابةً", ArabicNumber.Money(amount)),
            ("وذلك عن", $"القسط رقم {p["InstallmentNo"]} المستحق في {Ui.Format(p["DueDate"])} — عقد {p["ContractNo"]}"),
            ("العين المؤجرة", $"{p["UnitType"]} رقم {p["UnitNo"]} — {p["PropertyName"]}"),
            ("طريقة الدفع", method),
            ("المتبقي على القسط حالياً", Ui.Money(remaining)),
            ("المستلم", (string)p["ReceivedByName"]),
        };
        if (p["Notes"] is string n) rows.Add(("ملاحظات", n));
        bool cancelled = (bool)p["IsCancelled"];
        if (cancelled) rows.Add(("سبب الإلغاء", Ui.Format(p["CancelReason"])));
        return new ReportResult("إيصال قبض", new[] { new ReportSection("", KeyValue(rows.ToArray()), false) },
            cancelled ? "⚠ هذا الإيصال ملغى" : null, new[] { "المستلم", "المستأجر" });
    }
}
