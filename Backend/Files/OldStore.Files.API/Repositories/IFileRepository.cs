using OldStore.Files.API.Models;

namespace OldStore.Files.API.Repositories;

public interface IFileRepository
{
    public Models.File? GetFileById(Guid id);

    public Task<Models.File?> AddFile(Models.File file);

    public FileAuthor? GetFileAuthor(int userId);
}