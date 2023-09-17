using Microsoft.AspNetCore.Mvc;
using OldStore.Files.API.Services;

namespace OldStore.Files.API.Controllers;

public class FilesController : Controller
{
    private readonly IFileService _fileService;
    
    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet("file/{id}")]
    public async Task<IActionResult> GetFile(Guid id)
    {
        var fileInfo = _fileService.GetFileInfoById(id);

        if (fileInfo is null) return NotFound();
        
        return this.PhysicalFile(fileInfo.FilePath, fileInfo.ContentType, fileInfo.FileName);
    }
}