using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

/// <summary>تسجيل دفعة على قسط (UC-06) ثم طباعة إيصال القبض.</summary>
public partial class PaymentDialog : DialogBase
{
    private bool _loading = true;

    public PaymentDialog(int? contractId = null, int? installmentId = null)
    {
        InitializeComponent();
        Ui.BindCombo(cmbContract, ContractDal.PayableContractList(), "— اختر العقد —");
        Ui.BindCombo(cmbMethod, Labels.PaymentMethods);
        dtpDate.Value = DateTime.Today;
        chkPrint.Checked = true;
        if (contractId is not null) cmbContract.SelectedValue = contractId.Value;
        BindInstallments();
        if (installmentId is not null) cmbInstallment.SelectedValue = installmentId.Value;

        cmbContract.SelectedIndexChanged += (_, _) => { if (!_loading) Ui.Try(BindInstallments); };
        cmbInstallment.SelectedIndexChanged += (_, _) => InstallmentChanged();
        cmbMethod.SelectedIndexChanged += (_, _) => txtReference.Enabled = Ui.SelectedCode(cmbMethod) != "Cash";
        _loading = false;
        InstallmentChanged();
        txtReference.Enabled = false;
    }

    /// <summary>الأقساط غير المسددة للعقد المختار، ويُختار أقدمها تلقائياً.</summary>
    private void BindInstallments()
    {
        var id = Ui.SelectedId(cmbContract);
        var t = id is null ? new DataTable() : ContractDal.OpenInstallmentList(id.Value);
        if (id is null)
        {
            t.Columns.Add("Id", typeof(int));
            t.Columns.Add("Name", typeof(string));
            t.Columns.Add("Remaining", typeof(decimal));
        }
        Ui.BindCombo(cmbInstallment, t);
        InstallmentChanged();
    }

    private decimal Remaining => cmbInstallment.SelectedItem is DataRowView r ? (decimal)r["Remaining"] : 0;

    private void InstallmentChanged()
    {
        if (_loading) return;
        lblRemaining.Text = cmbInstallment.SelectedItem is null ? "—" : Ui.Money(Remaining);
        numAmount.Value = Math.Min(Remaining, numAmount.Maximum);
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        int id = PaymentService.Record(Ui.SelectedId(cmbInstallment), numAmount.Value, Remaining, dtpDate.Value,
            Ui.SelectedCode(cmbMethod), txtReference.Text, txtNotes.Text);
        if (chkPrint.Checked) ReportPrinter.Preview(ReportCatalog.Receipt(id), this);
        else Ui.Info("تم تسجيل الدفعة.");
        return true;
    });
}
