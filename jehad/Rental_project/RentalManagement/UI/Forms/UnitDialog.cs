using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

public partial class UnitDialog : DialogBase
{
    private readonly int? _id;

    public UnitDialog(int? id, int? propertyId = null)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة وحدة" : "تعديل بيانات وحدة");
        Ui.BindCombo(cmbProperty, PropertyDal.PropertyList(), "— اختر —");
        cmbType.Items.AddRange(Labels.UnitTypes);
        cmbType.SelectedIndex = 0;
        if (propertyId is not null) cmbProperty.SelectedValue = propertyId;
        numFloor.Value = 0;      // القيمة الافتراضية للوحدة الجديدة: الطابق الأرضي
        if (id is null) return;

        var r = PropertyDal.Unit(id.Value)!;
        cmbProperty.SelectedValue = r["PropertyId"];
        txtUnitNo.Text = (string)r["UnitNo"];
        if (!cmbType.Items.Contains(r["UnitType"])) cmbType.Items.Add(r["UnitType"]);
        cmbType.SelectedItem = r["UnitType"];
        numFloor.Value = r["FloorNo"] is int f ? f : 0;
        numArea.Value = r["Area"] is decimal a ? a : 0;
        numRooms.Value = r["Rooms"] is int n ? n : 0;
        numRent.Value = (decimal)r["MonthlyRent"];
        txtNotes.Text = r["Notes"] as string;
        string status = (string)r["Status"];
        chkMaintenance.Checked = status == "Maintenance";
        if (status == "Rented")
        {
            chkMaintenance.Enabled = false;
            lblStatusInfo.Text = "الوحدة مؤجرة حالياً: لا يمكن تحويلها إلى الصيانة أو نقلها لعقار آخر قبل إنهاء عقدها.";
            lblStatusInfo.ForeColor = Theme.Info;
        }
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        MasterDataService.SaveUnit(_id, Ui.SelectedId(cmbProperty), txtUnitNo.Text, cmbType.SelectedItem as string,
            (int)numFloor.Value, numArea.Value, numRooms.Value > 0 ? (int)numRooms.Value : null, numRent.Value,
            chkMaintenance.Checked, txtNotes.Text);
        return true;
    });
}
