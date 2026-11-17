using RentalManagement.DAL;

namespace RentalManagement.BLL;

/// <summary>قسط في جدول الدفع (للمعاينة قبل الحفظ).</summary>
public sealed record ScheduleItem(int No, DateTime DueDate, int Months, decimal Amount);

/// <summary>عقود الإيجار: الإبرام، معاينة الأقساط، الإنهاء، الفسخ، التجديد.</summary>
public static class ContractService
{
    public static readonly int[] Cycles = { 1, 3, 6, 12 };

    /// <summary>
    /// جدول الأقساط (BR-04) — نفس منطق الإجراء المخزن sp_GenerateInstallments تماماً:
    /// كل قسط يغطي عدد أشهر الدورية ويُحسب تاريخه من تاريخ البداية، والقسط الأخير بالتناسب مع الأشهر المتبقية.
    /// </summary>
    public static List<ScheduleItem> Schedule(DateTime start, DateTime end, decimal monthlyRent, int cycle)
    {
        var list = new List<ScheduleItem>();
        if (end.Date <= start.Date || monthlyRent <= 0 || !Cycles.Contains(cycle)) return list;
        var stop = end.Date.AddDays(1);
        for (int no = 1; ; no++)
        {
            var due = start.Date.AddMonths(cycle * (no - 1));
            if (due >= stop) break;
            int months = (stop.Year - due.Year) * 12 + stop.Month - due.Month;   // مثل DATEDIFF(MONTH) في SQL Server
            months = Math.Max(1, Math.Min(months, cycle));
            list.Add(new ScheduleItem(no, due, months, monthlyRent * months));
        }
        return list;
    }

    private static void Validate(DateTime start, DateTime end, decimal rent, int cycle)
    {
        if (end.Date <= start.Date) throw new AppException("تاريخ نهاية العقد يجب أن يكون بعد تاريخ البداية.");
        if (rent <= 0) throw new AppException("الرجاء إدخال قيمة الإيجار الشهري.");
        if (!Cycles.Contains(cycle)) throw new AppException("الرجاء اختيار دورية الدفع.");
        if ((end - start).TotalDays > 366 * 10) throw new AppException("مدة العقد لا تتجاوز 10 سنوات.");
    }

    /// <summary>إبرام عقد جديد (FR-12..14). يرجع رقم العقد الداخلي.</summary>
    public static int Create(int? unitId, int? tenantId, DateTime start, DateTime end, decimal rent, int cycle, decimal deposit, string? notes)
    {
        Session.Demand(Session.CanOperate);
        if (unitId is null) throw new AppException("الرجاء اختيار الوحدة (الشاغرة).");
        if (tenantId is null) throw new AppException("الرجاء اختيار المستأجر.");
        Validate(start, end, rent, cycle);
        if (deposit < 0) throw new AppException("مبلغ التأمين لا يمكن أن يكون سالباً.");
        return ContractDal.Create(unitId.Value, tenantId.Value, start, end, rent, cycle, deposit,
            string.IsNullOrWhiteSpace(notes) ? null : notes.Trim());
    }

    /// <summary>إنهاء العقد عند انتهاء مدته (أي مستخدم)، أو فسخه قبلها (المدير فقط).</summary>
    public static void Close(int contractId, bool terminate, DateTime closeDate, string? reason)
    {
        if (terminate)
        {
            Session.Demand(Session.IsManager);
            if (string.IsNullOrWhiteSpace(reason)) throw new AppException("الرجاء كتابة سبب الفسخ.");
            if (closeDate.Date > DateTime.Today) throw new AppException("تاريخ الفسخ لا يمكن أن يكون في المستقبل.");
        }
        else Session.Demand(Session.CanOperate);
        ContractDal.Close(contractId, terminate, closeDate, string.IsNullOrWhiteSpace(reason) ? null : reason.Trim());
    }

    /// <summary>تجديد العقد: يُغلق الحالي في تاريخ نهايته ويُنشأ عقد جديد يبدأ في اليوم التالي (FR-16).</summary>
    public static int Renew(int contractId, DateTime newEnd, decimal rent, int cycle)
    {
        Session.Demand(Session.CanOperate);
        var c = ContractDal.Get(contractId) ?? throw new AppException("العقد غير موجود.");
        if ((string)c["Status"] != "Active") throw new AppException("لا يُجدَّد إلا عقد نشط.");
        Validate(((DateTime)c["EndDate"]).AddDays(1), newEnd, rent, cycle);
        return ContractDal.Renew(contractId, newEnd, rent, cycle);
    }
}
