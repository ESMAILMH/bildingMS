# نظام إدارة العقارات والإيجارات (bildingMS)

**مشروع تخرج – كلية التقنيات الهندسية / يفرن – قسم تقنية المعلومات**

> تصميم وتنفيذ نظام إلكتروني لإدارة العقارات والإيجارات وتتبع دفعات المستأجرين باستخدام C# وSQL Server

## محتويات المستودع

| الملف | المحتوى |
|---|---|
| [`docs/00_Roadmap.md`](docs/00_Roadmap.md) | خارطة الطريق: جميع مراحل بناء النظام بالترتيب مع الجدول الزمني |
| [`docs/01_Requirements_Analysis.md`](docs/01_Requirements_Analysis.md) | تحليل المتطلبات: الفاعلون، المتطلبات الوظيفية وغير الوظيفية، حالات الاستخدام، قواعد العمل |
| [`docs/02_Database_Design.md`](docs/02_Database_Design.md) | تصميم قاعدة البيانات: مخطط ERD، الجداول والحقول والقيود، التطبيع |
| [`docs/03_System_Design.md`](docs/03_System_Design.md) | تصميم النظام: المعمارية ثلاثية الطبقات، مخطط الأصناف، مخططات التتابع والنشاط، الشاشات، التقارير |
| [`docs/04_Implementation_Testing.md`](docs/04_Implementation_Testing.md) | التنفيذ والاختبار: هيكل الحل في Visual Studio، أمثلة كود ADO.NET، حالات الاختبار، هيكل كتاب المشروع |
| [`database/01_Schema.sql`](database/01_Schema.sql) | سكربت إنشاء قاعدة البيانات كاملة (جداول، قيود، فهارس) |
| [`database/02_Views_Procedures.sql`](database/02_Views_Procedures.sql) | العروض (Views) والإجراءات المخزنة (إنشاء عقد، تسجيل دفعة، إنهاء عقد...) |
| [`database/03_Seed_Data.sql`](database/03_Seed_Data.sql) | بيانات تجريبية للاختبار والعرض أمام لجنة المناقشة |

## التقنيات

- **C# / .NET – Windows Forms** لواجهة المستخدم.
- **SQL Server** لقاعدة البيانات + **ADO.NET** للاتصال.
- **Visual Studio** و **SQL Server Management Studio (SSMS)**.
- نظام التشغيل: Windows 10 أو أحدث.

## التشغيل السريع لقاعدة البيانات

1. افتح SSMS واتصل بالخادم المحلي (`.\SQLEXPRESS` أو `(localdb)\MSSQLLocalDB`).
2. نفّذ الملفات بالترتيب: `01_Schema.sql` ← `02_Views_Procedures.sql` ← `03_Seed_Data.sql`.
3. حساب الدخول الافتراضي: **admin / Admin@123** (غيّره بعد أول دخول).
