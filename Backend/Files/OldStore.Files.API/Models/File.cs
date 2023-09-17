using System.ComponentModel.DataAnnotations;

namespace OldStore.Files.API.Models;

public class File
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Path { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public bool IsActive { get; set; }
    
    public FileAuthor Author { get; set; }
}