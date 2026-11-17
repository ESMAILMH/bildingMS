using RentalManagement.DAL;
using RentalManagement.Forms;

namespace RentalManagement.Pages;

/// <summary>الدفعات وإيصالات القبض (FR-18..21): تسجيل، طباعة الإيصال، وإلغاء الإيصال الخاطئ (للمدير).</summary>
public partial class PaymentsPage : PageBase
{
    public PaymentsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "رقم الإيصال، المستأجر، رقم العقد...";
        dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-2);
        dtpTo.Value = DateTime.Today;
        dtpFrom.ValueChanged += Filter_Changed;
        dtpTo.ValueChanged += Filter_Changed;
        chkCancelled.CheckedChanged += Filter_Changed;
        btnCancelReceipt.Visible = Session.IsManager;
        InitRowActions(btnReceipt, btnReceipt, btnCancelReceipt);
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is DataRowView r && (bool)r["IsCancelled"])
            {
                e.CellStyle!.ForeColor = Theme.Danger;
                e.CellStyle.Font = new Font(Theme.FontName, 10F, FontStyle.Strikeout);
            }
        };
    }

    public override void RefreshData()
    {
        var t = PaymentDal.Search(Ui.NullIfEmpty(txtSearch.Text), dtpFrom.Value, dtpTo.Value, chkCancelled.Checked);
        Bind(t);
        decimal total = t.AsEnumerable().Where(r => !(bool)r["IsCancelled"]).Sum(r => (decimal)r["المبلغ"]);
        lblCount.Text += $"     |     إجمالي المحصّل في الفترة: {Ui.Money(total)}";
    }

    protected override void OnRowSelected(DataRowView? row) =>
        btnCancelReceipt.Enabled = row != null && !(bool)row["IsCancelled"];

    private void btnNew_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new PaymentDialog()));

    private void btnReceipt_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is { } r) ReportPrinter.Preview(ReportCatalog.Receipt((int)r["Id"]), FindForm());
    });

    private void btnCancelReceipt_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new CancelPaymentDialog((int)r["Id"])); });

    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => PrintGrid("الدفعات", $"من {dtpFrom.Value:yyyy/MM/dd} إلى {dtpTo.Value:yyyy/MM/dd}"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("الدفعات"));
}
