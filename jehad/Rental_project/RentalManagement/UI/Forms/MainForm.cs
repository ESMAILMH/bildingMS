using RentalManagement.BLL;
using RentalManagement.Pages;

namespace RentalManagement.Forms;

/// <summary>
/// النافذة الرئيسية: شريط علوي (الشعار واسم النظام والمكتب وأزرار المستخدم)،
/// ثم شريط تنقل أفقي بالصفحات مقسّم إلى مجموعات بفواصل، ثم الصفحة بعرض الشاشة كاملاً، وشريط حالة في الأسفل.
/// كل زر تنقل يحمل في Tag اسم الصفحة التي يفتحه؛ وما لا يسمح به دور المستخدم يُخفى عند التشغيل.
/// </summary>
public partial class MainForm : Form
{
    private static readonly Color Gold = Color.FromArgb(212, 175, 55);
    private static readonly Color NavText = Color.FromArgb(95, 92, 75);
    private static readonly Font NavFont = new(Theme.FontName, 11F);
    private static readonly Font NavFontActive = new(Theme.FontName, 11F, FontStyle.Bold);

    private readonly Dictionary<string, Control> _pages = new();
    private readonly System.Windows.Forms.Timer _alertTimer = new() { Interval = 5 * 60 * 1000 };
    private Button? _active;
    private int _alerts;

    public bool LogoutRequested { get; private set; }

    private IEnumerable<Button> NavButtons => flpNav.Controls.OfType<Button>();

    public MainForm()
    {
        InitializeComponent();
        Ui.ApplyIcon(this);
        var user = Session.Current ?? throw new InvalidOperationException("لا يوجد مستخدم مسجل.");
        Text = "نظام إدارة العقارات والإيجارات - " + AppSettings.OfficeName;
        lblOffice.Text = AppSettings.OfficeName;
        lblUser.Text = $"{user.DisplayName}  ·  {Labels.Of(Labels.Roles, user.Role.ToString())}";
        if (Ui.AppIcon is { } icon) picLogo.Image = new Icon(icon, 48, 48).ToBitmap();
        btnSettings.Visible = user.Role == UserRole.Manager;
        lblStatus.Text = StatusText(user);

        ApplyRole(user);
        foreach (var b in NavButtons) b.Paint += Nav_Paint;
        ButtonStyle.Apply(flpUser);   // أزرار المستخدم فقط؛ أزرار التنقل لها شكلها (خط ذهبي تحت الصفحة الحالية)

        KeyDown += (_, e) =>   // F5 = تحديث الصفحة الحالية
        {
            if (e.KeyCode != Keys.F5 || pnlContent.Controls.Count == 0 || pnlContent.Controls[0] is not IPage page) return;
            Ui.Try(page.RefreshData);
            UpdateAlertCount();
        };
        _alertTimer.Tick += (_, _) => UpdateAlertCount();
        _alertTimer.Start();
        Shown += (_, _) => NavButtons.First(b => b.Visible).PerformClick();
    }

    /// <summary>شريط الحالة: المستخدم والتاريخ وقاعدة البيانات المتصل بها.</summary>
    private static string StatusText(AppUser user)
    {
        string db = "", server = "";
        try
        {
            var b = new SqlConnectionStringBuilder(AppSettings.ConnectionString);
            db = b.InitialCatalog; server = b.DataSource;
        }
        catch (ArgumentException) { /* نص اتصال غير صالح */ }
        return $"المستخدم: {user.Username}     |     {DateTime.Today:yyyy/MM/dd}     |     قاعدة البيانات: {db} على {server}";
    }

    // ------------------------------------------------------------ الصلاحيات
    /// <summary>المستخدمون وسجل العمليات للمدير فقط (والصلاحية تُفحص أيضاً داخل كل عملية في طبقة المنطق).</summary>
    private void ApplyRole(AppUser user)
    {
        bool manager = user.Role == UserRole.Manager;
        btnNavUsers.Visible = btnNavAudit.Visible = manager;
    }

