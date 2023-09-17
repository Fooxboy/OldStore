using OldStore.Files.API.Models;

namespace OldStore.Files.API.Services;

public interface IFileService
{
    public DbFileInfo? GetFileInfoById(Guid id);
}