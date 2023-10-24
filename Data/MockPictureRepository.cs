using GalleryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.FileProviders;
using Microsoft.SqlServer.Server;

class MockPictureRepository : IPictureRepository<PictureDto, Picture>
{
    private readonly IStorageFileService _storageService;
    private List<Picture> db;
    private int curr_id = 0;

    public MockPictureRepository(IStorageFileService storageService)
    {
        db = new List<Picture>();
        this._storageService = storageService;
    }
    public async Task<IAsyncResult> Create(PictureDto dto, string name)
    {
        Picture picture = new Picture(dto, name);
        await _storageService.StoreFile(dto.picture, picture.PicturePathInPersistence!);
        picture.Id = curr_id;
        curr_id ++;
        db.Add(picture);
        return Task.CompletedTask;
    }
    public async Task<IAsyncResult> Delete(int id, string userName)
    {
        var picture = this.Get(id);
        if (picture is not null && picture.UserName == userName)
        {
            db.Remove(picture);
        }
        return Task.CompletedTask;
    }
    public Picture Get(int id)
    {
        var result = db.FirstOrDefault(x => x.Id == id);
        if (result is not null)
            return result;
        return null!;
    }
    public IEnumerable<Picture> GetAll(string userName)
    {
        return db.Where(x => x.UserName == userName);
    }
    public byte[] RetrievePicture(string name)
    {
        return _storageService.RetrieveFile(name);
    }
    public async Task<IAsyncResult> Update(int id, PictureDto newDto, string name)
    {
        var newPicture = new Picture(newDto, name);
        newPicture.Id = id;
        await _storageService.StoreFile(newDto.picture, newPicture.PicturePathInPersistence!);
        db.Remove(db.Find(x => x.Id == id));
        db.Add(newPicture);
        return Task.CompletedTask;
    }

}