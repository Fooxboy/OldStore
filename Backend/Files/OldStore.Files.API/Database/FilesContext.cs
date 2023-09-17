using Microsoft.EntityFrameworkCore;

namespace OldStore.Files.API.Database;

public class FilesContext : DbContext
{
    public FilesContext(DbContextOptions<FilesContext> options): base(options)
    {
        
    }

    public DbSet<Models.File> Files { get; set; }
    
    public DbSet<Models.FileAuthor> FileAuthors { get; set; }
}