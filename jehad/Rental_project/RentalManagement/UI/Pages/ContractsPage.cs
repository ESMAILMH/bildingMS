using RentalManagement.DAL;
using RentalManagement.Forms;

namespace RentalManagement.Pages;

/// <summary>
/// عقود الإيجار (FR-12..17): إبرام، عرض الأقساط، تسجيل دفعة، طباعة نموذج العقد، تجديد، إنهاء، وفسخ (للمدير).
/// </summary>
public partial class ContractsPage : PageBase
{
    public ContractsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "رقم العقد، المستأجر، الهاتف، العقار، الوحدة...";
        cmbProperty.SelectedIndexChanged += Filter_Changed;
        btnTerminate.Visible = Session.IsManager;
        InitChips("Active", btnChipActive, btnChipEnded, btnChipTerminated, btnChipAll);
        InitRowActions(btnDetails, btnDetails, btnPay, btnPrintContract, btnRenew, btnEnd, btnTerminate);
        Ui.ColorBy(grid, "Status", "الحالة", Ui.ContractStatusColor);
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex < 0 || grid.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;
            string col = grid.Columns[e.ColumnIndex].DataPropertyName;
            if (col == "المتأخر" && r[col] is decimal d && d > 0) { e.CellStyle!.ForeColor = Theme.Danger; e.CellStyle.Font = Theme.Bold; }
            if (col == "أيام متبقية" && r[col] is int days && days <= AppSettings.ContractAlertDays)
            {
                e.CellStyle!.ForeColor = days < 0 ? Theme.Danger : Theme.Warning;
                e.CellStyle.Font = Theme.Bold;
            }
        };
    }

    public override void RefreshData()
    {
        bool ready = Ready;
        Ready = false;
        Rebind(cmbProperty, () => Ui.BindCombo(cmbProperty, PropertyDal.PropertyList(), "— كل العقارات —"));
        Ready = ready;

        var counts = ContractDal.CountByStatus();
        ChipText(btnChipActive, "نشطة", counts.GetValueOrDefault("Active"));
        ChipText(btnChipEnded, "منتهية", counts.GetValueOrDefault("Ended"));
        ChipText(btnChipTerminated, "مفسوخة", counts.GetValueOrDefault("Terminated"));
        ChipText(btnChipAll, "الكل", counts.Values.Sum());
        Bind(ContractDal.Search(Chip, Ui.NullIfEmpty(txtSearch.Text), Ui.SelectedId(cmbProperty)));
    }

    /// <summary>العمليات على العقد النشط فقط، والدفع لأي عقد عليه متبقٍّ.</summary>
    protected override void OnRowSelected(DataRowView? row)
    {
        bool active = row != null && (string)row["Status"] == "Active";
        btnRenew.Enabled = btnEnd.Enabled = btnTerminate.Enabled = active;
        btnPay.Enabled = row != null && (decimal)row["المتبقي"] > 0;
    }

    private int? SelectedId => RequireSelection() is { } r ? (int)r["Id"] : null;

    private void btnNew_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new ContractDialog()));
    private void btnDetails_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (SelectedId is { } id) OpenDialog(new ContractDetailsDialog(id)); });
    private void btnPay_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (SelectedId is { } id) OpenDialog(new PaymentDialog(id)); });
    private void btnPrintContract_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (SelectedId is { } id) ReportPrinter.Preview(ReportCatalog.ContractDocument(id), FindForm()); });
    private void btnRenew_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (SelectedId is { } id) OpenDialog(new RenewContractDialog(id)); });
    private void btnEnd_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (SelectedId is { } id) OpenDialog(new CloseContractDialog(id, terminate: false)); });
    private void btnTerminate_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (SelectedId is { } id) OpenDialog(new CloseContractDialog(id, terminate: true)); });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("عقود الإيجار"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("عقود الإيجار"));
}
