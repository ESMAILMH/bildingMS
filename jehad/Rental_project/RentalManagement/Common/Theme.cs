namespace RentalManagement.Common;

/// <summary>ألوان وخطوط موحدة لواجهة التطبيق.</summary>
public static class Theme
{
    public static readonly Color Primary = Color.FromArgb(85, 107, 47);
    public static readonly Color PrimaryDark = Color.FromArgb(62, 78, 33);
    public static readonly Color Sidebar = Color.FromArgb(44, 56, 30);
    public static readonly Color SidebarHover = Color.FromArgb(60, 76, 40);
    public static readonly Color SidebarActive = Color.FromArgb(85, 107, 47);
    public static readonly Color Background = Color.FromArgb(246, 244, 236);
    public static readonly Color Surface = Color.White;
    public static readonly Color Border = Color.FromArgb(221, 216, 196);
    public static readonly Color Text = Color.FromArgb(40, 40, 30);
    public static readonly Color MutedText = Color.FromArgb(122, 118, 100);
    public static readonly Color Success = Color.FromArgb(62, 125, 58);
    public static readonly Color Danger = Color.FromArgb(166, 61, 47);
    public static readonly Color Warning = Color.FromArgb(201, 149, 43);
    public static readonly Color Info = Color.FromArgb(70, 110, 120);
    public static readonly Color Neutral = Color.FromArgb(122, 118, 100);
    public static readonly Color GridAlt = Color.FromArgb(251, 250, 244);

    public const string FontName = "Tajawal";
    public static readonly Font Base = new(FontName, 10F);
    public static readonly Font Bold = new(FontName, 10F, FontStyle.Bold);
    public static readonly Font Small = new(FontName, 9F);
    public static readonly Font Title = new(FontName, 16F, FontStyle.Bold);
    public static readonly Font Subtitle = new(FontName, 12F, FontStyle.Bold);
    public static readonly Font CardValue = new(FontName, 20F, FontStyle.Bold);
}
