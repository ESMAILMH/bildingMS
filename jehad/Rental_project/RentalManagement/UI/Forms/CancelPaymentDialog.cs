using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

/// <summary>إلغاء إيصال قبض خاطئ (للمدير فقط).</summary>
public partial class CancelPaymentDialog : DialogBase
{
    private readonly int _id;

    public CancelPaymentDialog(int paymentId)
    {
        InitializeComponent();
        _id = paymentId;
        var p = PaymentDal.Get(paymentId) ?? throw new AppException("الإيصال غير موجود.");
        if ((bool)p["IsCancelled"]) throw new AppException("هذا الإيصال ملغى مسبقاً.");
        lblReceipt.Text = $"{p["ReceiptNo"]} — {p["TenantName"]} — {Ui.Format(p["PaymentDate"])}";
        lblAmount.Text = Ui.Money((decimal)p["Amount"]);
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        if (!Ui.Confirm("هل تريد إلغاء هذا الإيصال؟")) return false;
        PaymentService.Cancel(_id, txtReason.Text);
        Ui.Info("تم إلغاء الإيصال وإعادة المبلغ إلى رصيد القسط.");
        return true;
    });
}
