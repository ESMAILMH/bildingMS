using RentalManagement.BLL;

namespace RentalManagement.Forms;

/// <summary>إعدادات المكتب (رأس التقارير)، أيام التنبيه، والنسخ الاحتياطي (FR-28..30) — للمدير.</summary>
public partial class SettingsDialog : DialogBase
{
    public SettingsDialog()
    {
        InitializeComponent();
        Session.Demand(Session.IsManager);
        txtOffice.Text = AppSettings.OfficeName;
        txtPhone.Text = AppSettings.OfficePhone;
        txtAddress.Text = AppSettings.OfficeAddress;
        numAlertDays.Value = AppSettings.ContractAlertDays;
        txtBackupFolder.Text = @"C:\Backup";
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        SettingsService.Save(txtOffice.Text, txtPhone.Text, txtAddress.Text, (int)numAlertDays.Value);
        Ui.Info("تم حفظ الإعدادات.");
        return true;
    });

    private void btnBackup_Click(object? sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        try
        {
            string file = SettingsService.Backup(txtBackupFolder.Text.Trim());
            Ui.Info("تم أخذ نسخة احتياطية من قاعدة البيانات:\n" + file);
        }
        catch (Exception ex)
        {
            Ui.ShowError(ex);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }
}
