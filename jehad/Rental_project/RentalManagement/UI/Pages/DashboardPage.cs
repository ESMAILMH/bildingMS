using System.Drawing.Drawing2D;
using System.Globalization;
using RentalManagement.DAL;
using RentalManagement.Forms;

namespace RentalManagement.Pages;

/// <summary>
/// الشاشة الرئيسية (FR-24): شريط ترحيب بالتاريخ والأزرار السريعة، ثم ثماني بطاقات في شبكة 4 × 2
/// (كل بطاقة تفتح صفحتها)، ثم رسمان: دائرة نسبة الإشغال، وأعمدة التحصيل لآخر 6 أشهر. لا جداول في هذه الشاشة.
/// </summary>
public partial class DashboardPage : PageBase
{
    /// <summary>طلب الانتقال إلى صفحة أخرى (تستقبله النافذة الرئيسية باسم الصفحة مثل "Alerts").</summary>
    public event Action<string>? Navigate;

    private static readonly CultureInfo Arabic = new("ar-LY");
    private static readonly Color Gold = Color.FromArgb(201, 149, 43);

    /// <summary>بيانات بطاقة: رمز، عنوان، قيمة، توضيح، لون، والصفحة التي تفتحها.</summary>
    private sealed record Tile(string Icon, string Title, string Value, string Hint, Color Color, string Page);

    private (int Rented, int Vacant, int Maintenance) _units;
    private List<(DateTime Month, decimal Amount)> _months = new();

