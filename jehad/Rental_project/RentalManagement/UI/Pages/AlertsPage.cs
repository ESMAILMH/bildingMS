using RentalManagement.DAL;
using RentalManagement.Forms;

namespace RentalManagement.Pages;

/// <summary>
/// التنبيهات (FR-22, FR-23): الأقساط المتأخرة (تاريخها مضى ولم تُسدد كاملاً)،
/// والعقود التي تنتهي خلال عدد الأيام المحدد في الإعدادات أو انتهت مدتها ولم تُغلق.
/// </summary>
public partial class AlertsPage : PageBase
{
    private bool Overdue => Chip != "expiring";

    public AlertsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount);
        cmbProperty.SelectedIndexChanged += Filter_Changed;
        InitChips("overdue", btnChipOverdue, btnChipExpiring);
        InitRowActions(btnDetails, btnPay, btnDetails, btnRenew, btnEnd);
        // اللون حسب أعمدة جدول الصف نفسه (لا حسب التبويب): عند تبديل التبويب قد يُرسم صف من الجدول السابق قبل ربط الجديد
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex < 0 || grid.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;
            var cols = r.Row.Table.Columns;
            if (cols.Contains("DaysLateRaw") && r["DaysLateRaw"] is int late)
                e.CellStyle!.ForeColor = late > 30 ? Theme.Danger : Theme.Warning;
            else if (cols.Contains("أيام متبقية") && r["أيام متبقية"] is int days)
                e.CellStyle!.ForeColor = days < 0 ? Theme.Danger : Theme.Warning;
        };
    }

    public override void RefreshData()
    {
        bool ready = Ready;
        Ready = false;
        Rebind(cmbProperty, () => Ui.BindCombo(cmbProperty, PropertyDal.PropertyList(), "— كل العقارات —"));
        Ready = ready;

        int days = AppSettings.ContractAlertDays;
        lblNote.Text = $"⏰ يُنبَّه للعقود التي تنتهي خلال {days} يوماً (يُغيَّر من الإعدادات)، وللعقود التي انتهت مدتها ولم تُغلق بعد.";
        int? property = Ui.SelectedId(cmbProperty);
        var overdue = PaymentDal.Overdue(property);
        var expiring = ContractDal.Expiring(days, property);
        ChipText(btnChipOverdue, "أقساط متأخرة", overdue.Rows.Count);
        ChipText(btnChipExpiring, "عقود تنتهي قريباً", expiring.Rows.Count);
        Bind(Overdue ? overdue : expiring);
        if (Overdue && overdue.Rows.Count > 0)
            lblCount.Text += $"     |     إجمالي المتأخرات: {Ui.Money(overdue.AsEnumerable().Sum(r => (decimal)r["المتبقي"]))}";
    }

    /// <summary>الدفع للمتأخرات، والتجديد والإنهاء للعقود.</summary>
    protected override void OnRowSelected(DataRowView? row)
    {
        btnPay.Visible = Overdue;
        btnRenew.Visible = btnEnd.Visible = !Overdue;
        btnEnd.Enabled = row != null && !Overdue && row.Row.Table.Columns.Contains("أيام متبقية") && row["أيام متبقية"] is int d && d <= 0;
    }

    /// <summary>رقم العقد للصف المحدد: في جدول المتأخرات عمود ContractId، وفي جدول العقود Id.</summary>
    private int? ContractId => RequireSelection() is { } r ? (int)r[r.Row.Table.Columns.Contains("ContractId") ? "ContractId" : "Id"] : null;

    private void btnPay_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is { } r) OpenDialog(new PaymentDialog((int)r["ContractId"], (int)r["Id"]));
    });
    private void btnDetails_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (ContractId is { } id) OpenDialog(new ContractDetailsDialog(id)); });
    private void btnRenew_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (ContractId is { } id) OpenDialog(new RenewContractDialog(id)); });
    private void btnEnd_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (ContractId is { } id) OpenDialog(new CloseContractDialog(id, terminate: false)); });

    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => PrintGrid(Overdue ? "الأقساط المتأخرة" : "العقود التي تنتهي قريباً"));
    private void btnExcel_Click(object? sender, EventArgs e) =>
        Ui.Try(() => ExportGrid(Overdue ? "الأقساط المتأخرة" : "العقود التي تنتهي قريباً"));
}
