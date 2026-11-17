using System.Globalization;
using RentalManagement.DAL;
using RentalManagement.Forms;

namespace RentalManagement.Pages;

/// <summary>
/// الشاشة الرئيسية (FR-24): ترحيب، أزرار سريعة، بطاقات إحصائية (كل بطاقة تفتح صفحتها)،
/// ورسمان بيانيان: الوحدات حسب الحالة، والتحصيل الشهري لآخر 6 أشهر.
/// </summary>
public partial class DashboardPage : PageBase
{
    /// <summary>طلب الانتقال إلى صفحة أخرى (تستقبله النافذة الرئيسية باسم الصفحة مثل "Alerts").</summary>
    public event Action<string>? Navigate;

    private static readonly CultureInfo Arabic = new("ar-LY");

    public DashboardPage()
    {
        InitializeComponent();
        lblTitle.Text = $"مرحباً، {Session.Current?.DisplayName} 👋";
        lblDate.Text = DateTime.Today.ToString("dddd، d MMMM yyyy", Arabic);
        foreach (var t in new[] { tblStatus, tblChart })
        {
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));  // الاسم
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));   // الشريط
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));  // القيمة
        }
        Resize += (_, _) => FitCards();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!DesignMode) Ui.Try(RefreshData);
    }

    public override void RefreshData()
    {
        var s = ReportDal.Stats(AppSettings.ContractAlertDays);
        int units = Convert.ToInt32(s["Units"]), rented = Convert.ToInt32(s["Rented"]);
        string occupancy = units == 0 ? "—" : $"نسبة الإشغال {rented * 100 / units}%";
        flpCards.SuspendLayout();
        flpCards.Controls.Clear();
        AddCard("🏢", "العقارات", s["Properties"], $"{units} وحدة", Theme.Primary, "Properties");
        AddCard("🔑", "وحدات مؤجرة", rented, occupancy, Theme.Info, "Units");
        AddCard("🚪", "وحدات شاغرة", s["Vacant"], $"تحت الصيانة: {s["Maintenance"]}", Theme.Success, "Units");
        AddCard("📄", "عقود نشطة", s["ActiveContracts"], $"{s["Tenants"]} مستأجر فعّال", Color.FromArgb(111, 66, 193), "Contracts");
        AddCard("⛔", "أقساط متأخرة", s["OverdueCount"], Ui.Money((decimal)s["OverdueAmount"]), Theme.Danger, "Alerts");
        AddCard("⏳", "عقود تنتهي قريباً", Convert.ToInt32(s["Expiring"]) + Convert.ToInt32(s["ExpiredOpen"]),
            $"خلال {AppSettings.ContractAlertDays} يوماً أو انتهت", Theme.Warning, "Alerts");
        AddCard("💵", "المحصّل هذا الشهر", Ui.Money((decimal)s["CollectedMonth"]),
            $"المتوقع شهرياً: {Ui.Money((decimal)s["MonthlyIncome"])}", Theme.Success, "Payments");
        AddCard("📆", "مستحق باقي الشهر", Ui.Money((decimal)s["DueRestOfMonth"]), "أقساط لم يحن موعدها بعد", Theme.Neutral, "Contracts");
        flpCards.ResumeLayout();
        FitCards();
        LoadStatusChart(s);
        LoadCollectionChart();
    }

    // ------------------------------------------------------------ البطاقات
    /// <summary>بطاقة إحصائية: رمز، عنوان، قيمة، وسطر توضيح. الضغط عليها يفتح الصفحة المرتبطة.</summary>
    private void AddCard(string icon, string title, object value, string hint, Color color, string page)
    {
        var card = new Panel { Size = new Size(240, 112), BackColor = Theme.Surface, Margin = new Padding(6), Cursor = Cursors.Hand };
        card.Controls.Add(new Label { Text = Convert.ToString(value), Font = Theme.CardValue, ForeColor = color, Dock = DockStyle.Fill, Padding = new Padding(14, 0, 4, 0), TextAlign = ContentAlignment.MiddleLeft, AutoEllipsis = true });
        card.Controls.Add(new Label { Text = hint, Font = Theme.Small, ForeColor = Theme.MutedText, Dock = DockStyle.Bottom, Height = 26, Padding = new Padding(14, 0, 4, 4), AutoEllipsis = true });
        card.Controls.Add(new Label { Text = title, Font = Theme.Bold, ForeColor = Theme.Text, Dock = DockStyle.Top, Height = 34, Padding = new Padding(14, 8, 4, 0) });
        card.Controls.Add(new Label { Text = icon, Font = new Font("Segoe UI Emoji", 20F), ForeColor = color, Dock = DockStyle.Right, Width = 56, TextAlign = ContentAlignment.MiddleCenter });
        card.Controls.Add(new Panel { Dock = DockStyle.Left, Width = 6, BackColor = color });

        void Open(object? sender, EventArgs e) => Navigate?.Invoke(page);
        card.Click += Open;
        foreach (Control c in card.Controls) { c.Click += Open; c.Cursor = Cursors.Hand; }
        flpCards.Controls.Add(card);
    }

    /// <summary>4 بطاقات في كل صف عند الإمكان.</summary>
    private void FitCards()
    {
        if (flpCards.Controls.Count == 0) return;
        int width = flpCards.ClientSize.Width - 4;
        int perRow = Math.Max(1, Math.Min(4, width / 230));
        foreach (Control c in flpCards.Controls) c.Width = width / perRow - 12;
        flpCards.Height = (int)Math.Ceiling(flpCards.Controls.Count / (double)perRow) * 124 + 8;
    }

    // ------------------------------------------------------------ الرسوم البيانية البسيطة
    /// <summary>عدد الوحدات في كل حالة مع نسبتها من الإجمالي.</summary>
    private void LoadStatusChart(DataRow s)
    {
        int total = Convert.ToInt32(s["Units"]);
        string Value(string col)
        {
            int n = Convert.ToInt32(s[col]);
            return total > 0 ? $"{n}  ({n * 100 / total}%)" : n.ToString();
        }
        FillBars(tblStatus, new List<(string, double, string, Color)>
        {
            ("مؤجرة", Convert.ToInt32(s["Rented"]), Value("Rented"), Theme.Info),
            ("شاغرة", Convert.ToInt32(s["Vacant"]), Value("Vacant"), Theme.Success),
            ("تحت الصيانة", Convert.ToInt32(s["Maintenance"]), Value("Maintenance"), Theme.Warning),
        }, "لا توجد وحدات بعد");
    }

    /// <summary>المبالغ المحصّلة في كل شهر من آخر 6 أشهر.</summary>
    private void LoadCollectionChart()
    {
        var data = ReportDal.MonthlyCollections(6)
            .Select(m => (m.Month.ToString("MMMM yyyy", Arabic), (double)m.Amount, m.Amount.ToString("N0", CultureInfo.InvariantCulture),
                          m.Month.Month == DateTime.Today.Month ? Theme.Success : Theme.Primary))
            .ToList();
        FillBars(tblChart, data, "لا توجد دفعات بعد");
    }

    /// <summary>يرسم أشرطة أفقية في الجدول: الاسم، الشريط (طوله نسبة إلى الأكبر)، ثم القيمة.</summary>
    private static void FillBars(TableLayoutPanel tbl, List<(string Name, double Value, string Text, Color Color)> data, string emptyText)
    {
        double max = data.Count == 0 ? 1 : Math.Max(1, data.Max(x => x.Value));
        tbl.SuspendLayout();
        tbl.Controls.Clear();
        tbl.RowStyles.Clear();
        for (int i = 0; i < data.Count; i++)
        {
            var (name, value, text, color) = data[i];
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            var host = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 8, 0, 8) };
            var bar = new Panel { Dock = DockStyle.Left, BackColor = color };
            double ratio = value / max;
            host.Resize += (_, _) => bar.Width = value <= 0 ? 0 : Math.Max(4, (int)(host.ClientSize.Width * ratio));
            host.Controls.Add(bar);
            tbl.Controls.Add(new Label { Text = name, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, AutoEllipsis = true }, 0, i);
            tbl.Controls.Add(host, 1, i);
            tbl.Controls.Add(new Label { Text = text, Dock = DockStyle.Fill, Font = Theme.Bold, ForeColor = color, TextAlign = ContentAlignment.MiddleCenter }, 2, i);
        }
        tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));   // صف فارغ يأخذ باقي المساحة حتى لا يتمدد آخر شريط
        tbl.RowCount = data.Count + 1;
        if (data.All(x => x.Value <= 0)) tbl.Controls.Add(new Label { Text = emptyText, AutoSize = true, ForeColor = Theme.MutedText }, 1, data.Count);
        tbl.ResumeLayout();
    }

    // ------------------------------------------------------------ الأزرار
    private void btnQuickContract_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new ContractDialog()));
    private void btnQuickPayment_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new PaymentDialog()));
    private void btnQuickTenant_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new TenantDialog(null)));
    private void btnQuickReports_Click(object? sender, EventArgs e) => Navigate?.Invoke("Reports");
}
