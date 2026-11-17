using RentalManagement.DAL;

namespace RentalManagement.Pages;

/// <summary>التقارير (FR-26, FR-27): اختيار التقرير ← المرشحات ← عرض، طباعة، PDF، Excel.</summary>
public partial class ReportsPage : UserControl, IPage
{
    /// <summary>عناصر كل مرشح (العنوان + الأداة) لإظهارها حسب التقرير المختار.</summary>
    private readonly Dictionary<ReportFilter, Control[]> _filters;
    private bool _loaded;

    public ReportsPage()
    {
        InitializeComponent();
        Ui.StyleGrid(grid);
        _filters = new()
        {
            [ReportFilter.Property] = new Control[] { lblProperty, cmbProperty },
            [ReportFilter.UnitStatus] = new Control[] { lblUnitStatus, cmbUnitStatus },
            [ReportFilter.ContractStatus] = new Control[] { lblContractStatus, cmbContractStatus },
            [ReportFilter.Tenant] = new Control[] { lblTenant, cmbTenant },
            [ReportFilter.Contract] = new Control[] { lblContract, cmbContract },
            [ReportFilter.Payment] = new Control[] { lblPayment, cmbPayment },
            [ReportFilter.User] = new Control[] { lblUser, cmbUser },
            [ReportFilter.DateRange] = new Control[] { lblFrom, dtpFrom, lblTo, dtpTo },
            [ReportFilter.Days] = new Control[] { lblDays, numDays },
        };
        dtpFrom.Value = new DateTime(DateTime.Today.Year, 1, 1);
        dtpTo.Value = DateTime.Today;
        lstReports.DrawItem += DrawReportItem;
        // التقارير مجمّعة: عنوان المجموعة (نص) ثم تقاريرها
        foreach (var group in ReportCatalog.All.Where(r => !r.ManagerOnly || Session.IsManager).GroupBy(r => r.Group))
        {
            lstReports.Items.Add(group.Key);
            foreach (var r in group) lstReports.Items.Add(r);
        }
        numDays.Value = Math.Clamp(AppSettings.ContractAlertDays, 1, 365);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!DesignMode && !_loaded) Ui.Try(RefreshData);
    }

    public void RefreshData()
    {
        _loaded = false;
        Ui.BindCombo(cmbProperty, PropertyDal.PropertyList(), "— الكل —");
        Ui.BindCombo(cmbUnitStatus, Labels.WithAll(Labels.UnitStatuses));
        Ui.BindCombo(cmbContractStatus, Labels.WithAll(Labels.ContractStatuses));
        Ui.BindCombo(cmbTenant, TenantDal.AllTenantList(), "— اختر —");
        Ui.BindCombo(cmbContract, ContractDal.ContractList(activeOnly: false), "— اختر —");
        Ui.BindCombo(cmbPayment, PaymentDal.ReceiptList(), "— اختر —");
        if (Session.IsManager) Ui.BindCombo(cmbUser, ReportLists.Users(), "— الكل —");
        _loaded = true;
        if (lstReports.SelectedIndex < 0 && lstReports.Items.Count > 0) lstReports.SelectedIndex = 0;
        else lstReports_SelectedIndexChanged(null, EventArgs.Empty);
    }

    private ReportDefinition? Current => lstReports.SelectedItem as ReportDefinition;

    /// <summary>إظهار مرشحات التقرير المختار فقط.</summary>
    private void lstReports_SelectedIndexChanged(object? sender, EventArgs e)
    {
        // عنوان المجموعة لا يُختار: ننتقل إلى أول تقرير تحته
        if (lstReports.SelectedItem is string && lstReports.SelectedIndex + 1 < lstReports.Items.Count)
        {
            lstReports.SelectedIndex++;
            return;
        }
        if (Current is not { } def) return;
        foreach (var (flag, controls) in _filters)
            foreach (var c in controls) c.Visible = def.Filters.HasFlag(flag);
        grid.DataSource = null;
        lblPreviewTitle.Text = "";
    }

    private ReportResult Build()
    {
        var def = Current ?? throw new AppException("اختر تقريراً.");
        void Need(ReportFilter f, ComboBox c, string name)
        {
            if (def.Required.HasFlag(f) && Ui.SelectedId(c) is null) throw new AppException($"الرجاء اختيار {name}.");
        }
        Need(ReportFilter.Tenant, cmbTenant, "المستأجر");
        Need(ReportFilter.Contract, cmbContract, "العقد");
        Need(ReportFilter.Payment, cmbPayment, "الإيصال");
        if (def.Filters.HasFlag(ReportFilter.DateRange) && dtpFrom.Value.Date > dtpTo.Value.Date)
            throw new AppException("تاريخ البداية بعد تاريخ النهاية.");

        bool Has(ReportFilter f) => def.Filters.HasFlag(f);
        string? Pick(ReportFilter f, ComboBox c, string name) => Has(f) && c.SelectedIndex > 0 ? $"{name}: {c.Text}" : null;
        int? Id(ReportFilter f, ComboBox c) => Has(f) ? Ui.SelectedId(c) : null;

        var parts = new[]
        {
            Pick(ReportFilter.Property, cmbProperty, "العقار"), Pick(ReportFilter.UnitStatus, cmbUnitStatus, "حالة الوحدة"),
            Pick(ReportFilter.ContractStatus, cmbContractStatus, "حالة العقد"), Pick(ReportFilter.User, cmbUser, "المستخدم"),
            Has(ReportFilter.DateRange) ? $"من {dtpFrom.Value:yyyy/MM/dd} إلى {dtpTo.Value:yyyy/MM/dd}" : null,
            Has(ReportFilter.Days) ? $"خلال {numDays.Value} يوماً" : null
        }.Where(p => p != null);

        return def.Build(new ReportFilterValues
        {
            PropertyId = Id(ReportFilter.Property, cmbProperty),
            UnitStatus = Has(ReportFilter.UnitStatus) ? Ui.SelectedCode(cmbUnitStatus) : null,
            ContractStatus = Has(ReportFilter.ContractStatus) ? Ui.SelectedCode(cmbContractStatus) : null,
            TenantId = Id(ReportFilter.Tenant, cmbTenant),
            ContractId = Id(ReportFilter.Contract, cmbContract),
            PaymentId = Id(ReportFilter.Payment, cmbPayment),
            UserId = Id(ReportFilter.User, cmbUser),
            From = dtpFrom.Value.Date,
            To = dtpTo.Value.Date,
            Days = (int)numDays.Value,
            Description = string.Join("   |   ", parts)
        });
    }

    /// <summary>الجدول الرئيسي في التقرير (للعرض والتصدير).</summary>
    private static DataTable MainTable(ReportResult r)
    {
        var data = r.Sections.Select(s => s.Table)
            .Where(t => !(t.Columns.Count == 2 && t.Columns[0].ColumnName == "البيان")).ToList();
        if (data.Count == 0) return r.Sections[0].Table;
        var main = data.OrderByDescending(t => t.Rows.Count).First();
        var same = data.Where(t => t.Columns.Count == main.Columns.Count).ToList();
        if (same.Count == 1) return main;
        var merged = same[0].Clone();
        foreach (var t in same) foreach (DataRow row in t.Rows) merged.ImportRow(row);
        return merged;
    }

    private void btnShow_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        var r = Build();
        Ui.BindGrid(grid, MainTable(r));
        lblPreviewTitle.Text = r.Title + (string.IsNullOrEmpty(r.Subtitle) ? "" : "  —  " + r.Subtitle);
    });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => ReportPrinter.Preview(Build(), FindForm()));
    private void btnPdf_Click(object? sender, EventArgs e) => Ui.Try(() => ReportPrinter.SavePdf(Build(), FindForm()));

    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        var r = Build();
        Ui.ExportExcel(MainTable(r), r.Title, FindForm());
    });

    private void DrawReportItem(object? sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;
        if (lstReports.Items[e.Index] is string group)   // عنوان مجموعة
        {
            using var gb = new SolidBrush(Theme.Background);
            e.Graphics.FillRectangle(gb, e.Bounds);
            using var gf = new Font(Theme.FontName, 9F, FontStyle.Bold);
            TextRenderer.DrawText(e.Graphics, group, gf, Rectangle.Inflate(e.Bounds, -10, 0), Theme.MutedText,
                TextFormatFlags.Right | TextFormatFlags.Bottom | TextFormatFlags.RightToLeft);
            return;
        }
        bool selected = (e.State & DrawItemState.Selected) != 0;
        using var back = new SolidBrush(selected ? Theme.Primary : Theme.Surface);
        e.Graphics.FillRectangle(back, e.Bounds);
        TextRenderer.DrawText(e.Graphics, "📄  " + lstReports.Items[e.Index], e.Font, Rectangle.Inflate(e.Bounds, -10, 0),
            selected ? Color.White : Theme.Text,
            TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft | TextFormatFlags.EndEllipsis);
    }
}
