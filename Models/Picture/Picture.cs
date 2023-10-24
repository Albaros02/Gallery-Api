public class Picture : BaseDomainModel
{
    public Picture(){}
    public Picture(PictureDto dto, string userName)
    {
        this.Album = dto.Album;
        this.Description = dto.Description;
        this.URL = dto.URL;
        this.ContentType = dto.picture.ContentType;
        var name = Guid.NewGuid().ToString();
        this.PicturePathInPersistence = name;
        this.UserName = userName;
    }
    public string? UserName { get; set; }
    public string? Description { get; set; }
    public string? URL { get; set; }
    public string? Album  { get; set; }
    public string? PicturePathInPersistence { get; set; }
    public string? ContentType { get; set; }
}