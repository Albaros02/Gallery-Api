public class Picture : BaseDomainModel
{
    public Picture(){}
    public Picture(PictureDto dto)
    {
        this.Album = dto.Album;
        this.Description = dto.Description;
        this.URL = dto.URL;
        var name = Guid.NewGuid().ToString();
        this.PicturePathInPersistence = name;
    }
    public string? Description { get; set; }
    public string? URL { get; set; }
    public string? Album  { get; set; }
    public string? PicturePathInPersistence { get; set; }
}