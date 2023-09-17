namespace OldStore.Files.API.Repositories;

public interface IFileRepository
{
    public Models.File? GetFileById(Guid id);
}