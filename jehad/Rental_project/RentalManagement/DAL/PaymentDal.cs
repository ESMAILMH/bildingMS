namespace RentalManagement.DAL;

/// <summary>الدفعات وإيصالات القبض (Payment) والأقساط المتأخرة.</summary>
public static class PaymentDal
{
    private static readonly string Select = $@"
        SELECT pay.PaymentId AS Id, pay.IsCancelled, i.ContractId, c.TenantId, pay.ReceiptNo AS [رقم الإيصال],
               pay.PaymentDate AS [التاريخ], t.FullName AS [المستأجر], c.ContractNo AS [رقم العقد],
               p.Name AS [العقار], u.UnitNo AS [الوحدة], i.InstallmentNo AS [القسط], pay.Amount AS [المبلغ],
               {Labels.Sql(Labels.SqlPaymentMethod, "pay.Method")} AS [طريقة الدفع], pay.ReferenceNo AS [رقم الصك/الحوالة],
               usr.FullName AS [المستلم], CASE pay.IsCancelled WHEN 1 THEN N'ملغى' ELSE N'ساري' END AS [الحالة],
               pay.Notes AS [ملاحظات]
        FROM dbo.Payment pay
        JOIN dbo.Installment i ON i.InstallmentId = pay.InstallmentId
        JOIN dbo.Contract c    ON c.ContractId = i.ContractId
        JOIN dbo.Unit u        ON u.UnitId = c.UnitId
        JOIN dbo.Property p    ON p.PropertyId = u.PropertyId
        JOIN dbo.Tenant t      ON t.TenantId = c.TenantId
        JOIN dbo.[User] usr    ON usr.UserId = pay.ReceivedBy";

    public static DataTable Search(string? text, DateTime? from, DateTime? to, bool includeCancelled,
                                   int? propertyId = null, int? contractId = null) => Db.Query(Select + @"
        WHERE (@s IS NULL OR pay.ReceiptNo LIKE N'%' + @s + N'%' OR t.FullName LIKE N'%' + @s + N'%'
               OR c.ContractNo LIKE N'%' + @s + N'%' OR pay.ReferenceNo LIKE N'%' + @s + N'%')
          AND (@from IS NULL OR pay.PaymentDate >= @from)
          AND (@to IS NULL OR pay.PaymentDate <= @to)
          AND (@all = 1 OR pay.IsCancelled = 0)
          AND (@p IS NULL OR p.PropertyId = @p)
          AND (@c IS NULL OR c.ContractId = @c)
        ORDER BY pay.PaymentDate DESC, pay.PaymentId DESC",
        Db.P("@s", text), Db.P("@from", from?.Date), Db.P("@to", to?.Date), Db.P("@all", includeCancelled),
        Db.P("@p", propertyId), Db.P("@c", contractId));

    public static DataRow? Get(int paymentId) => Db.Row(@"
        SELECT pay.*, i.InstallmentNo, i.DueDate, i.Amount AS InstallmentAmount, i.PaidAmount AS InstallmentPaid,
               c.ContractNo, c.ContractId, t.FullName AS TenantName, t.NationalId, p.Name AS PropertyName, u.UnitNo, u.UnitType,
               usr.FullName AS ReceivedByName
        FROM dbo.Payment pay
        JOIN dbo.Installment i ON i.InstallmentId = pay.InstallmentId
        JOIN dbo.Contract c    ON c.ContractId = i.ContractId
        JOIN dbo.Unit u        ON u.UnitId = c.UnitId
        JOIN dbo.Property p    ON p.PropertyId = u.PropertyId
        JOIN dbo.Tenant t      ON t.TenantId = c.TenantId
        JOIN dbo.[User] usr    ON usr.UserId = pay.ReceivedBy
        WHERE pay.PaymentId = @id", Db.P("@id", paymentId));

    public static DataTable ReceiptList() => Db.Query(@"
        SELECT TOP (500) pay.PaymentId AS Id, pay.ReceiptNo + N' - ' + t.FullName + N' - ' + CONVERT(NVARCHAR(10), pay.PaymentDate, 111) AS Name
        FROM dbo.Payment pay
        JOIN dbo.Installment i ON i.InstallmentId = pay.InstallmentId
        JOIN dbo.Contract c ON c.ContractId = i.ContractId
        JOIN dbo.Tenant t ON t.TenantId = c.TenantId
        WHERE pay.IsCancelled = 0
        ORDER BY pay.PaymentId DESC");

    // ------------------------------------------------------------ العمليات
    public static int Record(int installmentId, decimal amount, DateTime date, string method, string? referenceNo, string? notes) =>
        Db.ProcWithId("dbo.sp_RecordPayment", "@PaymentId",
            Db.P("@InstallmentId", installmentId), Db.Money("@Amount", amount), Db.P("@Date", date.Date),
            Db.P("@Method", method), Db.P("@ReferenceNo", referenceNo), Db.P("@Notes", notes), Db.P("@UserId", Session.UserId));

    public static void Cancel(int paymentId, string reason) =>
        Db.Proc("dbo.sp_CancelPayment", Db.P("@PaymentId", paymentId), Db.P("@Reason", reason), Db.P("@ManagerId", Session.UserId));

    // ------------------------------------------------------------ المتأخرات
    public static DataTable Overdue(int? propertyId = null, int? tenantId = null) => Db.Query(@"
        SELECT o.InstallmentId AS Id, o.ContractId, o.TenantId, o.DaysLate AS DaysLateRaw,
               o.TenantName AS [المستأجر], o.TenantPhone AS [الهاتف], o.ContractNo AS [رقم العقد],
               o.PropertyName AS [العقار], o.UnitNo AS [الوحدة], o.InstallmentNo AS [القسط],
               o.DueDate AS [تاريخ الاستحقاق], o.Amount AS [المبلغ], o.PaidAmount AS [المدفوع], o.Remaining AS [المتبقي],
               o.DaysLate AS [أيام التأخير],
               CASE o.ContractStatus WHEN N'Active' THEN N'نشط' WHEN N'Ended' THEN N'منتهٍ' ELSE N'مفسوخ' END AS [حالة العقد]
        FROM dbo.vw_OverdueInstallments o
        WHERE (@p IS NULL OR o.PropertyId = @p) AND (@t IS NULL OR o.TenantId = @t)
        ORDER BY o.DaysLate DESC", Db.P("@p", propertyId), Db.P("@t", tenantId));
}