    public DashboardPage()
    {
        InitializeComponent();
        lblTitle.Text = $"أهلاً، {Session.Current?.DisplayName}";
        lblDate.Text = DateTime.Today.ToString("dddd، d MMMM yyyy", Arabic) + "  —  " + AppSettings.OfficeName;
        foreach (var p in new[] { pnlDonut, pnlColumns }) Smooth(p);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!DesignMode) Ui.Try(RefreshData);
    }

    public override void RefreshData()
    {
        var s = ReportDal.Stats(AppSettings.ContractAlertDays);
        int I(string c) => Convert.ToInt32(s[c]);
        string M(string c) => ((decimal)s[c]).ToString("N0", CultureInfo.InvariantCulture);
        int units = I("Units");
        _units = (I("Rented"), I("Vacant"), I("Maintenance"));
        _months = ReportDal.MonthlyCollections(6);

        var tiles = new[]
        {
            new Tile("🏢", "العقارات", I("Properties").ToString(), $"{units} وحدة", Theme.Primary, "Properties"),
            new Tile("🔑", "وحدات مؤجرة", I("Rented").ToString(), units == 0 ? "—" : $"الإشغال {I("Rented") * 100 / units}%", Theme.Info, "Units"),
            new Tile("🚪", "وحدات شاغرة", I("Vacant").ToString(), $"تحت الصيانة: {I("Maintenance")}", Theme.Success, "Units"),
            new Tile("📄", "عقود نشطة", I("ActiveContracts").ToString(), $"{I("Tenants")} مستأجر فعّال", Color.FromArgb(156, 107, 48), "Contracts"),
            new Tile("⛔", "أقساط متأخرة", I("OverdueCount").ToString(), $"{M("OverdueAmount")} د.ل", Theme.Danger, "Alerts"),
            new Tile("⏳", "عقود تنتهي قريباً", (I("Expiring") + I("ExpiredOpen")).ToString(), $"خلال {AppSettings.ContractAlertDays} يوماً أو انتهت", Gold, "Alerts"),
            new Tile("💵", "المحصّل هذا الشهر", M("CollectedMonth"), $"المتوقع شهرياً {M("MonthlyIncome")} د.ل", Theme.Success, "Payments"),
            new Tile("📆", "مستحق باقي الشهر", M("DueRestOfMonth"), "أقساط لم يحن موعدها", Theme.Neutral, "Contracts"),
        };
        tblCards.SuspendLayout();
        foreach (Control c in tblCards.Controls) c.Dispose();
        tblCards.Controls.Clear();
        for (int i = 0; i < tiles.Length; i++) tblCards.Controls.Add(MakeTile(tiles[i]), i % 4, i / 4);
        tblCards.ResumeLayout();
        pnlDonut.Invalidate();
        pnlColumns.Invalidate();
    }

    // ------------------------------------------------------------ البطاقات
    /// <summary>بطاقة مرسومة: إطار دائري الزوايا، رمز داخل دائرة ملونة، القيمة بخط كبير، ثم العنوان والتوضيح.</summary>
    private Control MakeTile(Tile t)
    {
        var p = new Panel { Dock = DockStyle.Fill, Margin = new Padding(8), Cursor = Cursors.Hand, BackColor = Theme.Background };
        Smooth(p);
        bool hover = false;
        p.MouseEnter += (_, _) => { hover = true; p.Invalidate(); };
        p.MouseLeave += (_, _) => { hover = false; p.Invalidate(); };
        p.Click += (_, _) => Navigate?.Invoke(t.Page);
        p.Paint += (_, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new RectangleF(1, 1, p.Width - 3, p.Height - 3);
            using (var path = Rounded(r, 14))
            using (var fill = new SolidBrush(hover ? Color.FromArgb(252, 250, 242) : Theme.Surface))
            using (var pen = new Pen(hover ? t.Color : Theme.Border, hover ? 2f : 1.2f))
            {
                g.FillPath(fill, path);
                g.DrawPath(pen, path);
            }
            // الرمز داخل دائرة بلون فاتح من لون البطاقة (في الجهة اليمنى للواجهة العربية)
            const int d = 46;
            var circle = new RectangleF(r.Right - d - 16, r.Top + 16, d, d);
            using (var tint = new SolidBrush(Color.FromArgb(40, t.Color))) g.FillEllipse(tint, circle);
            using (var emoji = new Font("Segoe UI Emoji", 16F))
                TextRenderer.DrawText(g, t.Icon, emoji, Rectangle.Round(circle), t.Color,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            var rtl = TextFormatFlags.Right | TextFormatFlags.RightToLeft | TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine;
            int textRight = (int)circle.Left - 12;
            TextRenderer.DrawText(g, t.Title, Theme.Bold, new Rectangle(16, (int)r.Top + 16, textRight - 16, 24), Theme.Text, rtl);
            TextRenderer.DrawText(g, t.Hint, Theme.Small, new Rectangle(16, (int)r.Top + 40, textRight - 16, 22), Theme.MutedText, rtl);
            using var big = new Font(Theme.FontName, 22F, FontStyle.Bold);
            TextRenderer.DrawText(g, t.Value, big, new Rectangle(16, (int)r.Bottom - 50, (int)r.Width - 32, 42), t.Color,
                rtl | TextFormatFlags.VerticalCenter);
        };
        return p;
    }

    // ------------------------------------------------------------ الرسمان
    /// <summary>دائرة الإشغال: مؤجرة / شاغرة / صيانة، والنسبة في الوسط، ومفتاح الألوان بجانبها.</summary>
    private void pnlDonut_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        var parts = new (string Name, int Value, Color Color)[]
        {
            ("مؤجرة", _units.Rented, Theme.Primary), ("شاغرة", _units.Vacant, Gold), ("تحت الصيانة", _units.Maintenance, Theme.Neutral)
        };
        int total = parts.Sum(x => x.Value);
        int size = Math.Max(60, Math.Min(pnlDonut.Height - 10, pnlDonut.Width / 2 - 10));
        var ring = new RectangleF(pnlDonut.Width - size - 10, (pnlDonut.Height - size) / 2f, size, size);   // يمين اللوحة
        const float thick = 26;
        var inner = RectangleF.Inflate(ring, -thick / 2, -thick / 2);
        float start = -90;
        if (total == 0)
            using (var pen = new Pen(Theme.Border, thick)) g.DrawEllipse(pen, inner);
        foreach (var (_, value, color) in parts)
        {
            if (total == 0 || value == 0) continue;
            float sweep = 360f * value / total;
            using var pen = new Pen(color, thick);
            g.DrawArc(pen, inner, start, sweep);
            start += sweep;
        }
        string pct = total == 0 ? "—" : $"{_units.Rented * 100 / total}%";
        using (var big = new Font(Theme.FontName, 20F, FontStyle.Bold))
            TextRenderer.DrawText(g, pct, big, Rectangle.Round(new RectangleF(ring.X, ring.Y + ring.Height / 2 - 26, ring.Width, 34)), Theme.Primary,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        TextRenderer.DrawText(g, "إشغال", Theme.Small, Rectangle.Round(new RectangleF(ring.X, ring.Y + ring.Height / 2 + 6, ring.Width, 22)),
            Theme.MutedText, TextFormatFlags.HorizontalCenter | TextFormatFlags.RightToLeft);

        // مفتاح الألوان على يسار الدائرة
        float y = ring.Y + ring.Height / 2 - parts.Length * 17;
        int legendRight = (int)ring.Left - 20;
        foreach (var (name, value, color) in parts)
        {
            using (var b = new SolidBrush(color)) g.FillEllipse(b, legendRight - 12, y + 6, 12, 12);
            TextRenderer.DrawText(g, $"{name}: {value}", Theme.Base, new Rectangle(0, (int)y, legendRight - 18, 24), Theme.Text,
                TextFormatFlags.Right | TextFormatFlags.RightToLeft | TextFormatFlags.VerticalCenter);
            y += 34;
        }
    }

    /// <summary>أعمدة التحصيل الشهري: من الأقدم (يمين) إلى الشهر الحالي (يسار، بالذهبي)، والقيمة فوق كل عمود.</summary>
    private void pnlColumns_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        if (_months.Count == 0) return;
        int w = pnlColumns.Width, h = pnlColumns.Height;
        const int top = 26, bottom = 30;
        float chartH = Math.Max(20, h - top - bottom);
        decimal max = Math.Max(1, _months.Max(m => m.Amount));
        float slot = w / (float)_months.Count;
        float barW = Math.Min(56, slot * 0.55f);
        using (var axis = new Pen(Theme.Border, 1.2f)) g.DrawLine(axis, 0, h - bottom, w, h - bottom);
        for (int i = 0; i < _months.Count; i++)
        {
            var (month, amount) = _months[i];
            bool current = i == _months.Count - 1;
            float x = w - (i + 1) * slot + (slot - barW) / 2;      // الأقدم على اليمين
            float bh = (float)(amount / max) * chartH;
            var bar = new RectangleF(x, h - bottom - bh, barW, Math.Max(bh, 1));
            using (var path = Rounded(bar, Math.Min(8, bar.Height / 2)))
            using (var brush = new SolidBrush(current ? Gold : Theme.Primary))
                g.FillPath(brush, path);
            TextRenderer.DrawText(g, amount.ToString("N0", CultureInfo.InvariantCulture), Theme.Small,
                new Rectangle((int)(x - 20), (int)(bar.Top - 22), (int)barW + 40, 20), Theme.Text, TextFormatFlags.HorizontalCenter);
            TextRenderer.DrawText(g, month.ToString("MMM", Arabic), Theme.Small,
                new Rectangle((int)(x - 20), h - bottom + 4, (int)barW + 40, 22), current ? Gold : Theme.MutedText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.RightToLeft);
        }
    }

    // ------------------------------------------------------------ مساعدات الرسم
    private static void Smooth(Control c)
    {
        typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            ?.SetValue(c, true);
        c.Resize += (_, _) => c.Invalidate();
    }

    private static GraphicsPath Rounded(RectangleF r, float radius)
    {
        float d = Math.Max(1, Math.Min(radius * 2, Math.Min(r.Width, r.Height)));
        var p = new GraphicsPath();
        p.AddArc(r.X, r.Y, d, d, 180, 90);
        p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        p.CloseFigure();
        return p;
    }

    // ------------------------------------------------------------ الأزرار السريعة
    private void btnQuickContract_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new ContractDialog()));
    private void btnQuickPayment_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new PaymentDialog()));
    private void btnQuickTenant_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new TenantDialog(null)));
    private void btnQuickReports_Click(object? sender, EventArgs e) => Navigate?.Invoke("Reports");
}
