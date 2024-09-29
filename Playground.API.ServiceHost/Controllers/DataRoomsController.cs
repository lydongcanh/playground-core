using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.ServiceHost.Controllers;

[ApiController]
[Route("[controller]")]
public class DataRoomsController(IDataRoomService dataRoomService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDataRoomAsync(CreateDataRoomRequest request, CancellationToken cancellationToken)
    {
        var id = await dataRoomService.CreateDataRoomAsync(request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPost]
    [Route("{dataRoomId:guid}/folders")]
    public async Task<IActionResult> CreateFolderAsync(Guid dataRoomId, CreateFolderRequest request, CancellationToken cancellationToken)
    {
        var id = await dataRoomService.CreateFolderAsync(dataRoomId, request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPost]
    [Route("{dataRoomId:guid}/folders/{folderId:guid}/files")]
    public async Task<IActionResult> CreateFileAsync(Guid dataRoomId, Guid folderId, CreateFileRequest request, CancellationToken cancellationToken)
    {
        var id = await dataRoomService.CreateFileAsync(dataRoomId, folderId, request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetDataRoomAsync(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await dataRoomService.GetDataRoomAsync(id, cancellationToken));
    }
    
    [HttpPost]
    [Route("dummy")]
    public async Task<IActionResult> GenerateDummyFileAsync(GenerateDummyFileRequest request, CancellationToken cancellationToken)
    {
        var file = await dataRoomService.GenerateDummyFileAsync(request, cancellationToken);
        return File(file.FileContent, MediaTypeNames.Text.Plain, file.FileName);
    }
}