using System.ComponentModel.DataAnnotations;

namespace OldStore.Files.API.Models;

public class FileAuthor
{
    [Key]
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public DateTime FirstUploadAt { get; set; }
    
    public List<File> Files { get; set; }
}