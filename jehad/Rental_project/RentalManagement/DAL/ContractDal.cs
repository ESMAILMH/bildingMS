namespace RentalManagement.DAL;

/// <summary>عقود الإيجار (Contract) وجدول أقساطها (Installment) عبر الإجراءات المخزنة.</summary>
public static class ContractDal
{
    private const string Select = $@"
        SELECT s.ContractId AS Id, s.Status, s.UnitId, s.TenantId, s.PropertyId, s.ContractNo AS [رقم العقد],
               s.TenantName AS [المستأجر], s.TenantPhone AS [الهاتف], s.PropertyName AS [العقار], s.UnitNo AS [الوحدة],
               s.StartDate AS [البداية], s.EndDate AS [النهاية], s.MonthlyRent AS [الإيجار الشهري],
               CASE s.PaymentCycle WHEN 1 THEN N'شهري' WHEN 3 THEN N'ربع سنوي' WHEN 6 THEN N'نصف سنوي' ELSE N'سنوي' END AS [الدفع],
               s.TotalAmount AS [قيمة العقد], s.TotalPaid AS [المدفوع], s.Balance AS [المتبقي], s.OverdueAmount AS [المتأخر],
               CASE WHEN s.Status = N'Active' THEN s.DaysLeft END AS [أيام متبقية],
               CASE s.Status WHEN N'Active' THEN N'نشط' WHEN N'Ended' THEN N'منتهٍ' ELSE N'مفسوخ' END AS [الحالة]
        FROM dbo.vw_ContractSummary s";

    public static DataTable Search(string? status, string? text, int? propertyId = null, int? tenantId = null,
                                   DateTime? from = null, DateTime? to = null) => Db.Query(Select + @"
        WHERE (@st IS NULL OR s.Status = @st)
          AND (@s IS NULL OR s.ContractNo LIKE N'%' + @s + N'%' OR s.TenantName LIKE N'%' + @s + N'%'
               OR s.PropertyName LIKE N'%' + @s + N'%' OR s.UnitNo LIKE N'%' + @s + N'%' OR s.TenantPhone LIKE N'%' + @s + N'%')
          AND (@p IS NULL OR s.PropertyId = @p)
          AND (@t IS NULL OR s.TenantId = @t)
          AND (@from IS NULL OR s.StartDate >= @from)
          AND (@to IS NULL OR s.StartDate <= @to)
        ORDER BY CASE s.Status WHEN N'Active' THEN 0 ELSE 1 END, s.EndDate",
        Db.P("@st", status), Db.P("@s", text), Db.P("@p", propertyId), Db.P("@t", tenantId),
        Db.P("@from", from?.Date), Db.P("@to", to?.Date));

    /// <summary>عدد العقود في كل حالة (لأزرار التبويب).</summary>
    public static Dictionary<string, int> CountByStatus() =>
        Db.Query("SELECT Status, COUNT(*) AS N FROM dbo.Contract GROUP BY Status")
            .AsEnumerable().ToDictionary(r => (string)r["Status"], r => (int)r["N"]);

