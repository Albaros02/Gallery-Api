using GalleryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.FileProviders;
using Microsoft.SqlServer.Server;

class PictureRepository : IPictureRepository<PictureDto, Picture>
{
    const string RootPath = "./Data/PicturesPersistence";
    private readonly ApplicationDbContext dataBaseContext;
    public PictureRepository(ApplicationDbContext dataBaseContext)
    {
        this.dataBaseContext = dataBaseContext;
    }
    public async Task<IAsyncResult> Create(PictureDto dto)
    {
        Picture picture = new Picture(dto);
        await SavePicture(dto.picture,picture.PicturePathInPersistence!);
        await dataBaseContext.PicturesDbSet!.AddAsync(picture);
        await dataBaseContext.SaveChangesAsync();
        return Task.CompletedTask;   
    }
    public async Task<IAsyncResult> SavePicture(IFormFile file, string name)
    {
        var stream = new FileStream(RootPath+"/"+name,FileMode.Create);
        await file.CopyToAsync(stream);
        stream.Close();
        return Task.CompletedTask;
    }
    public byte[] RetrievePicture(string name)
    {
        var filePath = Path.Combine(Path.GetFullPath(RootPath), name);
        byte[] rawData = System.IO.File.ReadAllBytes(filePath);   
        return rawData;
    }

    public async Task<IAsyncResult> Delete(int id)
    {
        var picture = this.Get(id);
        if(picture is not null)
        {
            dataBaseContext.PicturesDbSet!.Remove(picture);
            await dataBaseContext.SaveChangesAsync();
        }
        return Task.CompletedTask;
    }
    public Picture Get(int id)
    {
        var result = dataBaseContext.PicturesDbSet!.FirstOrDefault(x => x.Id == id);
        if(result is not null)
            return result;
        return null!;
    }
    public IEnumerable<Picture> GetAll()
    {
        return dataBaseContext.PicturesDbSet!;
    }
    public async Task<IAsyncResult> Update(int id, PictureDto newDto)
    {
        var newPicture = new Picture(newDto);
        newPicture.Id = id;
        await SavePicture(newDto.picture,newPicture.PicturePathInPersistence!);
        dataBaseContext.PicturesDbSet!.Update(newPicture);
        await dataBaseContext.SaveChangesAsync();
        return Task.CompletedTask;
    }
}