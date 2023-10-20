using Microsoft.VisualBasic.FileIO;

public class FileUploadModel
{
    public IFormFile? FileDetails { get; set; }
    public FieldType FileType { get; set; }
}