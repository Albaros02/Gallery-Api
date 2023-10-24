
// namespace GalleryApi.Data;
// public class MockPictureRepository : IRepository<PictureDto, Picture>
// {
//     const string RootPath = "./Data/PicturesPersistence";
//     private List<Picture> _data = new List<Picture>();
//     public async Task<IAsyncResult> Create(PictureDto dto)
//     {
//         Picture picture = new Picture(dto);
//         string name = picture.PicturePathInPersistence!; 
//         picture.CreatedTime = DateTime.Now;
//         await SavePicture(dto.picture,name);
//         _data.Add(picture);
//         return Task.CompletedTask;
//     }
//     private async Task<IAsyncResult> SavePicture(IFormFile file, string name)
//     {
//         var stream = new FileStream(RootPath+"/"+name,FileMode.Create);
//         await file.CopyToAsync(stream);
//         return Task.CompletedTask;
//     }

//     public Task<IAsyncResult> Delete(int id)
//     {
//         var picture = this.Get(id);
//         _data.Remove(picture);
//         return (Task<IAsyncResult>)Task.CompletedTask;
//     }

//     public Picture Get(int id)
//     {
//         var picture =  _data.FirstOrDefault( x => x.Id == id);
//         if(picture is null)
//             throw new Exception($"The id requested does not exists.");
//         return picture;
//     }

//     public IEnumerable<Picture> GetAll()
//     {
//         return _data;
//     }

//     public Task<IAsyncResult> Update(int id, PictureDto newEntity)
//     {
//         throw new NotImplementedException();
//     }
// }