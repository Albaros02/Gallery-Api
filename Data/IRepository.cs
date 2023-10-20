namespace GalleryApi.Data;
public interface IRepository<T>
{
    public IAsyncResult Create(T entity);
    public IAsyncResult Delete(int id);
    public IAsyncResult Update(int id,T newEntity);
    public T Get(int id);
    public IEnumerable<T> GetAll();
}