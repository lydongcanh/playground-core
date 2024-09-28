namespace Playground.API.Core.Application.DTOs;

public record CreateFileRequest
{
    public required string Name { get; set; }
    public required string Base64Content { get; set; }
}