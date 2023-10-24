using  GalleryApi.Data;
interface IPictureRepository<DTO, Entity> : IRepository<DTO, Entity>
{
    public byte[] RetrievePicture(string name);
}