    // ------------------------------------------------------------ التنقل بين الصفحات
    /// <summary>الصفحة التي يفتحها كل زر (حسب Tag).</summary>
    private static Control CreatePage(string key) => key switch
    {
        "Dashboard" => new DashboardPage(),
        "Alerts" => new AlertsPage(),
        "Contracts" => new ContractsPage(),
        "Payments" => new PaymentsPage(),
        "Properties" => new PropertiesPage(),
        "Units" => new UnitsPage(),
        "Tenants" => new TenantsPage(),
        "Reports" => new ReportsPage(),
        "Users" => new UsersPage(),
        "Audit" => new AuditPage(),
        _ => throw new ArgumentException(key)
    };

    private void Nav_Click(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        Ui.Try(() =>
        {
            string key = (string)button.Tag!;
            bool isNew = !_pages.TryGetValue(key, out var page);
            if (isNew)
            {
                page = CreatePage(key);
                page.Dock = DockStyle.Fill;
                // بطاقات وأزرار الشاشة الرئيسية تفتح صفحات أخرى
                if (page is DashboardPage dashboard) dashboard.Navigate += OpenPage;
                _pages[key] = page;
            }
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page!);
            if (!isNew && page is IPage p) p.RefreshData();

            var previous = _active;
            _active = button;
            if (previous != null)
            {
                previous.Font = NavFont;
                previous.ForeColor = NavText;
                previous.Invalidate();
            }
            button.Font = NavFontActive;
            button.ForeColor = Theme.Primary;
            button.Invalidate();
            UpdateAlertCount();
        });
    }

    /// <summary>خط ذهبي تحت زر الصفحة الحالية.</summary>
    private void Nav_Paint(object? sender, PaintEventArgs e)
    {
        if (sender != _active) return;
        var b = (Control)sender!;
        using var brush = new SolidBrush(Gold);
        e.Graphics.FillRectangle(brush, 10, b.Height - 4, b.Width - 20, 4);
    }

    /// <summary>فتح صفحة باسمها (كما في Tag الزر)، إذا كان الدور يسمح بها.</summary>
    private void OpenPage(string key) =>
        NavButtons.FirstOrDefault(b => (string)b.Tag! == key && b.Visible)?.PerformClick();

    /// <summary>عدد التنبيهات على زر التنبيهات: الأقساط المتأخرة + العقود القريبة من الانتهاء (FR-24).</summary>
    private void UpdateAlertCount()
    {
        try
        {
            var s = DAL.ReportDal.Stats(AppSettings.ContractAlertDays);
            _alerts = Convert.ToInt32(s["OverdueCount"]) + Convert.ToInt32(s["Expiring"]) + Convert.ToInt32(s["ExpiredOpen"]);
            btnNavAlerts.Text = _alerts > 0 ? $"التنبيهات ({_alerts})" : "التنبيهات";
            if (btnNavAlerts != _active) btnNavAlerts.ForeColor = _alerts > 0 ? Theme.Danger : NavText;
        }
        catch (Exception) { /* لا نوقف الواجهة بسبب العدّاد */ }
    }

    // ------------------------------------------------------------ أزرار المستخدم
    private void btnChangePassword_Click(object? sender, EventArgs e)
    {
        using var d = new ChangePasswordDialog();
        d.ShowDialog(this);
    }

    private void btnSettings_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        using var d = new SettingsDialog();
        if (d.ShowDialog(this) != DialogResult.OK) return;
        Text = "نظام إدارة العقارات والإيجارات - " + AppSettings.OfficeName;
        lblOffice.Text = AppSettings.OfficeName;
        if (pnlContent.Controls.Count > 0 && pnlContent.Controls[0] is IPage page) page.RefreshData();
        UpdateAlertCount();
    });

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        if (!Ui.Confirm("هل تريد تسجيل الخروج؟")) return;
        Ui.Try(UserService.Logout);
        LogoutRequested = true;
        Close();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _alertTimer.Dispose();
        foreach (var p in _pages.Values) p.Dispose();
        base.OnFormClosed(e);
    }
}
