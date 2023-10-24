namespace GalleryApi.Data;
public interface IRepository<DTO,Entity>
{
    public Task<IAsyncResult> Create(DTO dto, string userName);
    public Task<IAsyncResult> Delete(int id,string userName);
    public Task<IAsyncResult> Update(int id,DTO newDto, string name);
    public Entity Get(int id);
    public IEnumerable<Entity> GetAll(string name);
}