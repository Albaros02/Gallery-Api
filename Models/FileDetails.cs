using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.FileIO;

[Table("FileDetails")]
public class FileDetails
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? FileName { get; set; }
    public byte[]? FileData { get; set; }
    public FieldType FileType { get; set; }
}