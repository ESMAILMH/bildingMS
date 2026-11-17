namespace RentalManagement.Common;

/// <summary>
/// تفقيط المبالغ: كتابة المبلغ بالحروف العربية في إيصال القبض، مثل:
/// 1250.500 ← "فقط ألف ومائتان وخمسون دينار ليبي و500 درهم لا غير".
/// </summary>
public static class ArabicNumber
{
    private static readonly string[] Ones =
    {
        "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", "عشرة",
        "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر"
    };

    private static readonly string[] Tens = { "", "", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };

    private static readonly string[] Hundreds =
        { "", "مائة", "مائتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };

    /// <summary>عدد من 0 إلى 999.</summary>
    private static string Group(int n)
    {
        var parts = new List<string>();
        if (n >= 100) parts.Add(Hundreds[n / 100]);
        int r = n % 100;
        if (r is > 0 and < 20) parts.Add(Ones[r]);
        else if (r >= 20) parts.Add(r % 10 == 0 ? Tens[r / 10] : $"{Ones[r % 10]} و{Tens[r / 10]}");
        return string.Join(" و", parts);
    }

    /// <summary>ألف/ألفان/آلاف أو مليون/مليونان/ملايين حسب العدد.</summary>
    private static string Scale(int n, string one, string two, string plural)
    {
        if (n == 1) return one;
        if (n == 2) return two;
        if (n is >= 3 and <= 10) return $"{Group(n)} {plural}";
        return $"{Group(n)} {one}";
    }

    public static string ToWords(long n)
    {
        if (n == 0) return "صفر";
        var parts = new List<string>();
        int millions = (int)(n / 1_000_000 % 1000), thousands = (int)(n / 1000 % 1000), rest = (int)(n % 1000);
        if (n >= 1_000_000_000) parts.Add(Scale((int)(n / 1_000_000_000), "مليار", "ملياران", "مليارات"));
        if (millions > 0) parts.Add(Scale(millions, "مليون", "مليونان", "ملايين"));
        if (thousands > 0) parts.Add(Scale(thousands, "ألف", "ألفان", "آلاف"));
        if (rest > 0) parts.Add(Group(rest));
        return string.Join(" و", parts);
    }

    /// <summary>المبلغ بالدينار الليبي والدرهم (الدينار = 1000 درهم).</summary>
    public static string Money(decimal amount)
    {
        amount = Math.Round(Math.Abs(amount), 3);
        long dinars = (long)Math.Floor(amount);
        int dirhams = (int)Math.Round((amount - dinars) * 1000);
        string text = dinars switch
        {
            0 => "",
            1 => "دينار ليبي واحد",
            2 => "ديناران ليبيان",
            _ when dinars % 100 is >= 3 and <= 10 => ToWords(dinars) + " دنانير ليبية",   // ثلاثة دنانير ... عشرة دنانير
            _ => ToWords(dinars) + " دينار ليبي"
        };
        if (dirhams > 0) text += (text.Length > 0 ? " و" : "") + $"{dirhams} درهم";
        return $"فقط {text} لا غير";
    }
}
