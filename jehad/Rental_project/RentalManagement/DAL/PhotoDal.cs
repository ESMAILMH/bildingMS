namespace RentalManagement.DAL;

/// <summary>صور العقارات والوحدات (Photo).</summary>
public static class PhotoDal
{
    /// <summary>صور عقار أو وحدة (يُمرَّر أحدهما فقط) مع بيانات الصورة.</summary>
    public static DataTable List(int? propertyId, int? unitId) => Db.Query(@"
        SELECT ph.PhotoId AS Id, ph.Image, ph.Caption, ph.CreatedAt, u.FullName AS AddedBy
        FROM dbo.Photo ph JOIN dbo.[User] u ON u.UserId = ph.CreatedBy
        WHERE (@p IS NOT NULL AND ph.PropertyId = @p) OR (@u IS NOT NULL AND ph.UnitId = @u)
        ORDER BY ph.PhotoId", Db.P("@p", propertyId), Db.P("@u", unitId));

    public static int Insert(int? propertyId, int? unitId, byte[] image, string? caption) =>
        Convert.ToInt32(Db.Scalar(@"
            INSERT dbo.Photo (PropertyId, UnitId, Image, Caption, CreatedBy)
            OUTPUT INSERTED.PhotoId VALUES (@p, @u, @img, @c, @by)",
            Db.P("@p", propertyId), Db.P("@u", unitId), Db.Binary("@img", image), Db.P("@c", caption), Db.P("@by", Session.UserId)));

    public static void Delete(int photoId) =>
        Db.Execute("DELETE FROM dbo.Photo WHERE PhotoId = @id", Db.P("@id", photoId));

    /// <summary>أول صورة للوحدة (تُطبع في أعلى نموذج العقد)، أو null.</summary>
    public static byte[]? FirstUnitImage(int unitId) =>
        Db.Scalar("SELECT TOP 1 Image FROM dbo.Photo WHERE UnitId = @u ORDER BY PhotoId", Db.P("@u", unitId)) as byte[];
}
