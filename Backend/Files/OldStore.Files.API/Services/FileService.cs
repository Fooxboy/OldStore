using OldStore.Files.API.Models;
using OldStore.Files.API.Repositories;
using File = OldStore.Files.API.Models.File;

namespace OldStore.Files.API.Services;

public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;

    private readonly IConfiguration _configuration;

    public FileService(IFileRepository fileRepository, IConfiguration configuration)
    {
        _fileRepository = fileRepository;
        _configuration = configuration;
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

    public async Task<Guid?> SaveFile(IFormFile fileBody, int gameId, int userId)
    {
        var basePath = _configuration.GetValue<string>("FilesDirectory");
        
        var extension = fileBody.FileName.Split(".").LastOrDefault();

        //todo: конвертить жепег жопы
        var dictionaryPath = Path.Combine(basePath, "Games", gameId.ToString());
        var filePath = Path.Combine(dictionaryPath, $"{Guid.NewGuid()}.{extension}");

        var fileAuthor = _fileRepository.GetFileAuthor(userId);

        if (fileAuthor is null)
        {
            fileAuthor = new FileAuthor()
            {
                FirstUploadAt = DateTime.UtcNow
            };
        }
        
        var file = new Models.File()
        {
            Name = $"{Guid.NewGuid()}.{extension}",
            Author = fileAuthor,
            Path = filePath,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
        };

        var dbFile = await _fileRepository.AddFile(file);

        if (dbFile is null)
        {
            return null;
        }

        if (!Directory.Exists(dictionaryPath))
        {
            Directory.CreateDirectory(dictionaryPath);
        }

        await using var fs = new FileStream(filePath, FileMode.Create);
        await fileBody.CopyToAsync(fs);

        return dbFile.Id;
    }
}