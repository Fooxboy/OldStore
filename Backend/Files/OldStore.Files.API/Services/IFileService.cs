using OldStore.Files.API.Models;

namespace OldStore.Files.API.Services;

public interface IFileService
{
    public DbFileInfo? GetFileInfoById(Guid id);

    public Task<Guid?> SaveFile(IFormFile file, int gameId, int userId);
}