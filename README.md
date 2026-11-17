# نظام إدارة العقارات والإيجارات (bildingMS)

**مشروع تخرج – كلية التقنيات الهندسية / يفرن – قسم تقنية المعلومات**

> تصميم وتنفيذ نظام إلكتروني لإدارة العقارات والإيجارات وتتبع دفعات المستأجرين باستخدام C# وSQL Server

## ⭐ المشروع النهائي: مجلد [`jehad/`](jehad)

| المسار | المحتوى |
|---|---|
| [`jehad/Rental_project/`](jehad/Rental_project) | الكود الكامل (Visual Studio 2022 / .NET 8 WinForms) + سكربتات قاعدة البيانات — راجع [README](jehad/Rental_project/README.md) |
| `jehad/كتاب_مشروع_إدارة_العقارات.docx` | كتاب مشروع التخرج (5 أبواب، 23 شكلاً، 23 جدولاً) بنفس تنسيق كتاب مشروع حصر الأصول |
| [`jehad/diagrams/`](jehad/diagrams) | المخططات بصيغة PNG (المعمارية، حالات الاستخدام، النشاط، الحالة، ERD، الفئات، السياق، التنقل) |

> لتنزيله على سطح المكتب باسم `jehad`:
> `git clone -b claude/property-rental-management-system-r72547 https://github.com/ESMAILMH/bildingMS.git C:\Users\thinkpad\Desktop\jehad_repo`
> ثم انسخ محتوى المجلد `jehad` إلى `C:\Users\thinkpad\Desktop\jehad`.

## وثائق التخطيط (المرحلة الأولى)

| الملف | المحتوى |
|---|---|
| [`docs/00_Roadmap.md`](docs/00_Roadmap.md) | خارطة الطريق: جميع مراحل بناء النظام بالترتيب مع الجدول الزمني |
| [`docs/01_Requirements_Analysis.md`](docs/01_Requirements_Analysis.md) | تحليل المتطلبات: الفاعلون، المتطلبات الوظيفية وغير الوظيفية، حالات الاستخدام، قواعد العمل |
| [`docs/02_Database_Design.md`](docs/02_Database_Design.md) | تصميم قاعدة البيانات: مخطط ERD، الجداول والحقول والقيود، التطبيع |
| [`docs/03_System_Design.md`](docs/03_System_Design.md) | تصميم النظام: المعمارية ثلاثية الطبقات، مخطط الأصناف، مخططات التتابع والنشاط، الشاشات، التقارير |
| [`docs/04_Implementation_Testing.md`](docs/04_Implementation_Testing.md) | التنفيذ والاختبار: هيكل الحل في Visual Studio، أمثلة كود ADO.NET، حالات الاختبار، هيكل كتاب المشروع |

> سكربتات قاعدة البيانات النهائية في `jehad/Rental_project/Database` (حلّت محل مسودة المرحلة الأولى).

## التقنيات

- **C# / .NET – Windows Forms** لواجهة المستخدم.
- **SQL Server** لقاعدة البيانات + **ADO.NET** للاتصال.
- **Visual Studio** و **SQL Server Management Studio (SSMS)**.
- نظام التشغيل: Windows 10 أو أحدث.
