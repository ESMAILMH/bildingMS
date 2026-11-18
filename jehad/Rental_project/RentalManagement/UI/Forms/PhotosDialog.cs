using RentalManagement.BLL;
using RentalManagement.DAL;

namespace RentalManagement.Forms;

/// <summary>
/// صور عقار أو وحدة: الصور المصغّرة في جانب، والصورة المختارة كبيرة في الجانب الآخر.
/// إضافة عدة صور دفعة واحدة، وحذف الصورة المختارة، وحفظ نسخة منها على الجهاز.
/// </summary>
public partial class PhotosDialog : DialogBase
{
    private readonly int? _propertyId, _unitId;
    private readonly List<(int Id, Image Image, string Caption)> _photos = new();
    private int _selected = -1;
    private bool _changed;

    public PhotosDialog(int? propertyId, int? unitId, string title)
    {
        InitializeComponent();
        _propertyId = propertyId;
        _unitId = unitId;
        SetTitle(lblHeader, "الصور — " + title);
        FormClosing += (_, _) => { if (_changed) DialogResult = DialogResult.OK; };   // لتحديث عدد الصور في الصفحة
        LoadPhotos();
    }

    private void LoadPhotos(int? selectId = null)
    {
        foreach (var p in _photos) p.Image.Dispose();
        _photos.Clear();
        foreach (DataRow r in PhotoDal.List(_propertyId, _unitId).Rows)
            if (Ui.ToImage(r["Image"] as byte[]) is { } img)
                _photos.Add(((int)r["Id"], img, $"{r["Caption"]}  —  أضافها {r["AddedBy"]} في {Ui.Format(r["CreatedAt"], r.Table.Columns["CreatedAt"]!)}"));

        flpThumbs.SuspendLayout();
        foreach (Control c in flpThumbs.Controls) c.Dispose();
        flpThumbs.Controls.Clear();
        for (int i = 0; i < _photos.Count; i++)
        {
            int index = i;
            var thumb = new PictureBox
            {
                Image = _photos[i].Image, SizeMode = PictureBoxSizeMode.Zoom, Size = new Size(130, 96),
                Margin = new Padding(4), Padding = new Padding(3), BackColor = Color.White, Cursor = Cursors.Hand
            };
            thumb.Click += (_, _) => Select(index);
            flpThumbs.Controls.Add(thumb);
        }
        flpThumbs.ResumeLayout();

        lblInfo.Text = _photos.Count == 0 ? "لا توجد صور بعد. اضغط «إضافة صور» واختر صورة أو أكثر." : $"عدد الصور: {_photos.Count}";
        int sel = selectId is { } id ? _photos.FindIndex(p => p.Id == id) : 0;
        Select(_photos.Count == 0 ? -1 : Math.Max(0, sel));
    }

    /// <summary>عرض الصورة المختارة كبيرة وتمييز مصغّرتها بإطار ذهبي.</summary>
    private void Select(int index)
    {
        _selected = index;
        picPreview.Image = index >= 0 ? _photos[index].Image : null;
        lblCaption.Text = index >= 0 ? _photos[index].Caption : "";
        for (int i = 0; i < flpThumbs.Controls.Count; i++)
            flpThumbs.Controls[i].BackColor = i == index ? Color.FromArgb(212, 175, 55) : Color.White;
        btnDelete.Enabled = btnExport.Enabled = index >= 0;
    }

    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        using var dlg = new OpenFileDialog
        {
            Title = "اختر صورة أو أكثر",
            Filter = "الصور|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
            Multiselect = true
        };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        Cursor = Cursors.WaitCursor;
        int? last = null;
        try
        {
            foreach (string f in dlg.FileNames) last = PhotoService.Add(_propertyId, _unitId, f);
        }
        finally
        {
            Cursor = Cursors.Default;
            _changed = true;
            LoadPhotos(last);
        }
    });

    private void btnDelete_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (_selected < 0 || !Ui.Confirm("هل تريد حذف هذه الصورة؟")) return;
        PhotoService.Delete(_photos[_selected].Id);
        _changed = true;
        LoadPhotos();
    });

    private void btnExport_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (_selected < 0) return;
        using var dlg = new SaveFileDialog { Filter = "صورة JPEG|*.jpg", FileName = $"صورة_{_photos[_selected].Id}.jpg" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        _photos[_selected].Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        Ui.Info("تم حفظ الصورة:\n" + dlg.FileName);
    });

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        foreach (var p in _photos) p.Image.Dispose();
        base.OnFormClosed(e);
    }
}
