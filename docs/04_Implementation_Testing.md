# التنفيذ والاختبار

## 1. تجهيز البيئة

| الأداة | الإصدار المقترح | ملاحظات |
|---|---|---|
| Visual Studio | 2022 Community | حزمة **.NET desktop development** + إضافة **Microsoft RDLC Report Designer** |
| إطار العمل | **.NET Framework 4.8** (Windows Forms) | الأسهل مع RDLC ReportViewer. (بديل: .NET 8 + حزمة `ReportViewerCore.WinForms`) |
| SQL Server | 2019/2022 **Express** | أو LocalDB المرفق مع Visual Studio |
| SSMS | آخر إصدار | لتنفيذ السكربتات وإدارة القاعدة |
| Git | — | لحفظ النسخ ورفعها على GitHub |

## 2. هيكل الحل (Solution) في Visual Studio

```
RentalMS.sln
├── RentalMS.Models        (Class Library)  ← أصناف الكيانات + Enums
│     User.cs, Property.cs, Unit.cs, Tenant.cs, Contract.cs, Installment.cs, Payment.cs, Enums.cs
├── RentalMS.DAL           (Class Library)  ← ADO.NET
│     DbHelper.cs
│     Repositories/ UserRepository.cs, PropertyRepository.cs, UnitRepository.cs,
│                   TenantRepository.cs, ContractRepository.cs, PaymentRepository.cs, ReportRepository.cs
├── RentalMS.BLL           (Class Library)  ← منطق الأعمال
│     AuthService.cs, PropertyService.cs, TenantService.cs, ContractService.cs,
│     PaymentService.cs, AlertService.cs, ReportService.cs, BackupService.cs, ValidationException.cs
├── RentalMS.UI            (Windows Forms App) ← المشروع الذي يُشغَّل
│     Program.cs, App.config
│     Forms/   LoginForm, MainForm, PropertiesForm, UnitsForm, TenantsForm, ContractForm,
│              ContractsListForm, PaymentForm, AlertsForm, SearchForm, ReportsForm, UsersForm, SettingsForm
│     Reports/ Receipt.rdlc, TenantStatement.rdlc, Overdue.rdlc, ...
│     Helpers/ UiHelper.cs (رسائل موحدة، تنسيق الجداول، تحويل الرقم إلى كتابة)
└── RentalMS.Tests         (Unit Test Project – MSTest)
```

**المراجع (References):** `UI → BLL, Models` ، `BLL → DAL, Models` ، `DAL → Models`.

## 3. أمثلة الكود الأساسية

### 3.1 سلسلة الاتصال – `App.config`
```xml
<configuration>
  <connectionStrings>
    <add name="RentalDB"
         connectionString="Server=.\SQLEXPRESS;Database=RentalDB;Integrated Security=True;"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>
```

### 3.2 طبقة البيانات – `DbHelper.cs`
```csharp
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RentalMS.DAL
{
    public static class DbHelper
    {
        private static readonly string ConnStr =
            ConfigurationManager.ConnectionStrings["RentalDB"].ConnectionString;

        public static SqlConnection GetConnection() => new SqlConnection(ConnStr);

        public static DataTable ExecuteQuery(string sql, params SqlParameter[] prms)
        {
            using (var con = GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(prms);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] prms)
        {
            using (var con = GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(prms);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] prms)
        {
            using (var con = GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(prms);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
```

> ⚠️ **ممنوع** بناء الاستعلام بدمج النصوص مثل `"... WHERE Name='" + txtName.Text + "'"` — استخدم دائماً `SqlParameter` (NFR-02).

### 3.3 تنفيذ إجراء مخزن – إنشاء عقد `ContractRepository.Create`
```csharp
public int Create(Contract c, int userId)
{
    using (var con = DbHelper.GetConnection())
    using (var cmd = new SqlCommand("dbo.sp_CreateContract", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@UnitID", SqlDbType.Int).Value = c.UnitID;
        cmd.Parameters.Add("@TenantID", SqlDbType.Int).Value = c.TenantID;
        cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = c.StartDate;
        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = c.EndDate;
        var rent = cmd.Parameters.Add("@MonthlyRent", SqlDbType.Decimal);
        rent.Precision = 12; rent.Scale = 2; rent.Value = c.MonthlyRent;
        cmd.Parameters.Add("@PaymentFrequency", SqlDbType.TinyInt).Value = c.PaymentFrequency;
        cmd.Parameters.Add("@DepositAmount", SqlDbType.Decimal).Value = c.DepositAmount;
        cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = (object)c.Notes ?? DBNull.Value;
        cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = userId;
        var outId = cmd.Parameters.Add("@NewContractID", SqlDbType.Int);
        outId.Direction = ParameterDirection.Output;

        con.Open();
        cmd.ExecuteNonQuery();
        return (int)outId.Value;
    }
}
```

