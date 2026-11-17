using RentalManagement.DAL;

namespace RentalManagement.BLL;

/// <summary>الدفعات وإيصالات القبض.</summary>
public static class PaymentService
{
    /// <summary>تسجيل دفعة على قسط (FR-18..21). يرجع رقم الدفعة لطباعة الإيصال.</summary>
    public static int Record(int? installmentId, decimal amount, decimal remaining, DateTime date, string? method,
                             string? referenceNo, string? notes)
    {
        Session.Demand(Session.CanOperate);
        if (installmentId is null) throw new AppException("الرجاء اختيار القسط.");
        if (amount <= 0) throw new AppException("الرجاء إدخال مبلغ الدفعة.");
        if (amount > remaining) throw new AppException($"المبلغ أكبر من المتبقي على القسط ({Ui.Money(remaining)}).");
        if (date.Date > DateTime.Today) throw new AppException("تاريخ الدفعة لا يمكن أن يكون في المستقبل.");
        if (string.IsNullOrEmpty(method)) throw new AppException("الرجاء اختيار طريقة الدفع.");
        if (method != "Cash" && string.IsNullOrWhiteSpace(referenceNo))
            throw new AppException("الرجاء إدخال رقم الصك أو الحوالة.");
        return PaymentDal.Record(installmentId.Value, amount, date, method,
            string.IsNullOrWhiteSpace(referenceNo) ? null : referenceNo.Trim(),
            string.IsNullOrWhiteSpace(notes) ? null : notes.Trim());
    }

    /// <summary>إلغاء إيصال خاطئ (المدير فقط). الإيصال لا يُحذف بل يُعلَّم ملغى ويعود المبلغ إلى رصيد القسط.</summary>
    public static void Cancel(int paymentId, string reason)
    {
        Session.Demand(Session.IsManager);
        if (string.IsNullOrWhiteSpace(reason)) throw new AppException("الرجاء كتابة سبب إلغاء الإيصال.");
        PaymentDal.Cancel(paymentId, reason.Trim());
    }
}
