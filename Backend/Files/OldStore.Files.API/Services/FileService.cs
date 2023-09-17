using OldStore.Files.API.Models;
using OldStore.Files.API.Repositories;

namespace OldStore.Files.API.Services;

public class FileService : IFileService
{
    private IFileRepository _fileRepository;

    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public DbFileInfo? GetFileInfoById(Guid id)
    {
        var file = _fileRepository.GetFileById(id);

        if (file is null)
        {
            return null;
        }

        return new() { FileName = file.Name, ContentType = "multipart/form-data", FilePath = file.Path };
    }
}