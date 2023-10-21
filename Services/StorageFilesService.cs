
class StorageFilesService : IStorageFileService
{
    const string RootPath = "./Data/PicturesPersistence";
    public byte[] RetrieveFile(string name)
    {
        var filePath = Path.Combine(Path.GetFullPath(RootPath), name);
        byte[] rawData = System.IO.File.ReadAllBytes(filePath);   
        return rawData;
    }
    public async Task<IAsyncResult> StoreFile(IFormFile file, string name)
    {
        var stream = new FileStream(RootPath+"/"+name,FileMode.Create);
        await file.CopyToAsync(stream);
        stream.Close();
        return Task.CompletedTask;
    }
}