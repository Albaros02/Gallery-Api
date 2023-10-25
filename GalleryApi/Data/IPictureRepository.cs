using  GalleryApi.Data;
public interface IPictureRepository<DTO, Entity> : IRepository<DTO, Entity>
{
    public byte[] RetrievePicture(string name);
}