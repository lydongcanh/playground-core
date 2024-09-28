namespace Playground.API.Core.Application.Models;

public record File
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Guid FolderId { get; set; }
    public Folder? Folder { get; set; }
    public required string Base64Content { get; set; }
}