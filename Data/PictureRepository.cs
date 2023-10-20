using GalleryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

class PictureRepository : IRepository<PictureDto, Picture>
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
        await dataBaseContext.PicturesDbSet.AddAsync(picture);
        await dataBaseContext.SaveChangesAsync();
        return Task.CompletedTask;   
    }
    private async Task<IAsyncResult> SavePicture(IFormFile file, string name)
    {
        var stream = new FileStream(RootPath+"/"+name,FileMode.Create);
        await file.CopyToAsync(stream);
        return Task.CompletedTask;
    }
    // private async Task<IAsyncResult> RetrievePicture(IFormFile file, string name)
    // {
        
    // }

    public async Task<IAsyncResult> Delete(int id)
    {
        var picture = this.Get(id);
        if(picture is not null)
        {
            dataBaseContext.PicturesDbSet.Remove(picture);
            await dataBaseContext.SaveChangesAsync();
        }
        return Task.CompletedTask;
    }

    public Picture? Get(int id)
    {
        var result = dataBaseContext.PicturesDbSet.FirstOrDefault(x => x.Id == id);
        if(result is not null)
            return result;
        return null;
    }

    public IEnumerable<Picture> GetAll()
    {
        return dataBaseContext.PicturesDbSet;
    }

    public Task<IAsyncResult> Update(int id, PictureDto newDto)
    {
        throw new NotImplementedException();
    }
}