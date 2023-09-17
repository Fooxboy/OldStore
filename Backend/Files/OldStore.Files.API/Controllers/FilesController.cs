using Microsoft.AspNetCore.Mvc;
using OldStore.Files.API.Models;
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

    [HttpPost("game/upload")]
    public async Task<IActionResult> UploadFile(IFormFile file, int gameId)
    {
        if (file.FileName.Length > 300) return BadRequest();
        
        var extension = file.FileName.Split(".").LastOrDefault();

        if (extension is null) return BadRequest();

        var guidFile = await _fileService.SaveFile(file, gameId, 1);

        return Json(new FileUploadResult() { FileId = guidFile });
    }
}