# تصميم النظام

## 1. المعمارية: ثلاث طبقات (3-Tier / Layered Architecture)

```mermaid
flowchart TB
    subgraph PL["طبقة العرض – RentalMS.UI (Windows Forms)"]
        F1[LoginForm] --- F2[MainForm / Dashboard] --- F3[شاشات الإدارة] --- F4[ReportViewer]
    end
    subgraph BLL["طبقة منطق الأعمال – RentalMS.BLL"]
        S1[AuthService] --- S2[ContractService] --- S3[PaymentService] --- S4[AlertService] --- S5[ReportService]
    end
    subgraph DAL["طبقة الوصول للبيانات – RentalMS.DAL (ADO.NET)"]
        D0[DbHelper] --- D1[Repositories]
    end
    DB[(SQL Server – RentalDB)]
    M[[RentalMS.Models – الأصناف المشتركة]]

    PL --> BLL --> DAL --> DB
    PL -.-> M
    BLL -.-> M
    DAL -.-> M
```

**لماذا ثلاث طبقات؟** فصل الواجهة عن المنطق عن البيانات يسهّل الاختبار والصيانة، ويمكّن مستقبلاً من استبدال WinForms بواجهة ويب دون إعادة كتابة المنطق (يُذكر في التوصيات).

| الطبقة | المسؤولية | لا يُسمح لها بـ |
|---|---|---|
| UI | عرض البيانات، استقبال المدخلات، رسائل المستخدم | كتابة SQL مباشرة |
| BLL | التحقق من المدخلات، قواعد العمل، الصلاحيات | التعامل مع عناصر الواجهة (TextBox...) |
| DAL | فتح الاتصال، تنفيذ الاستعلامات والإجراءات، تحويل النتائج إلى كائنات | منطق الأعمال |

## 2. مخطط الأصناف (Class Diagram)

```mermaid
classDiagram
    direction LR
    class User {
        +int UserID
        +string FullName
        +string Username
        +UserRole Role
        +bool IsActive
        +bool IsAdmin()
    }
    class Property {
        +int PropertyID
        +string PropertyName
        +string PropertyType
        +string City
        +string Address
        +List~Unit~ Units
    }
    class Unit {
        +int UnitID
        +int PropertyID
        +string UnitNumber
        +string UnitType
        +decimal DefaultRent
        +UnitStatus Status
    }
    class Tenant {
        +int TenantID
        +string FullName
        +string NationalID
        +string Phone
    }
    class Contract {
        +int ContractID
        +string ContractNumber
        +int UnitID
        +int TenantID
        +DateTime StartDate
        +DateTime EndDate
        +decimal MonthlyRent
        +int PaymentFrequency
        +ContractStatus Status
        +int DaysLeft()
        +List~Installment~ Installments
    }
    class Installment {
        +int InstallmentID
        +int InstallmentNo
        +DateTime DueDate
        +decimal Amount
        +decimal PaidAmount
        +decimal Remaining()
        +bool IsOverdue()
    }
    class Payment {
        +int PaymentID
        +string ReceiptNumber
        +int InstallmentID
        +DateTime PaymentDate
        +decimal Amount
        +string PaymentMethod
    }

    class DbHelper {
        -string connectionString
        +DataTable ExecuteQuery(sql, params)
        +int ExecuteNonQuery(sql, params)
        +object ExecuteScalar(sql, params)
        +SqlCommand StoredProc(name)
    }
    class ContractRepository {
        +List~Contract~ GetAll(filter)
        +Contract GetById(id)
        +int Create(Contract c, int userId)
        +void Close(id, date, terminate)
    }
    class ContractService {
        +int CreateContract(Contract c)
        +List~Installment~ PreviewInstallments(Contract c)
        +void Terminate(id)
        +int Renew(id, newEnd, rent, freq)
    }
    class PaymentService {
        +int RecordPayment(Payment p)
        +void PrintReceipt(paymentId)
    }
    class AuthService {
        +User CurrentUser$
        +bool Login(username, password)
        +string HashPassword(salt, password)
        +void Require(UserRole role)
    }
    class AlertService {
        +List~Installment~ GetOverdue()
        +List~Contract~ GetExpiring()
    }

    Property "1" o-- "*" Unit
    Unit "1" -- "*" Contract
    Tenant "1" -- "*" Contract
    Contract "1" *-- "*" Installment
    Installment "1" -- "*" Payment
    ContractService ..> ContractRepository
    ContractRepository ..> DbHelper
    PaymentService ..> DbHelper
    AlertService ..> DbHelper
    AuthService ..> DbHelper
```

