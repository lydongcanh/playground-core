namespace Playground.API.Core.Application.DTOs;

public class GenerateDummyFileResponse
{
    public required string FileName { get; set; }
    public required byte[] FileContent { get; set; }
}