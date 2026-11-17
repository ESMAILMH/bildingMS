using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

public partial class TenantDialog : DialogBase
{
    private readonly int? _id;

    public TenantDialog(int? id)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة مستأجر" : "تعديل بيانات مستأجر");
        chkActive.Checked = true;
        if (id is null) return;
        var r = TenantDal.Tenant(id.Value)!;
        txtName.Text = (string)r["FullName"];
        txtNationalId.Text = (string)r["NationalId"];
        txtPhone.Text = (string)r["Phone"];
        txtPhone2.Text = r["Phone2"] as string;
        txtEmail.Text = r["Email"] as string;
        txtAddress.Text = r["Address"] as string;
        txtNotes.Text = r["Notes"] as string;
        chkActive.Checked = (bool)r["IsActive"];
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        MasterDataService.SaveTenant(_id, txtName.Text, txtNationalId.Text, txtPhone.Text, txtPhone2.Text, txtEmail.Text,
            txtAddress.Text, txtNotes.Text, chkActive.Checked);
        return true;
    });
}
