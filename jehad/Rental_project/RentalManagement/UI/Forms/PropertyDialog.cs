using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

public partial class PropertyDialog : DialogBase
{
    private readonly int? _id;

    public PropertyDialog(int? id)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة عقار" : "تعديل بيانات عقار");
        cmbType.Items.AddRange(Labels.PropertyTypes);
        chkActive.Checked = true;
        if (id is null)
        {
            cmbType.SelectedIndex = 0;
            return;
        }
        var r = PropertyDal.Property(id.Value)!;
        txtName.Text = (string)r["Name"];
        if (!cmbType.Items.Contains(r["PropertyType"])) cmbType.Items.Add(r["PropertyType"]);
        cmbType.SelectedItem = r["PropertyType"];
        txtCity.Text = (string)r["City"];
        txtAddress.Text = r["Address"] as string;
        txtNotes.Text = r["Notes"] as string;
        chkActive.Checked = (bool)r["IsActive"];
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        MasterDataService.SaveProperty(_id, txtName.Text, cmbType.SelectedItem as string, txtCity.Text, txtAddress.Text,
            txtNotes.Text, chkActive.Checked);
        return true;
    });
}
