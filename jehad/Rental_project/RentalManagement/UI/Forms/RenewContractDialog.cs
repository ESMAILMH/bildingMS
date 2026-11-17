using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

/// <summary>تجديد العقد (FR-16): عقد جديد لنفس الوحدة والمستأجر يبدأ بعد نهاية الحالي مباشرة.</summary>
public partial class RenewContractDialog : DialogBase
{
    private readonly int _id;
    private readonly DateTime _newStart;

    public RenewContractDialog(int contractId)
    {
        InitializeComponent();
        _id = contractId;
        var c = ContractDal.Get(contractId) ?? throw new AppException("العقد غير موجود.");
        if ((string)c["Status"] != "Active") throw new AppException("لا يُجدَّد إلا عقد نشط.");
        _newStart = ((DateTime)c["EndDate"]).AddDays(1);
        lblContract.Text = $"{c["ContractNo"]} — {c["TenantName"]} — {c["PropertyName"]} / {c["UnitNo"]}";
        lblNewStart.Text = Ui.Format(_newStart);
        dtpEnd.Value = _newStart.AddYears(1).AddDays(-1);
        numRent.Value = (decimal)c["MonthlyRent"];
        Ui.BindCombo(cmbCycle, Labels.PaymentCycles);
        cmbCycle.SelectedValue = c["PaymentCycle"].ToString();
        dtpEnd.ValueChanged += (_, _) => UpdatePreview();
        numRent.ValueChanged += (_, _) => UpdatePreview();
        cmbCycle.SelectedIndexChanged += (_, _) => UpdatePreview();
        UpdatePreview();
    }

    private int Cycle => int.TryParse(Ui.SelectedCode(cmbCycle), out int c) ? c : 0;

    private void UpdatePreview()
    {
        var items = ContractService.Schedule(_newStart, dtpEnd.Value, numRent.Value, Cycle);
        lblPreview.Text = items.Count == 0 ? "—" : $"{items.Count} قسط — الإجمالي {Ui.Money(items.Sum(i => i.Amount))}";
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        int newId = ContractService.Renew(_id, dtpEnd.Value, numRent.Value, Cycle);
        Ui.Info($"تم تجديد العقد. رقم العقد الجديد: {ContractDal.Get(newId)?["ContractNo"]}");
        return true;
    });
}
