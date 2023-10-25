public interface IStorageFileService
{
    public Task<IAsyncResult> StoreFile(IFormFile file, string name);
    public byte[] RetrieveFile(string name);
}