## 3. مخططات التتابع (Sequence Diagrams)

### 3.1 تسجيل الدخول
```mermaid
sequenceDiagram
    actor U as المستخدم
    participant L as LoginForm
    participant A as AuthService
    participant R as UserRepository
    participant DB as SQL Server
    U->>L: يُدخل اسم المستخدم وكلمة المرور
    L->>A: Login(username, password)
    A->>R: GetByUsername(username)
    R->>DB: SELECT ... WHERE Username=@u AND IsActive=1
    DB-->>R: صف المستخدم (Hash, Salt, Role)
    R-->>A: User
    A->>A: Hash(Salt + password) == PasswordHash ؟
    alt مطابقة
        A-->>L: true (CurrentUser = user)
        L->>U: فتح MainForm حسب الصلاحية
    else غير مطابقة
        A-->>L: false
        L->>U: "اسم المستخدم أو كلمة المرور غير صحيحة"
    end
```

### 3.2 إبرام عقد
```mermaid
sequenceDiagram
    actor U as الموظف
    participant F as ContractForm
    participant S as ContractService
    participant R as ContractRepository
    participant DB as SQL Server
    U->>F: يختار الوحدة الشاغرة والمستأجر ويدخل البيانات
    F->>S: PreviewInstallments(contract)
    S-->>F: قائمة الأقساط (معاينة)
    U->>F: حفظ
    F->>S: CreateContract(contract)
    S->>S: التحقق (التواريخ، المبلغ، الدورية)
    S->>R: Create(contract, CurrentUser.UserID)
    R->>DB: EXEC sp_CreateContract
    Note over DB: BEGIN TRAN<br/>INSERT Contract<br/>INSERT Installments<br/>UPDATE Unit = Rented<br/>COMMIT
    DB-->>R: @NewContractID
    R-->>S: id
    S-->>F: id
    F->>U: "تم حفظ العقد C-000012"
```

### 3.3 تسجيل دفعة
```mermaid
sequenceDiagram
    actor U as الموظف
    participant F as PaymentForm
    participant S as PaymentService
    participant DB as SQL Server
    U->>F: يبحث عن العقد ويختار القسط ويدخل المبلغ
    F->>S: RecordPayment(payment)
    S->>S: المبلغ > 0 و ≤ المتبقي؟
    S->>DB: EXEC sp_RecordPayment
    Note over DB: BEGIN TRAN<br/>INSERT Payment<br/>UPDATE Installment.PaidAmount<br/>COMMIT
    DB-->>S: PaymentID
    S-->>F: PaymentID
    F->>U: هل تريد طباعة الإيصال؟
    U->>F: نعم
    F->>S: PrintReceipt(PaymentID)
```

## 4. مخطط النشاط: دورة حياة العقد (Activity / State)

```mermaid
stateDiagram-v2
    [*] --> شاغرة
    شاغرة --> مؤجرة: إبرام عقد (sp_CreateContract)
    state مؤجرة {
        [*] --> نشط
        نشط --> نشط: تسجيل دفعات
        نشط --> قرب_الانتهاء: الأيام المتبقية ≤ أيام التنبيه
        قرب_الانتهاء --> [*]
    }
    مؤجرة --> مؤجرة: تجديد (عقد جديد لنفس الوحدة)
    مؤجرة --> شاغرة: انتهاء (Ended) أو فسخ (Terminated)
    شاغرة --> صيانة: تحويل يدوي
    صيانة --> شاغرة: انتهاء الصيانة
```

