using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RentalManagement.Common;

/// <summary>
/// قراءة وحفظ إعدادات التطبيق من الملف appsettings.json
/// (نص الاتصال، بيانات المكتب التي تظهر في رأس التقارير، وعدد أيام التنبيه قبل انتهاء العقد).
/// </summary>
public static class AppSettings
{
    private const string DefaultConnection =
        "Server=.\\SQLEXPRESS;Database=RentalDB;Integrated Security=True;TrustServerCertificate=True";

    public static string FilePath => Path.Combine(AppContext.BaseDirectory, "appsettings.json");

    public static string ConnectionString { get; set; } = DefaultConnection;
    public static string OfficeName { get; set; } = "مكتب العقارات";
    public static string OfficePhone { get; set; } = "";
    public static string OfficeAddress { get; set; } = "";

    /// <summary>عدد الأيام قبل انتهاء العقد التي يبدأ عندها التنبيه (FR-23).</summary>
    public static int ContractAlertDays { get; set; } = 30;

    /// <summary>السطر الثاني في رأس التقارير: الهاتف والعنوان.</summary>
    public static string OfficeLine =>
        string.Join("   —   ", new[] { OfficeAddress, OfficePhone }.Where(s => !string.IsNullOrWhiteSpace(s)));

    public static void Load()
    {
        if (!File.Exists(FilePath)) return;
        try
        {
            var root = JsonNode.Parse(File.ReadAllText(FilePath));
            ConnectionString = root?["ConnectionStrings"]?["RentalDb"]?.GetValue<string>() ?? DefaultConnection;
            OfficeName = root?["Office"]?["Name"]?.GetValue<string>() ?? OfficeName;
            OfficePhone = root?["Office"]?["Phone"]?.GetValue<string>() ?? OfficePhone;
            OfficeAddress = root?["Office"]?["Address"]?.GetValue<string>() ?? OfficeAddress;
            ContractAlertDays = root?["Alerts"]?["ContractDays"]?.GetValue<int>() ?? ContractAlertDays;
            if (ContractAlertDays is < 1 or > 365) ContractAlertDays = 30;
        }
        catch (Exception ex)
        {
            Ui.Warn("تعذر قراءة ملف الإعدادات، سيتم استخدام القيم الافتراضية.\n" + ex.Message);
        }
    }

    public static void Save()
    {
        var root = new JsonObject
        {
            ["ConnectionStrings"] = new JsonObject { ["RentalDb"] = ConnectionString },
            ["Office"] = new JsonObject { ["Name"] = OfficeName, ["Phone"] = OfficePhone, ["Address"] = OfficeAddress },
            ["Alerts"] = new JsonObject { ["ContractDays"] = ContractAlertDays }
        };
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        File.WriteAllText(FilePath, root.ToJsonString(options));
    }
}
