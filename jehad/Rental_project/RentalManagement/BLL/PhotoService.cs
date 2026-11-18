using System.Drawing.Imaging;
using RentalManagement.DAL;

namespace RentalManagement.BLL;

/// <summary>إضافة صور العقارات والوحدات وحذفها: تُصغَّر الصورة قبل الحفظ حتى لا يكبر حجم القاعدة.</summary>
public static class PhotoService
{
    private const int MaxSide = 1600;                 // أقصى طول أو عرض للصورة المحفوظة
    private const int MaxBytes = 2 * 1024 * 1024;     // نفس قيد القاعدة CK_Photo_Size

    /// <summary>يضيف صورة من ملف لعقار أو وحدة (أحدهما فقط). يرجع رقم الصورة.</summary>
    public static int Add(int? propertyId, int? unitId, string file)
    {
        Session.Demand(Session.CanOperate);
        if ((propertyId is null) == (unitId is null)) throw new AppException("الصورة تخص عقاراً أو وحدة.");
        byte[] data = Prepare(file);
        int id = PhotoDal.Insert(propertyId, unitId, data, Path.GetFileNameWithoutExtension(file));
        AuditDal.Log("AddPhoto", propertyId is null ? "Unit" : "Property", propertyId ?? unitId, Path.GetFileName(file));
        return id;
    }

    public static void Delete(int photoId)
    {
        Session.Demand(Session.CanOperate);
        PhotoDal.Delete(photoId);
        AuditDal.Log("DeletePhoto", "Photo", photoId, null);
    }

    /// <summary>يقرأ الصورة ويصغّرها إلى 1600 بكسل كحد أقصى ويحفظها JPEG (يقلّ الجودة إن زاد الحجم عن 2 ميغابايت).</summary>
    private static byte[] Prepare(string file)
    {
        Image src;
        try { src = Image.FromFile(file); }
        catch (Exception ex) when (ex is OutOfMemoryException or ArgumentException or IOException)
        {
            throw new AppException($"الملف «{Path.GetFileName(file)}» ليس صورة صالحة.");
        }
        using (src)
        {
            double scale = Math.Min(1.0, MaxSide / (double)Math.Max(src.Width, src.Height));
            int w = Math.Max(1, (int)(src.Width * scale)), h = Math.Max(1, (int)(src.Height * scale));
            using var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);
                g.DrawImage(src, 0, 0, w, h);
            }
            var jpeg = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
            foreach (long quality in new long[] { 85, 70, 55, 40 })
            {
                using var ms = new MemoryStream();
                using var prm = new EncoderParameters(1);
                prm.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                bmp.Save(ms, jpeg, prm);
                if (ms.Length <= MaxBytes) return ms.ToArray();
            }
            throw new AppException("الصورة كبيرة جداً حتى بعد تصغيرها.");
        }
    }
}
