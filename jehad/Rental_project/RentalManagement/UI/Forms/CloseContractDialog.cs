using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

/// <summary>إنهاء العقد عند انتهاء مدته، أو فسخه قبل موعده (للمدير).</summary>
public partial class CloseContractDialog : DialogBase
{
    private readonly int _id;
    private readonly bool _terminate;

    public CloseContractDialog(int contractId, bool terminate)
    {
        InitializeComponent();
        _id = contractId;
        _terminate = terminate;
        var c = ContractDal.Get(contractId) ?? throw new AppException("العقد غير موجود.");
        SetTitle(lblHeader, terminate ? "فسخ العقد قبل موعده" : "إنهاء العقد");
        lblContract.Text = $"{c["ContractNo"]} — {c["TenantName"]} — {c["PropertyName"]} / {c["UnitNo"]}";
        lblPeriod.Text = $"من {Ui.Format(c["StartDate"])} إلى {Ui.Format(c["EndDate"])}";
        decimal balance = (decimal)c["Balance"], overdue = (decimal)c["OverdueAmount"];
        lblBalance.Text = $"{Ui.Money(balance)}   (المتأخر منه: {Ui.Money(overdue)})";
        lblBalance.ForeColor = overdue > 0 ? Theme.Danger : Theme.Primary;

        if (terminate)
        {
            dtpDate.Value = DateTime.Today;
            lblNote.Text = "عند الفسخ: تُحذف الأقساط المستقبلية غير المسددة (بعد تاريخ الفسخ)، وتصبح الوحدة شاغرة. الفسخ قبل بداية العقد يلغيه كاملاً. السبب مطلوب.";
            btnSave.Text = "فسخ العقد";
        }
        else
        {
            dtpDate.Value = (DateTime)c["EndDate"];
            dtpDate.Enabled = false;
            lblNote.Text = "يُغلق العقد في تاريخ نهايته وتصبح الوحدة شاغرة. الأقساط غير المسددة تبقى مستحقة على المستأجر.";
            btnSave.Text = "إنهاء العقد";
            btnSave.BackColor = Theme.Primary;
        }
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        if (!Ui.Confirm(_terminate ? "هل تريد فسخ هذا العقد؟ لا يمكن التراجع عن العملية." : "هل تريد إنهاء هذا العقد؟"))
            return false;
        ContractService.Close(_id, _terminate, dtpDate.Value, txtReason.Text);
        Ui.Info(_terminate ? "تم فسخ العقد وأصبحت الوحدة شاغرة." : "تم إنهاء العقد وأصبحت الوحدة شاغرة.");
        return true;
    });
}
