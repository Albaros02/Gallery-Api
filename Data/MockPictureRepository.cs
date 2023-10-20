
namespace GalleryApi.Data;
public class MockPictureRepository : IRepository<Picture>
{
    private List<Picture> _data = new List<Picture>();
    public IAsyncResult Create(Picture entity)
    {
        _data.Add(entity);
        return Task.CompletedTask;
    }

    public IAsyncResult Delete(int id)
    {
        var picture = this.Get(id);
        _data.Remove(picture);
        return Task.CompletedTask;
    }

    public Picture Get(int id)
    {
        var picture =  _data.FirstOrDefault( x => x.Id == id);
        if(picture is null)
            throw new Exception($"The id requested does not exists.");
        return picture;
    }

    public IEnumerable<Picture> GetAll()
    {
        return _data;
    }

    public IAsyncResult Update(int id, Picture newEntity)
    {
        throw new NotImplementedException();
    }
}