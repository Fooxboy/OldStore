using OldStore.Files.API.Database;
using OldStore.Files.API.Models;
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

    public async Task<File?> AddFile(File file)
    {
        var dbFile = _dbContext.Files.Add(file);
        await _dbContext.SaveChangesAsync();

        return dbFile.Entity;
    }

    public FileAuthor? GetFileAuthor(int userId)
    {
        return _dbContext.FileAuthors.FirstOrDefault(a => a.UserId == userId);
    }
}