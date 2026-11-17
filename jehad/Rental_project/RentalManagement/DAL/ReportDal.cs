namespace RentalManagement.DAL;

/// <summary>استعلامات الإحصائيات والتقارير.</summary>
public static class ReportDal
{
    /// <summary>أرقام الشاشة الرئيسية والتقرير الإحصائي العام.</summary>
    public static DataRow Stats(int alertDays) => Db.Row(@"
        DECLARE @today DATE = CAST(SYSDATETIME() AS DATE);
        DECLARE @month DATE = DATEFROMPARTS(YEAR(@today), MONTH(@today), 1);
        SELECT
            (SELECT COUNT(*) FROM dbo.Property WHERE IsActive = 1)                          AS Properties,
            (SELECT COUNT(*) FROM dbo.Unit)                                                 AS Units,
            (SELECT COUNT(*) FROM dbo.Unit WHERE Status = N'Rented')                        AS Rented,
            (SELECT COUNT(*) FROM dbo.Unit WHERE Status = N'Vacant')                        AS Vacant,
            (SELECT COUNT(*) FROM dbo.Unit WHERE Status = N'Maintenance')                   AS Maintenance,
            (SELECT COUNT(*) FROM dbo.Tenant WHERE IsActive = 1)                            AS Tenants,
            (SELECT COUNT(*) FROM dbo.Contract WHERE Status = N'Active')                    AS ActiveContracts,
            (SELECT COUNT(*) FROM dbo.vw_OverdueInstallments)                               AS OverdueCount,
            (SELECT ISNULL(SUM(Remaining), 0) FROM dbo.vw_OverdueInstallments)              AS OverdueAmount,
            (SELECT COUNT(DISTINCT TenantId) FROM dbo.vw_OverdueInstallments)               AS LateTenants,
            (SELECT COUNT(*) FROM dbo.vw_ContractSummary WHERE Status = N'Active' AND DaysLeft BETWEEN 0 AND @d) AS Expiring,
            (SELECT COUNT(*) FROM dbo.vw_ContractSummary WHERE Status = N'Active' AND DaysLeft < 0)              AS ExpiredOpen,
            (SELECT ISNULL(SUM(Amount), 0) FROM dbo.Payment WHERE IsCancelled = 0 AND PaymentDate >= @month)     AS CollectedMonth,
            (SELECT ISNULL(SUM(Amount), 0) FROM dbo.Payment WHERE IsCancelled = 0 AND YEAR(PaymentDate) = YEAR(@today)) AS CollectedYear,
            (SELECT ISNULL(SUM(i.Amount - i.PaidAmount), 0) FROM dbo.Installment i
               JOIN dbo.Contract c ON c.ContractId = i.ContractId
               WHERE c.Status = N'Active' AND i.DueDate >= @today AND i.DueDate < DATEADD(MONTH, 1, @month)) AS DueRestOfMonth,
            (SELECT ISNULL(SUM(MonthlyRent), 0) FROM dbo.Contract WHERE Status = N'Active') AS MonthlyIncome",
        Db.P("@d", alertDays))!;

    /// <summary>التحصيل الشهري لآخر عدد من الأشهر (للرسم البياني في الشاشة الرئيسية).</summary>
    public static List<(DateTime Month, decimal Amount)> MonthlyCollections(int months)
    {
        var t = Db.Query(@"
            DECLARE @first DATE = DATEADD(MONTH, 1 - @n, DATEFROMPARTS(YEAR(SYSDATETIME()), MONTH(SYSDATETIME()), 1));
            SELECT DATEFROMPARTS(YEAR(PaymentDate), MONTH(PaymentDate), 1) AS M, SUM(Amount) AS A
            FROM dbo.Payment WHERE IsCancelled = 0 AND PaymentDate >= @first
            GROUP BY DATEFROMPARTS(YEAR(PaymentDate), MONTH(PaymentDate), 1)", Db.P("@n", months));
        var map = t.AsEnumerable().ToDictionary(r => (DateTime)r["M"], r => (decimal)r["A"]);
        var start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1 - months);
        return Enumerable.Range(0, months).Select(i => start.AddMonths(i))
            .Select(m => (m, map.GetValueOrDefault(m))).ToList();
    }

