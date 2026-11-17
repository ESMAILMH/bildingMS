using RentalManagement.DAL;
using RentalManagement.Forms;

namespace RentalManagement.Pages;

/// <summary>المستأجرون (FR-09..11): البيانات، العقود النشطة، المتأخرات، وكشف الحساب.</summary>
public partial class TenantsPage : PageBase
{
    public TenantsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الاسم، الرقم الوطني، الهاتف...";
        InitChips("active", btnChipActive, btnChipInactive, btnChipAll);
        InitRowActions(btnEdit, btnEdit, btnStatement);
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex < 0 || grid.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;
            if (!(bool)r["IsActive"]) e.CellStyle!.ForeColor = Theme.MutedText;
            else if (grid.Columns[e.ColumnIndex].DataPropertyName == "متأخرات" && (decimal)r["متأخرات"] > 0)
            {
                e.CellStyle!.ForeColor = Theme.Danger;
                e.CellStyle.Font = Theme.Bold;
            }
        };
    }

    public override void RefreshData()
    {
        var all = TenantDal.Tenants(Ui.NullIfEmpty(txtSearch.Text));
        var rows = all.AsEnumerable().ToList();
        int active = rows.Count(r => (bool)r["IsActive"]);
        ChipText(btnChipActive, "فعّال", active);
        ChipText(btnChipInactive, "معطّل", rows.Count - active);
        ChipText(btnChipAll, "الكل", rows.Count);
        var shown = rows.Where(r => Chip == null || (bool)r["IsActive"] == (Chip == "active")).ToList();
        Bind(shown.Count > 0 ? shown.CopyToDataTable() : all.Clone());
    }

    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new TenantDialog(null)));
    private void btnEdit_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new TenantDialog((int)r["Id"])); });

    private void btnStatement_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is { } r) ReportPrinter.Preview(ReportCatalog.TenantStatement((int)r["Id"]), FindForm());
    });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("المستأجرون"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("المستأجرون"));
}
