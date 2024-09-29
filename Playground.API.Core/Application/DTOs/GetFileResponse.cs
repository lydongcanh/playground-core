namespace Playground.API.Core.Application.DTOs;

public record GetFileResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Base64Content { get; set; }
}