using OldStore.Files.API.Database;
using File = OldStore.Files.API.Models.File;

namespace OldStore.Files.API.Repositories;

public class FilesRepository : IFileRepository
{

    private readonly FilesContext _dbContext;

    public FilesRepository(FilesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public File? GetFileById(Guid id)
    {
        return _dbContext.Files.FirstOrDefault(f => f.Id == id && f.IsActive);
    }
}