## 5. تصميم الشاشات (Screens)

> القاعدة العامة: كل النماذج `RightToLeft = Yes` و `RightToLeftLayout = true`، خط **Segoe UI** أو **Tahoma** بحجم 10–11، ألوان هادئة موحدة، وأزرار ثابتة المكان (إضافة / تعديل / حذف / حفظ / إلغاء).

| # | الشاشة | المحتوى الرئيسي | الصلاحية |
|---|---|---|---|
| 1 | **تسجيل الدخول** | اسم المستخدم، كلمة المرور، زر دخول | الجميع |
| 2 | **الرئيسية (Dashboard)** | بطاقات: عدد العقارات، الوحدات المؤجرة/الشاغرة، العقود النشطة، **المتأخرات (أحمر)**، **عقود قرب الانتهاء (برتقالي)**، المحصّل هذا الشهر + قائمة جانبية/شريط قوائم | الجميع |
| 3 | **العقارات** | DataGridView للعقارات + نموذج إدخال + زر "الوحدات" | الجميع (الحذف للمدير) |
| 4 | **الوحدات** | فلترة حسب العقار والحالة، تلوين الصفوف حسب الحالة | الجميع |
| 5 | **المستأجرون** | بحث، نموذج إدخال، تبويب "العقود" لعرض سجله | الجميع |
| 6 | **عقد جديد** | اختيار عقار ← وحدة شاغرة ← مستأجر، التواريخ، الإيجار، الدورية، التأمين، **جدول معاينة الأقساط** | الجميع |
| 7 | **العقود** | قائمة مع فلترة بالحالة، أزرار: عرض، طباعة، تجديد، إنهاء، فسخ | الإنهاء/الفسخ للمدير |
| 8 | **تسجيل دفعة** | بحث بالعقد/المستأجر ← أقساط بالمتبقي ← المبلغ والطريقة ← حفظ وطباعة إيصال | الجميع |
| 9 | **التنبيهات** | تبويبان: المتأخرات / العقود قرب الانتهاء، مع زر "تسجيل دفعة" و"تجديد" مباشرة | الجميع |
| 10 | **البحث الشامل** | مربع بحث واحد ونتائج مصنفة (مستأجر / عقد / وحدة) بالنقر المزدوج تفتح التفاصيل | الجميع |
| 11 | **التقارير** | قائمة التقارير + معايير (فترة، عقار، مستأجر) + معاينة وطباعة وتصدير PDF | الجميع |
| 12 | **المستخدمون** | إضافة، تعديل، تعطيل، إعادة تعيين كلمة المرور | المدير |
| 13 | **الإعدادات** | بيانات المكتب، أيام التنبيه، نسخ احتياطي/استعادة | المدير |

### مخطط تنقل الشاشات
```mermaid
flowchart TD
    Login[تسجيل الدخول] --> Main[الرئيسية / Dashboard]
    Main --> Props[العقارات] --> Units[الوحدات]
    Main --> Ten[المستأجرون]
    Main --> Con[العقود] --> NewC[عقد جديد]
    Con --> Pay[تسجيل دفعة]
    Main --> Alerts[التنبيهات] --> Pay
    Alerts --> Con
    Main --> Search[البحث الشامل]
    Main --> Rep[التقارير]
    Main --> UsersF[المستخدمون 🔒]
    Main --> Set[الإعدادات 🔒]
```