    /// <summary>العقود النشطة التي تنتهي خلال عدد من الأيام، أو انتهت مدتها ولم تُغلق بعد (FR-23).</summary>
    public static DataTable Expiring(int days, int? propertyId = null) => Db.Query(Select + @"
        WHERE s.Status = N'Active' AND s.DaysLeft <= @d AND (@p IS NULL OR s.PropertyId = @p)
        ORDER BY s.EndDate", Db.P("@d", days), Db.P("@p", propertyId));

    public static DataRow? Get(int id) => Db.Row("SELECT * FROM dbo.vw_ContractSummary WHERE ContractId=@id", Db.P("@id", id));

    /// <summary>قائمة العقود للقوائم المنسدلة بالشكل «رقم العقد - المستأجر - العقار/الوحدة».</summary>
    public static DataTable ContractList(bool activeOnly) => Db.Query(@"
        SELECT ContractId AS Id, ContractNo + N' - ' + TenantName + N' - ' + PropertyName + N' / ' + UnitNo AS Name
        FROM dbo.vw_ContractSummary WHERE @a = 0 OR Status = N'Active'
        ORDER BY ContractId DESC", Db.P("@a", activeOnly));

    /// <summary>العقود التي عليها أقساط غير مسددة (لتسجيل دفعة).</summary>
    public static DataTable PayableContractList() => Db.Query(@"
        SELECT ContractId AS Id, ContractNo + N' - ' + TenantName + N' - ' + PropertyName + N' / ' + UnitNo AS Name
        FROM dbo.vw_ContractSummary WHERE Balance > 0
        ORDER BY CASE Status WHEN N'Active' THEN 0 ELSE 1 END, ContractId DESC");

    // ------------------------------------------------------------ العمليات (إجراءات مخزنة)
    public static int Create(int unitId, int tenantId, DateTime start, DateTime end, decimal rent, int cycle, decimal deposit,
                             string? notes) =>
        Db.ProcWithId("dbo.sp_CreateContract", "@ContractId",
            Db.P("@UnitId", unitId), Db.P("@TenantId", tenantId), Db.P("@StartDate", start.Date), Db.P("@EndDate", end.Date),
            Db.Money("@MonthlyRent", rent), Db.P("@PaymentCycle", cycle), Db.Money("@Deposit", deposit),
            Db.P("@Notes", notes), Db.P("@UserId", Session.UserId), Db.P("@RenewedFrom", null));

    public static void Close(int contractId, bool terminate, DateTime closeDate, string? reason) =>
        Db.Proc("dbo.sp_CloseContract", Db.P("@ContractId", contractId), Db.P("@Terminate", terminate),
            Db.P("@CloseDate", closeDate.Date), Db.P("@Reason", reason), Db.P("@UserId", Session.UserId));

    public static int Renew(int contractId, DateTime newEnd, decimal rent, int cycle) =>
        Db.ProcWithId("dbo.sp_RenewContract", "@NewContractId",
            Db.P("@ContractId", contractId), Db.P("@NewEndDate", newEnd.Date), Db.Money("@MonthlyRent", rent),
            Db.P("@PaymentCycle", cycle), Db.P("@UserId", Session.UserId));

    // ------------------------------------------------------------ الأقساط
    public static DataTable Installments(int contractId) => Db.Query($@"
        SELECT i.InstallmentId AS Id, i.Status, i.DueDate AS DueDateRaw, i.InstallmentNo AS [رقم القسط],
               i.DueDate AS [تاريخ الاستحقاق], i.Amount AS [المبلغ], i.PaidAmount AS [المدفوع],
               i.Amount - i.PaidAmount AS [المتبقي],
               {Labels.Sql(Labels.SqlInstallmentStatus, "i.Status")} AS [الحالة],
               CASE WHEN i.PaidAmount < i.Amount AND i.DueDate < CAST(SYSDATETIME() AS DATE)
                    THEN DATEDIFF(DAY, i.DueDate, CAST(SYSDATETIME() AS DATE)) END AS [أيام التأخير]
        FROM dbo.Installment i WHERE i.ContractId = @c ORDER BY i.InstallmentNo", Db.P("@c", contractId));

    /// <summary>الأقساط غير المسددة بالكامل لعقد (للقائمة المنسدلة في نافذة الدفع).</summary>
    public static DataTable OpenInstallmentList(int contractId) => Db.Query(@"
        SELECT InstallmentId AS Id,
               N'قسط ' + CAST(InstallmentNo AS NVARCHAR(10)) + N' — ' + CONVERT(NVARCHAR(10), DueDate, 111)
               + N' — المتبقي ' + FORMAT(Amount - PaidAmount, N'N3') AS Name,
               Amount - PaidAmount AS Remaining
        FROM dbo.Installment WHERE ContractId = @c AND PaidAmount < Amount ORDER BY InstallmentNo", Db.P("@c", contractId));
}
