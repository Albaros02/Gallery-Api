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
    public async Task<IAsyncResult> Create(PictureDto dto)
    {
        Picture picture = new Picture(dto);
        await _storageService.StoreFile(dto.picture,picture.PicturePathInPersistence!);
        await _dataBaseContext.PicturesDbSet!.AddAsync(picture);
        await _dataBaseContext.SaveChangesAsync();
        return Task.CompletedTask;   
    }
    public async Task<IAsyncResult> Delete(int id)
    {
        var picture = this.Get(id);
        if(picture is not null)
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
    public IEnumerable<Picture> GetAll()
    {
        return _dataBaseContext.PicturesDbSet!;
    }
    public byte[] RetrievePicture(string name)
    {
        return _storageService.RetrieveFile(name);
    }
    public async Task<IAsyncResult> Update(int id, PictureDto newDto)
    {
        var newPicture = new Picture(newDto);
        newPicture.Id = id;
        await _storageService.StoreFile(newDto.picture,newPicture.PicturePathInPersistence!);
        _dataBaseContext.PicturesDbSet!.Update(newPicture);
        await _dataBaseContext.SaveChangesAsync();
        return Task.CompletedTask;
    }

}