namespace Playground.API.Core.Application.DTOs;

public record GenerateDummyFileRequest
{
    public required string FileName { get; set; }
}