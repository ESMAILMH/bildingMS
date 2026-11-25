using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

/// <summary>
/// إبرام عقد إيجار (UC-04): اختيار وحدة شاغرة ومستأجر، المدة والإيجار ودورية الدفع،
/// مع معاينة جدول الأقساط قبل الحفظ (نفس حساب الإجراء المخزن).
/// </summary>
public partial class ContractDialog : DialogBase
{
    private static readonly (string Text, int Months)[] Durations =
        { ("6 أشهر", 6), ("سنة", 12), ("سنتان", 24), ("3 سنوات", 36), ("مدة مخصصة", 0) };

    private bool _loading = true;

    public ContractDialog(int? unitId = null)
    {
        InitializeComponent();
        Ui.StyleGrid(gridSchedule);
        Ui.BindCombo(cmbProperty, PropertyDal.PropertyList(), "— كل العقارات —");
        BindUnits();
        BindTenants();
        Ui.BindCombo(cmbCycle, Labels.PaymentCycles);
        foreach (var d in Durations) cmbDuration.Items.Add(d.Text);
        dtpStart.Value = DateTime.Today;
        cmbDuration.SelectedIndex = 1;   // سنة
        SetDefaultCycle();

        if (unitId is not null)
        {
            var u = PropertyDal.Unit(unitId.Value);
            if (u != null)
            {
                cmbProperty.SelectedValue = u["PropertyId"];
                BindUnits();
                cmbUnit.SelectedValue = unitId.Value;
            }
        }

        cmbProperty.SelectedIndexChanged += (_, _) => { if (!_loading) Ui.Try(BindUnits); };
        cmbUnit.SelectedIndexChanged += (_, _) => { if (!_loading) UnitChanged(); };
        cmbDuration.SelectedIndexChanged += (_, _) => ApplyDuration();
        dtpStart.ValueChanged += (_, _) => ApplyDuration();
        dtpEnd.ValueChanged += (_, _) => UpdatePreview();
        numRent.ValueChanged += (_, _) => UpdatePreview();
        cmbCycle.SelectedIndexChanged += (_, _) => UpdatePreview();
        _loading = false;
        UnitChanged();
        ApplyDuration();
    }

    private void SetDefaultCycle() => cmbCycle.SelectedValue = "1";

    private void BindUnits() => Ui.BindCombo(cmbUnit, PropertyDal.VacantUnitList(Ui.SelectedId(cmbProperty)), "— اختر وحدة شاغرة —");

    private void BindTenants() => Ui.BindCombo(cmbTenant, TenantDal.TenantList(), "— اختر المستأجر —");

    /// <summary>الإيجار المقترح للوحدة المختارة.</summary>
    private void UnitChanged()
    {
        if (cmbUnit.SelectedItem is DataRowView r && r["MonthlyRent"] is decimal rent && rent > 0) numRent.Value = rent;
        UpdatePreview();
    }

    private void ApplyDuration()
    {
        if (_loading || cmbDuration.SelectedIndex < 0) return;
        int months = Durations[cmbDuration.SelectedIndex].Months;
        dtpEnd.Enabled = months == 0;
        if (months > 0) dtpEnd.Value = dtpStart.Value.Date.AddMonths(months).AddDays(-1);
        UpdatePreview();
    }

    private int Cycle => int.TryParse(Ui.SelectedCode(cmbCycle), out int c) ? c : 0;

    /// <summary>معاينة جدول الأقساط وإجمالي قيمة العقد.</summary>
    private void UpdatePreview()
    {
        if (_loading) return;
        var items = ContractService.Schedule(dtpStart.Value, dtpEnd.Value, numRent.Value, Cycle);
        var t = new DataTable();
        t.Columns.Add("رقم القسط", typeof(int));
        t.Columns.Add("تاريخ الاستحقاق", typeof(DateTime));
        t.Columns.Add("عدد الأشهر", typeof(int));
        t.Columns.Add("المبلغ", typeof(decimal));
        foreach (var i in items) t.Rows.Add(i.No, i.DueDate, i.Months, i.Amount);
        Ui.BindGrid(gridSchedule, t);
        // الأعمدة الأربعة تملأ عرض الجدول دون شريط تمرير أفقي
        foreach (DataGridViewColumn col in gridSchedule.Columns) { col.MinimumWidth = 60; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
        lblTotal.Text = items.Count == 0
            ? "أدخل المدة والإيجار ودورية الدفع لعرض الأقساط."
            : $"عدد الأقساط: {items.Count}     —     إجمالي قيمة العقد: {Ui.Money(items.Sum(i => i.Amount))}";
    }

    private void btnNewTenant_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        using var d = new TenantDialog(null);
        if (d.ShowDialog(this) != DialogResult.OK) return;
        BindTenants();
        // اختيار المستأجر الذي أُضيف للتو (أكبر رقم)
        var table = (DataTable)cmbTenant.DataSource!;
        int newest = table.AsEnumerable().Select(r => (int)r["Id"]).DefaultIfEmpty(0).Max();
        if (newest > 0) cmbTenant.SelectedValue = newest;
    });

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        int id = ContractService.Create(Ui.SelectedId(cmbUnit), Ui.SelectedId(cmbTenant), dtpStart.Value, dtpEnd.Value,
            numRent.Value, Cycle, numDeposit.Value, txtNotes.Text);
        var c = ContractDal.Get(id);
        if (Ui.Confirm($"تم حفظ العقد رقم {c?["ContractNo"]} وتوليد جدول الأقساط.\nهل تريد طباعة نموذج العقد الآن؟"))
            ReportPrinter.Preview(ReportCatalog.ContractDocument(id), this);
        return true;
    });
}
