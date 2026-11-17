using RentalManagement.DAL;

namespace RentalManagement.Forms;

/// <summary>تفاصيل العقد: جدول الأقساط مع المدفوع والمتبقي وأيام التأخير، وتسجيل دفعة مباشرة.</summary>
public partial class ContractDetailsDialog : DialogBase
{
    private readonly int _id;
    private int _tenantId;
    private bool _changed;

    public ContractDetailsDialog(int contractId)
    {
        InitializeComponent();
        _id = contractId;
        Ui.StyleGrid(grid);
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex < 0 || grid.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;
            string status = (string)r["Status"];
            bool late = status != "Paid" && (DateTime)r["DueDateRaw"] < DateTime.Today;
            e.CellStyle!.ForeColor = status == "Paid" ? Theme.Success : late ? Theme.Danger : status == "Partial" ? Theme.Info : Theme.Text;
        };
        grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) btnPay.PerformClick(); };
        FormClosing += (_, _) => { if (_changed) DialogResult = DialogResult.OK; };   // لتحديث الصفحة بعد الدفع
        LoadData();
    }

    private void LoadData()
    {
        var c = ContractDal.Get(_id) ?? throw new AppException("العقد غير موجود.");
        _tenantId = (int)c["TenantId"];
        SetTitle(lblHeader, $"أقساط العقد {c["ContractNo"]}");
        lblInfo.Text = $"{c["TenantName"]}   —   {c["PropertyName"]} / {c["UnitType"]} {c["UnitNo"]}   —   " +
                       $"من {Ui.Format(c["StartDate"])} إلى {Ui.Format(c["EndDate"])}   —   {Labels.Of(Labels.ContractStatuses, (string)c["Status"])}";
        lblTotals.Text = $"قيمة العقد: {Ui.Money((decimal)c["TotalAmount"])}     |     المدفوع: {Ui.Money((decimal)c["TotalPaid"])}" +
                         $"     |     المتبقي: {Ui.Money((decimal)c["Balance"])}     |     المتأخر: {Ui.Money((decimal)c["OverdueAmount"])}";
        lblTotals.ForeColor = (decimal)c["OverdueAmount"] > 0 ? Theme.Danger : Theme.Text;
        Ui.BindGrid(grid, ContractDal.Installments(_id));
        btnPay.Enabled = (decimal)c["Balance"] > 0;
    }

    private void btnPay_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        int? inst = Ui.CurrentRow(grid) is { } r && (string)r["Status"] != "Paid" ? (int)r["Id"] : null;
        using var d = new PaymentDialog(_id, inst);
        if (d.ShowDialog(this) != DialogResult.OK) return;
        _changed = true;
        LoadData();
    });

    private void btnStatement_Click(object? sender, EventArgs e) =>
        Ui.Try(() => ReportPrinter.Preview(ReportCatalog.TenantStatement(_tenantId), this));

    private void btnPrintContract_Click(object? sender, EventArgs e) =>
        Ui.Try(() => ReportPrinter.Preview(ReportCatalog.ContractDocument(_id), this));

    private void btnPrintSchedule_Click(object? sender, EventArgs e) => Ui.Try(() =>
        ReportPrinter.Preview(new ReportResult(lblHeader.Text, new[] { new ReportSection(lblTotals.Text, (DataTable)grid.DataSource!) },
            lblInfo.Text), this));
}
