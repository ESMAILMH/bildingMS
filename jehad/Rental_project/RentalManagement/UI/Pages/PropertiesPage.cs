using RentalManagement.DAL;
using RentalManagement.Forms;

namespace RentalManagement.Pages;

/// <summary>العقارات (FR-05): الفعّالة والمعطّلة، مع عدد الوحدات المؤجرة والشاغرة في كل عقار.</summary>
public partial class PropertiesPage : PageBase
{
    public PropertiesPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "اسم العقار، المدينة، العنوان...";
        InitChips("active", btnChipActive, btnChipInactive, btnChipAll);
        InitRowActions(btnEdit, btnEdit, btnUnits, btnPhotos);
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is DataRowView r && !(bool)r["IsActive"])
                e.CellStyle!.ForeColor = Theme.MutedText;
        };
    }

    public override void RefreshData()
    {
        var all = PropertyDal.Properties(Ui.NullIfEmpty(txtSearch.Text));
        var rows = all.AsEnumerable().ToList();
        int active = rows.Count(r => (bool)r["IsActive"]);
        ChipText(btnChipActive, "فعّال", active);
        ChipText(btnChipInactive, "معطّل", rows.Count - active);
        ChipText(btnChipAll, "الكل", rows.Count);
        var shown = rows.Where(r => Chip == null || (bool)r["IsActive"] == (Chip == "active")).ToList();
        Bind(shown.Count > 0 ? shown.CopyToDataTable() : all.Clone());
    }

    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new PropertyDialog(null)));
    private void btnEdit_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new PropertyDialog((int)r["Id"])); });

    /// <summary>وحدات العقار المحدد في نافذة مستقلة.</summary>
    private void btnUnits_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        int id = (int)r["Id"];
        using var d = new GridDialog($"وحدات العقار: {r["العقار"]}", () => PropertyDal.Units(id, null, null));
        d.ShowDialog(FindForm());
    });

    private void btnPhotos_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new PhotosDialog((int)r["Id"], null, (string)r["العقار"])); });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("العقارات"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("العقارات"));
}