    /// <summary>ملخص التحصيل حسب العقار خلال فترة: المستحق، المحصّل، المتأخر.</summary>
    public static DataTable CollectionByProperty(DateTime from, DateTime to) => Db.Query(@"
        SELECT p.Name AS [العقار],
               (SELECT COUNT(*) FROM dbo.Unit u WHERE u.PropertyId = p.PropertyId) AS [الوحدات],
               (SELECT COUNT(*) FROM dbo.Unit u WHERE u.PropertyId = p.PropertyId AND u.Status = N'Rented') AS [المؤجرة],
               ISNULL((SELECT SUM(i.Amount) FROM dbo.Installment i JOIN dbo.Contract c ON c.ContractId = i.ContractId
                       JOIN dbo.Unit u ON u.UnitId = c.UnitId
                       WHERE u.PropertyId = p.PropertyId AND i.DueDate BETWEEN @from AND @to), 0) AS [المستحق في الفترة],
               ISNULL((SELECT SUM(pay.Amount) FROM dbo.Payment pay JOIN dbo.Installment i ON i.InstallmentId = pay.InstallmentId
                       JOIN dbo.Contract c ON c.ContractId = i.ContractId JOIN dbo.Unit u ON u.UnitId = c.UnitId
                       WHERE u.PropertyId = p.PropertyId AND pay.IsCancelled = 0 AND pay.PaymentDate BETWEEN @from AND @to), 0) AS [المحصّل في الفترة],
               ISNULL((SELECT SUM(o.Remaining) FROM dbo.vw_OverdueInstallments o WHERE o.PropertyId = p.PropertyId), 0) AS [المتأخرات الحالية]
        FROM dbo.Property p
        ORDER BY p.Name", Db.P("@from", from.Date), Db.P("@to", to.Date));

    /// <summary>كشف حساب مستأجر: الأقساط (مدين) والدفعات (دائن) مرتبة بالتاريخ مع الرصيد التراكمي.</summary>
    public static DataTable TenantStatement(int tenantId, int? contractId)
    {
        var t = Db.Query(@"
            SELECT x.TxDate AS [التاريخ], x.ContractNo AS [رقم العقد], x.Description AS [البيان],
                   x.Debit AS [مدين (مستحق)], x.Credit AS [دائن (مدفوع)], CAST(0 AS DECIMAL(18,3)) AS [الرصيد]
            FROM (
                SELECT i.DueDate AS TxDate, c.ContractNo, N'قسط رقم ' + CAST(i.InstallmentNo AS NVARCHAR(10)) AS Description,
                       i.Amount AS Debit, CAST(0 AS DECIMAL(18,3)) AS Credit, 1 AS Ord, i.InstallmentId AS Ref
                FROM dbo.Installment i JOIN dbo.Contract c ON c.ContractId = i.ContractId
                WHERE c.TenantId = @t AND (@c IS NULL OR c.ContractId = @c) AND i.DueDate <= CAST(SYSDATETIME() AS DATE)
                UNION ALL
                SELECT pay.PaymentDate, c.ContractNo,
                       N'دفعة - إيصال ' + pay.ReceiptNo + N' (قسط ' + CAST(i.InstallmentNo AS NVARCHAR(10)) + N')',
                       0, pay.Amount, 2, pay.PaymentId
                FROM dbo.Payment pay JOIN dbo.Installment i ON i.InstallmentId = pay.InstallmentId
                JOIN dbo.Contract c ON c.ContractId = i.ContractId
                WHERE c.TenantId = @t AND (@c IS NULL OR c.ContractId = @c) AND pay.IsCancelled = 0
            ) x
            ORDER BY x.TxDate, x.Ord, x.Ref", Db.P("@t", tenantId), Db.P("@c", contractId));
        decimal balance = 0;
        foreach (DataRow r in t.Rows)
        {
            balance += (decimal)r[3] - (decimal)r[4];
            r[5] = balance;
        }
        return t;
    }
}

/// <summary>قوائم منسدلة للتقارير والمرشحات.</summary>
public static class ReportLists
{
    public static DataTable Users() =>
        Db.Query("SELECT UserId AS Id, FullName + N' (' + Username + N')' AS Name FROM dbo.[User] ORDER BY FullName");
}
