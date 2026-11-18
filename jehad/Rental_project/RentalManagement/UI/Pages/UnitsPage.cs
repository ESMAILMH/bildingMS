using RentalManagement.DAL;
using RentalManagement.Forms;

namespace RentalManagement.Pages;

/// <summary>الوحدات (FR-06, FR-07): حسب العقار والحالة (شاغرة، مؤجرة، تحت الصيانة).</summary>
public partial class UnitsPage : PageBase
{
    public UnitsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "رقم الوحدة، العقار، المستأجر...";
        cmbProperty.SelectedIndexChanged += Filter_Changed;
        InitChips(null, btnChipAll, btnChipVacant, btnChipRented, btnChipMaintenance);
        InitRowActions(btnEdit, btnEdit, btnContract, btnPhotos);
        Ui.ColorBy(grid, "Status", "الحالة", Ui.UnitStatusColor);
    }

    public override void RefreshData()
    {
        bool ready = Ready;
        Ready = false;
        Rebind(cmbProperty, () => Ui.BindCombo(cmbProperty, PropertyDal.PropertyList(), "— كل العقارات —"));
        Ready = ready;

        int? property = Ui.SelectedId(cmbProperty);
        var counts = PropertyDal.CountByStatus(property);
        ChipText(btnChipAll, "الكل", counts.Values.Sum());
        ChipText(btnChipVacant, "شاغرة", counts.GetValueOrDefault("Vacant"));
        ChipText(btnChipRented, "مؤجرة", counts.GetValueOrDefault("Rented"));
        ChipText(btnChipMaintenance, "تحت الصيانة", counts.GetValueOrDefault("Maintenance"));
        Bind(PropertyDal.Units(property, Chip, Ui.NullIfEmpty(txtSearch.Text)));
    }

    /// <summary>إبرام عقد للوحدة الشاغرة فقط.</summary>
    protected override void OnRowSelected(DataRowView? row) =>
        btnContract.Enabled = row != null && (string)row["Status"] == "Vacant";

    private void btnAdd_Click(object? sender, EventArgs e) =>
        Ui.Try(() => OpenDialog(new UnitDialog(null, Ui.SelectedId(cmbProperty))));
    private void btnEdit_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new UnitDialog((int)r["Id"])); });
    private void btnContract_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new ContractDialog((int)r["Id"])); });

    private void btnPhotos_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is { } r) OpenDialog(new PhotosDialog(null, (int)r["Id"], $"{r["العقار"]} / وحدة {r["رقم الوحدة"]}"));
    });

    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => PrintGrid("الوحدات", cmbProperty.SelectedIndex > 0 ? "العقار: " + cmbProperty.Text : null));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("الوحدات"));
}
