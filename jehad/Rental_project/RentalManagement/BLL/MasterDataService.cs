using RentalManagement.DAL;

namespace RentalManagement.BLL;

/// <summary>البيانات الأساسية: العقارات والوحدات والمستأجرون. لا حذف نهائي، بل تعطيل.</summary>
public static class MasterDataService
{
    private static string Required(string? value, string field) =>
        string.IsNullOrWhiteSpace(value) ? throw new AppException($"الرجاء إدخال {field}.") : value.Trim();

    private static string? Optional(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    // ------------------------------------------------------------ العقارات
    public static void SaveProperty(int? id, string name, string? type, string city, string? address, string? notes, bool active)
    {
        Session.Demand(Session.CanOperate);
        if (string.IsNullOrWhiteSpace(type)) throw new AppException("الرجاء اختيار نوع العقار.");
        if (id is not null && !active && PropertyDal.RentedUnits(id.Value) > 0)
            throw new AppException("لا يمكن تعطيل عقار فيه وحدات مؤجرة. أنهِ عقودها أولاً.");
        int savedId = PropertyDal.SaveProperty(id, Required(name, "اسم العقار"), type, Required(city, "المدينة"),
            Optional(address), Optional(notes), active);
        AuditDal.Log(id is null ? "AddProperty" : "EditProperty", "Property", savedId, name);
    }

    // ------------------------------------------------------------ الوحدات
    /// <summary>
    /// حالة "مؤجرة" لا تُختار يدوياً: يضبطها النظام عند إبرام العقد وإنهائه (FR-14).
    /// المستخدم يختار فقط بين "شاغرة" و"تحت الصيانة" للوحدة غير المؤجرة.
    /// </summary>
    public static void SaveUnit(int? id, int? propertyId, string unitNo, string? type, int? floor, decimal? area, int? rooms,
                                decimal rent, bool maintenance, string? notes)
    {
        Session.Demand(Session.CanOperate);
        if (propertyId is null) throw new AppException("الرجاء اختيار العقار.");
        if (string.IsNullOrWhiteSpace(type)) throw new AppException("الرجاء اختيار نوع الوحدة.");
        if (rent < 0) throw new AppException("قيمة الإيجار لا يمكن أن تكون سالبة.");
        if (area is <= 0) area = null;

        string status = maintenance ? "Maintenance" : "Vacant";
        if (id is not null)
        {
            var current = PropertyDal.Unit(id.Value) ?? throw new AppException("الوحدة غير موجودة.");
            if ((string)current["Status"] == "Rented")
            {
                if (maintenance) throw new AppException("لا يمكن تحويل وحدة مؤجرة إلى الصيانة قبل إنهاء عقدها.");
                if ((int)current["PropertyId"] != propertyId) throw new AppException("لا يمكن نقل وحدة مؤجرة إلى عقار آخر.");
                status = "Rented";
            }
        }
        int savedId = PropertyDal.SaveUnit(id, propertyId.Value, Required(unitNo, "رقم الوحدة"), type, floor, area, rooms,
            rent, status, Optional(notes));
        AuditDal.Log(id is null ? "AddUnit" : "EditUnit", "Unit", savedId, unitNo);
    }

    // ------------------------------------------------------------ المستأجرون
    public static void SaveTenant(int? id, string fullName, string nationalId, string phone, string? phone2, string? email,
                                  string? address, string? notes, bool active)
    {
        Session.Demand(Session.CanOperate);
        if (id is not null && !active && TenantDal.ActiveContracts(id.Value) > 0)
            throw new AppException("لا يمكن تعطيل مستأجر لديه عقد نشط.");
        if (Optional(email) is { } e && !e.Contains('@')) throw new AppException("البريد الإلكتروني غير صحيح.");
        int savedId = TenantDal.SaveTenant(id, Required(fullName, "اسم المستأجر"), Required(nationalId, "الرقم الوطني أو رقم السجل"),
            Required(phone, "رقم الهاتف"), Optional(phone2), Optional(email), Optional(address), Optional(notes), active);
        AuditDal.Log(id is null ? "AddTenant" : "EditTenant", "Tenant", savedId, fullName);
    }
}
