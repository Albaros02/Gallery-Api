using GalleryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.FileProviders;
using Microsoft.SqlServer.Server;

class PictureRepository : IPictureRepository<PictureDto, Picture>
{
    private readonly ApplicationDbContext _dataBaseContext;
    private readonly IStorageFileService _storageService;
    public PictureRepository(ApplicationDbContext dataBaseContext, IStorageFileService storageService)
    {
        this._dataBaseContext = dataBaseContext;
        this._storageService = storageService;
    }
    public async Task<IAsyncResult> Create(PictureDto dto, string name)
    {
        Picture picture = new Picture(dto, name);
        await _storageService.StoreFile(dto.picture,picture.PicturePathInPersistence!);
        await _dataBaseContext.PicturesDbSet!.AddAsync(picture);
        await _dataBaseContext.SaveChangesAsync();
        return Task.CompletedTask;   
    }
    public async Task<IAsyncResult> Delete(int id, string userName)
    {
        var picture = this.Get(id);
        if(picture is not null && picture.UserName == userName)
        {
            _dataBaseContext.PicturesDbSet!.Remove(picture);
            await _dataBaseContext.SaveChangesAsync();
        }
        return Task.CompletedTask;
    }
    public Picture Get(int id)
    {
        var result = _dataBaseContext.PicturesDbSet!.FirstOrDefault(x => x.Id == id);
        if(result is not null)
            return result;
        return null!;
    }
    public IEnumerable<Picture> GetAll(string userName)
    {
        return _dataBaseContext.PicturesDbSet!.Where(x => x.UserName == userName);
    }
    public byte[] RetrievePicture(string name)
    {
        return _storageService.RetrieveFile(name);
    }
    public async Task<IAsyncResult> Update(int id, PictureDto newDto, string name)
    {
        var newPicture = new Picture(newDto,name);
        newPicture.Id = id;
        await _storageService.StoreFile(newDto.picture,newPicture.PicturePathInPersistence!);
        _dataBaseContext.PicturesDbSet!.Update(newPicture);
        await _dataBaseContext.SaveChangesAsync();
        return Task.CompletedTask;
    }

}