### رسم تقريبي (Wireframe) للشاشة الرئيسية
```
┌──────────────────────────────────────────────────────────────────┐
│  نظام إدارة العقارات والإيجارات        المستخدم: أحمد (مدير) [خروج] │
├───────────────┬──────────────────────────────────────────────────┤
│ 🏠 الرئيسية    │ ┌────────┐ ┌────────┐ ┌────────┐ ┌────────┐      │
│ 🏢 العقارات    │ │العقارات │ │ مؤجرة  │ │ شاغرة  │ │عقود نشطة│     │
│ 🚪 الوحدات     │ │   3    │ │   4    │ │   4    │ │   4    │      │
│ 👥 المستأجرون  │ └────────┘ └────────┘ └────────┘ └────────┘      │
│ 📄 العقود      │ ┌─────────────────┐ ┌──────────────────┐         │
│ 💵 الدفعات     │ │ 🔴 متأخرات: 5    │ │ 🟠 تنتهي قريباً: 1 │          │
│ 🔔 التنبيهات   │ │  3,100 د.ل       │ │                  │          │
│ 🔍 البحث       │ └─────────────────┘ └──────────────────┘         │
│ 📊 التقارير    │  آخر المتأخرات:                                   │
│ ⚙️ الإعدادات   │  ┌─────────────────────────────────────────────┐ │
│               │  │ المستأجر │ الوحدة │ الاستحقاق │ المتبقي │ أيام│ │
│               │  └─────────────────────────────────────────────┘ │
└───────────────┴──────────────────────────────────────────────────┘
```

## 6. مصفوفة الصلاحيات

| الوظيفة | المدير | الموظف |
|---|:---:|:---:|
| عرض/إضافة/تعديل العقارات والوحدات والمستأجرين | ✅ | ✅ |
| حذف العقارات والوحدات والمستأجرين | ✅ | ❌ |
| إبرام عقد / تسجيل دفعة / طباعة إيصال | ✅ | ✅ |
| إنهاء / فسخ / تجديد عقد | ✅ | ❌ |
| التنبيهات والبحث والتقارير | ✅ | ✅ |
| إدارة المستخدمين | ✅ | ❌ |
| الإعدادات والنسخ الاحتياطي | ✅ | ❌ |

**التطبيق**: في الواجهة بإخفاء/تعطيل الأزرار حسب `AuthService.CurrentUser.Role`، **وفي BLL** بفحص `AuthService.Require(UserRole.Admin)` قبل العمليات الحساسة (حماية مزدوجة).

## 7. تصميم التقارير

| # | التقرير | الحقول | المعايير | المصدر |
|---|---|---|---|---|
| 1 | العقارات والوحدات | العقار، الوحدة، النوع، المساحة، الحالة، المستأجر الحالي | العقار | `vw_UnitOccupancy` |
| 2 | الوحدات الشاغرة | العقار، الوحدة، النوع، الإيجار الافتراضي | العقار، النوع | `vw_UnitOccupancy` |
| 3 | العقود النشطة | رقم العقد، المستأجر، الوحدة، البداية، النهاية، الإيجار، الرصيد | — | `vw_ContractDetails` |
| 4 | المتأخرات | المستأجر، الهاتف، الوحدة، الاستحقاق، المتبقي، أيام التأخير + الإجمالي | العقار | `vw_OverdueInstallments` |
| 5 | العقود قرب الانتهاء | رقم العقد، المستأجر، الهاتف، تاريخ الانتهاء، الأيام المتبقية | — | `vw_ExpiringContracts` |
| 6 | **كشف حساب مستأجر** | التاريخ، البيان، مدين، دائن، **الرصيد التراكمي** | المستأجر، العقد | `vw_TenantStatement` |
| 7 | الإيرادات المحصلة | رقم الإيصال، التاريخ، المستأجر، المبلغ، الطريقة، المستلم + الإجمالي | من/إلى | `sp_RevenueReport` |
| 8 | إيصال القبض | بيانات المكتب، رقم الإيصال، المستأجر، المبلغ رقماً وكتابةً، القسط، التوقيع | PaymentID | جدول Payments |
| 9 | نموذج العقد | بيانات الطرفين، الوحدة، المدة، القيمة، جدول الأقساط، البنود | ContractID | `vw_ContractDetails` + Installments |

**أداة التقارير المقترحة**: **RDLC (Microsoft ReportViewer)** — مجانية، تدعم العربية والتصدير إلى PDF/Excel، وتُصمم داخل Visual Studio بإضافة *Microsoft RDLC Report Designer*.
بديل أبسط: `PrintDocument` + `PrintPreviewDialog` لرسم الإيصال يدوياً.
