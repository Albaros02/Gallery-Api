namespace GalleryApi.Data;
public interface IRepository<DTO,Entity>
{
    public Task<IAsyncResult> Create(DTO dto);
    public Task<IAsyncResult> Delete(int id);
    public Task<IAsyncResult> Update(int id,DTO newDto);
    public Entity Get(int id);
    public IEnumerable<Entity> GetAll();
}