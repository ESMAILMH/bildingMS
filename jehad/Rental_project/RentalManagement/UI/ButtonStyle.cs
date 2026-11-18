using System.Drawing.Drawing2D;

namespace RentalManagement.Common;

/// <summary>
/// شكل الأزرار في كل البرنامج: زوايا دائرية مرسومة بنعومة (Anti-alias).
/// - الزر الرئيسي في الشاشة (حفظ، إضافة، جديد، دخول، عرض): ممتلئ بلونه.
/// - باقي الأزرار: محددة (إطار ونص بلون الزر على خلفية فاتحة)، وتمتلئ بدرجة فاتحة من لونها عند المرور والضغط.
/// - أزرار التبويب (التي تحمل نصاً في Tag مثل "active"): كبسولة، ولونها كما تضبطه الصفحة (BackColor / ForeColor).
/// لون كل زر يبقى كما هو في المصمم (BackColor)؛ هذه الدالة تغيّر طريقة الرسم فقط.
/// </summary>
public static class ButtonStyle
{
    private const int Radius = 10;
    /// <summary>الأزرار التي طُبّق عليها الشكل (حتى لا يُطبَّق مرتين). لا نستخدم Tag لأن أزرار التبويب تعتمد عليه.</summary>
    private static readonly System.Runtime.CompilerServices.ConditionalWeakTable<Button, object> Styled = new();
    private static readonly HashSet<string> PrimaryNames = new() { "btnSave", "btnLogin", "btnAdd", "btnNew", "btnShow", "btnQuickContract" };

    /// <summary>يطبّق الشكل على كل الأزرار داخل العنصر (مرة واحدة لكل زر).</summary>
    public static void Apply(Control root)
    {
        foreach (Control c in root.Controls)
        {
            if (c is Button b && !Styled.TryGetValue(b, out _))
            {
                Styled.Add(b, true);
                Style(b, root.FindForm());
            }
            if (c.HasChildren) Apply(c);
        }
    }

    private static void Style(Button b, Form? form)
    {
        bool chip = b.Tag is string;                  // أزرار التبويب تحمل قيمة التصفية في Tag
        bool primary = !chip && (PrimaryNames.Contains(b.Name) || form?.AcceptButton == b);
        bool hover = false, pressed = false;

        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.Cursor = Cursors.Hand;
        b.MouseEnter += (_, _) => { hover = true; b.Invalidate(); };
        b.MouseLeave += (_, _) => { hover = pressed = false; b.Invalidate(); };
        b.MouseDown += (_, _) => { pressed = true; b.Invalidate(); };
        b.MouseUp += (_, _) => { pressed = false; b.Invalidate(); };
        b.EnabledChanged += (_, _) => b.Invalidate();

        b.Paint += (_, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(b.Parent?.BackColor ?? Theme.Background);   // ما حول الزوايا بلون الخلفية

            Color accent = chip ? Theme.Primary : b.BackColor;
            Color fill, border, text;
            if (chip)
            {
                fill = hover && b.BackColor != Theme.Primary ? Blend(Theme.Primary, Color.White, 0.88) : b.BackColor;
                border = Theme.Primary;
                text = b.ForeColor;
            }
            else if (primary)
            {
                fill = pressed ? ControlPaint.Dark(accent, 0.1f) : hover ? ControlPaint.Light(accent, 0.15f) : accent;
                border = fill;
                text = Color.White;
            }
            else
            {
                fill = pressed ? Blend(accent, Color.White, 0.72) : hover ? Blend(accent, Color.White, 0.84) : Theme.Surface;
                border = accent;
                text = Blend(accent, Color.Black, 0.85);
            }
            if (!b.Enabled)
            {
                fill = Blend(fill, Theme.Background, 0.45);
                border = Blend(border, Theme.Background, 0.6);
                text = Blend(text, Theme.Background, 0.55);
            }

            var rect = new RectangleF(1, 1, b.Width - 3, b.Height - 3);
            float r = chip ? rect.Height / 2 : Radius;
            using (var path = Rounded(rect, r))
            using (var brush = new SolidBrush(fill))
            using (var pen = new Pen(border, 1.6f))
            {
                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }
            var flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine |
                        TextFormatFlags.EndEllipsis | (b.RightToLeft == RightToLeft.Yes ? TextFormatFlags.RightToLeft : 0);
            TextRenderer.DrawText(g, b.Text, b.Font, Rectangle.Inflate(b.ClientRectangle, -6, 0), text, flags);
        };
        b.Invalidate();
    }

    private static GraphicsPath Rounded(RectangleF r, float radius)
    {
        float d = Math.Min(radius * 2, Math.Min(r.Width, r.Height));
        var p = new GraphicsPath();
        p.AddArc(r.X, r.Y, d, d, 180, 90);
        p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        p.CloseFigure();
        return p;
    }

    /// <summary>مزج لونين: amount = نسبة اللون الثاني (0 إلى 1).</summary>
    private static Color Blend(Color a, Color b, double amount) => Color.FromArgb(
        (int)(a.R + (b.R - a.R) * amount), (int)(a.G + (b.G - a.G) * amount), (int)(a.B + (b.B - a.B) * amount));
}