### 3.4 تشفير كلمة المرور – `AuthService`
```csharp
using System.Security.Cryptography;
using System.Text;

public static class AuthService
{
    public static User CurrentUser { get; private set; }

    // يجب أن تطابق: HASHBYTES('SHA2_256', Salt + Password) في SQL (NVARCHAR = UTF-16)
    public static byte[] HashPassword(string salt, string password)
    {
        using (var sha = SHA256.Create())
            return sha.ComputeHash(Encoding.Unicode.GetBytes(salt + password));
    }

    public static bool Login(string username, string password)
    {
        var row = new UserRepository().GetActiveByUsername(username); // يرجع Hash و Salt و Role
        if (row == null) return false;
        var hash = HashPassword(row.Salt, password);
        if (!hash.SequenceEqual(row.PasswordHash)) return false;
        CurrentUser = row.ToUser();
        return true;
    }

    public static void Require(UserRole role)
    {
        if (CurrentUser == null || (role == UserRole.Admin && CurrentUser.Role != UserRole.Admin))
            throw new UnauthorizedAccessException("ليس لديك صلاحية لتنفيذ هذه العملية.");
    }
}
```
> ملاحظة للتوصيات: SHA-256 مع Salt كافٍ لمشروع تخرج، والأقوى في الأنظمة الحقيقية PBKDF2 أو bcrypt.

### 3.5 منطق الأعمال – التحقق ومعاينة الأقساط `ContractService`
```csharp
public List<Installment> PreviewInstallments(Contract c)
{
    var list = new List<Installment>();
    var stop = c.EndDate.Date.AddDays(1);
    for (int no = 1; ; no++)
    {
        var due = c.StartDate.Date.AddMonths(c.PaymentFrequency * (no - 1));
        if (due >= stop) break;
        int months = ((stop.Year - due.Year) * 12) + stop.Month - due.Month; // مثل DATEDIFF(MONTH)
        months = Math.Max(1, Math.Min(months, c.PaymentFrequency));
        list.Add(new Installment { InstallmentNo = no, DueDate = due, Amount = c.MonthlyRent * months });
    }
    return list;
}

public int CreateContract(Contract c)
{
    if (c.UnitID <= 0 || c.TenantID <= 0) throw new ValidationException("اختر الوحدة والمستأجر.");
    if (c.EndDate <= c.StartDate)          throw new ValidationException("تاريخ النهاية يجب أن يكون بعد البداية.");
    if (c.MonthlyRent <= 0)                throw new ValidationException("أدخل قيمة إيجار صحيحة.");
    if (!new[] { 1, 3, 6, 12 }.Contains(c.PaymentFrequency))
                                           throw new ValidationException("دورية الدفع غير صحيحة.");
    return _repo.Create(c, AuthService.CurrentUser.UserID);
}
```

### 3.6 الواجهة – معالجة الأخطاء بشكل موحد
```csharp
private void btnSave_Click(object sender, EventArgs e)
{
    try
    {
        int id = _service.CreateContract(ReadContractFromForm());
        MessageBox.Show("تم حفظ العقد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
        Close();
    }
    catch (ValidationException ex) { UiHelper.Warn(ex.Message); }
    catch (SqlException ex) when (ex.Number >= 50000) { UiHelper.Warn(ex.Message); } // رسائل THROW من الإجراءات
    catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627) { UiHelper.Warn("القيمة مكررة."); }
    catch (Exception ex) { UiHelper.Error("حدث خطأ غير متوقع: " + ex.Message); }
}
```

### 3.7 النسخ الاحتياطي (FR-30)
```csharp
string sql = "BACKUP DATABASE RentalDB TO DISK = @path WITH INIT";
DbHelper.ExecuteNonQuery(sql, new SqlParameter("@path", path));
// ملاحظة: المسار يجب أن يكون مجلداً يملك حساب خدمة SQL Server صلاحية الكتابة عليه.
```

## 4. ترتيب التنفيذ المقترح (Sprints أسبوعية)

| الأسبوع | المهام | معيار الإنجاز |
|---|---|---|
| 9 | السكربتات + Models + DbHelper + LoginForm + MainForm (القوائم والصلاحيات) | الدخول يعمل بالحسابين ويظهر/يخفي القوائم |
| 10 | العقارات + الوحدات + المستأجرون (CRUD كامل مع التحقق) | إضافة/تعديل/بحث/حذف بدون أخطاء |
| 11 | عقد جديد + معاينة الأقساط + قائمة العقود + إنهاء/فسخ/تجديد | الوحدة تتحول لمؤجرة والأقساط صحيحة |
| 12 | تسجيل الدفعات + إيصال القبض + Dashboard + التنبيهات | المتأخرات تظهر بدقة بعد كل دفعة |
| 13 | البحث الشامل + التقارير التسعة + المستخدمون + الإعدادات والنسخ الاحتياطي | كل تقرير يُطبع ويُصدّر PDF |

