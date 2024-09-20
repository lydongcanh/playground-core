using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.ServiceHost.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController(IFileService fileService) : ControllerBase
{
    [HttpPost]
    [Route("dummy")]
    public async Task<IActionResult> GenerateDummyFileAsync(GenerateDummyFileRequest request, CancellationToken cancellationToken)
    {
        var file = await fileService.GenerateDummyFileAsync(request, cancellationToken);
        return File(file.FileContent, MediaTypeNames.Text.Plain, file.FileName);
    }
}