## 5. الاختبار

### 5.1 اختبار الوحدات (Unit Tests – MSTest)
```csharp
[TestMethod]
public void Preview_Yearly12Months_Quarterly_Gives4x2400()
{
    var c = new Contract { StartDate = new DateTime(2026,1,1), EndDate = new DateTime(2026,12,31),
                           MonthlyRent = 800, PaymentFrequency = 3 };
    var list = new ContractService().PreviewInstallments(c);
    Assert.AreEqual(4, list.Count);
    Assert.IsTrue(list.All(i => i.Amount == 2400));
    Assert.AreEqual(new DateTime(2026,10,1), list[3].DueDate);
}

[TestMethod]
public void Preview_TenMonths_SemiAnnual_LastIsProrated()
{
    var c = new Contract { StartDate = new DateTime(2026,1,1), EndDate = new DateTime(2026,10,31),
                           MonthlyRent = 1000, PaymentFrequency = 6 };
    var list = new ContractService().PreviewInstallments(c);
    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(6000, list[0].Amount);
    Assert.AreEqual(4000, list[1].Amount);   // 4 أشهر فقط
}
```

### 5.2 حالات اختبار النظام (System Test Cases)

| رقم | الحالة | الخطوات / المدخلات | النتيجة المتوقعة |
|---|---|---|---|
| TC-01 | دخول صحيح | admin / Admin@123 | فتح الرئيسية بكل القوائم |
| TC-02 | دخول خاطئ | admin / 123 | رسالة خطأ، البقاء في شاشة الدخول |
| TC-03 | صلاحيات الموظف | دخول employee | قوائم المستخدمين والإعدادات وزر الحذف مخفية |
| TC-04 | حقل إلزامي فارغ | حفظ عقار بدون اسم | رسالة "الاسم مطلوب" وعدم الحفظ |
| TC-05 | رقم وطني مكرر | إضافة مستأجر برقم موجود | رسالة "القيمة مكررة" |
| TC-06 | رقم وحدة مكرر في نفس العقار | إضافة وحدة 101 مرتين | رفض الحفظ |
| TC-07 | إبرام عقد صحيح | وحدة شاغرة + مستأجر + سنة شهري 800 | 12 قسطاً × 800، الوحدة "مؤجرة" |
| TC-08 | عقد على وحدة مؤجرة | محاولة اختيار وحدة مؤجرة | لا تظهر في القائمة / رسالة من الإجراء |
| TC-09 | تواريخ معكوسة | النهاية قبل البداية | رسالة خطأ |
| TC-10 | دفعة كاملة | سداد قسط 800 | حالة القسط "مدفوع"، رقم إيصال R-xxxxxx |
| TC-11 | دفعة جزئية | 300 من 800 | حالة "جزئي"، المتبقي 500 |
| TC-12 | دفعة زائدة | 900 على قسط متبقيه 500 | رفض: "المبلغ أكبر من المتبقي" |
| TC-13 | ظهور المتأخرات | قسط تاريخه أمس وغير مدفوع | يظهر في التنبيهات بعدد أيام 1 |
| TC-14 | اختفاء المتأخر بعد السداد | سداد TC-13 كاملاً | يختفي من التنبيهات |
| TC-15 | تنبيه قرب الانتهاء | عقد ينتهي بعد 20 يوماً، الإعداد 30 | يظهر في التنبيهات |
| TC-16 | تغيير أيام التنبيه | تغيير الإعداد إلى 10 | عقد TC-15 يختفي |
| TC-17 | فسخ عقد | فسخ عقد نشط | الحالة Terminated، الوحدة شاغرة، الأقساط المستقبلية غير المدفوعة تُحذف |
| TC-18 | تجديد عقد | تجديد سنة إضافية | القديم Ended، جديد Active يبدأ في اليوم التالي |
| TC-19 | حذف عقار له عقود | حذف | رفض مع رسالة |
| TC-20 | البحث | كتابة جزء من رقم الهاتف | ظهور المستأجر |
| TC-21 | كشف حساب | مستأجر لديه دفعات | المدين والدائن والرصيد صحيح |
| TC-22 | تقرير الإيرادات | فترة شهر | المجموع = مجموع الدفعات في الفترة |
| TC-23 | الطباعة والتصدير | طباعة إيصال، تصدير PDF | ملف PDF بالعربية بشكل صحيح |
| TC-24 | حقن SQL | إدخال `' OR 1=1 --` في الدخول | فشل الدخول، لا خطأ |
| TC-25 | النسخ الاحتياطي والاستعادة | أخذ نسخة ثم حذف سجل ثم استعادة | عودة السجل |

### 5.3 اختبار القبول
- جلسة مع المالك/موظف المكتب، يُدخل بيانات حقيقية لعقار واحد على الأقل ويستخدم النظام.
- استبيان رضا قصير (سهولة الاستخدام، الوضوح، السرعة، الفائدة) بمقياس 1–5 وتُعرض نتيجته في الكتاب.

## 6. النشر (Deployment)
1. **Build → Release**.
2. إنشاء ملف تثبيت بـ **Inno Setup** (مجاني) أو *Visual Studio Installer Projects*.
3. على جهاز العميل: تثبيت SQL Server Express ← تشغيل السكربتات الثلاثة (أو Restore لملف `.bak`) ← تعديل `ServerName` في `RentalMS.UI.exe.config` ← تشغيل البرنامج.

## 7. هيكل كتاب مشروع التخرج المقترح

| الفصل | العنوان | المحتوى | المصدر في المستودع |
|---|---|---|---|
| — | الصفحات التمهيدية | الغلاف، الإهداء، الشكر، الملخص (عربي/إنجليزي)، الفهارس | — |
| 1 | **المقدمة** | تمهيد، المشكلة، الأهداف، الأهمية، الحدود، المنهجية، هيكل البحث | المقترح |
| 2 | **الدراسات السابقة والإطار النظري** | الأنظمة المشابهة ومقارنتها، مفاهيم: نظم المعلومات، قواعد البيانات العلائقية، C#، .NET، ADO.NET، SQL Server | المرحلة 1 |
| 3 | **تحليل النظام** | النظام الحالي، الجدوى، المتطلبات الوظيفية وغير الوظيفية، الفاعلون، حالات الاستخدام، DFD | `01_Requirements_Analysis.md` |
| 4 | **تصميم النظام** | المعمارية، ERD، المخطط العلائقي، التطبيع، قاموس البيانات، Class/Sequence/Activity، تصميم الواجهات والتقارير | `02` و `03` |
| 5 | **التنفيذ** | بيئة العمل، هيكل الحل، شرح أهم الأكواد، لقطات الشاشات مع شرح كل شاشة | `04` + الكود |
| 6 | **الاختبار والنتائج** | استراتيجية الاختبار، جدول حالات الاختبار ونتائجها، اختبار القبول | `04` |
| 7 | **الخاتمة والتوصيات** | ما تحقق من الأهداف، الصعوبات، التوصيات المستقبلية | — |
| — | المراجع والملاحق | المراجع، دليل المستخدم، سكربتات قاعدة البيانات | `database/` |

### توصيات مستقبلية (للفصل السابع)
- نسخة ويب (ASP.NET Core) وتطبيق جوال للمستأجر.
- إرسال تنبيهات SMS/WhatsApp للمستأجرين المتأخرين.
- الدفع الإلكتروني وربط النظام بالبنوك المحلية.
- دعم تعدد المكاتب والملاك (Multi-tenant).
- وحدة محاسبية متكاملة (مصروفات الصيانة، صافي الربح).
- أرشفة إلكترونية لصور العقود والهويات.

## 8. أسئلة متوقعة في المناقشة

| السؤال | محور الإجابة |
|---|---|
| لماذا Windows Forms وليس ويب؟ | حدود المشروع: مكتب واحد، جهاز واحد، بيئة Windows، سرعة التطوير، لا يحتاج إنترنت. |
| كيف تمنع تأجير الوحدة مرتين؟ | ثلاث طبقات حماية: فلترة الواجهة، فحص الإجراء مع قفل UPDLOCK، وفهرس فريد مرشّح على مستوى القاعدة. |
| ماذا لو انقطع التيار أثناء حفظ العقد؟ | المعاملات (Transaction) + `XACT_ABORT ON`: إما يُحفظ العقد وأقساطه وتحديث الوحدة كلها أو لا شيء. |
| كيف تحمي كلمات المرور؟ | لا تُخزن نصاً؛ تُخزن Hash بـ SHA-256 مع Salt عشوائي لكل مستخدم. |
| كيف تمنع SQL Injection؟ | الاستعلامات ذات المعاملات والإجراءات المخزنة فقط. |
| لماذا خزّنت PaidAmount وهو قيمة مشتقة؟ | تسريع التنبيهات والتقارير، ويُحدَّث فقط داخل إجراء واحد ضمن معاملة، مع قيد CHECK يمنع تجاوز قيمة القسط. |
| كيف يُحسب القسط الأخير إذا لم تكتمل الدورة؟ | بالتناسب حسب عدد الأشهر المتبقية (BR-04). |
