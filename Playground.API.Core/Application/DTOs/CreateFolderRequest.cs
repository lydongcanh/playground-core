namespace Playground.API.Core.Application.DTOs;

public record CreateFolderRequest
{
    public required string Name { get; set; }
    public Guid? ParentFolderId { get; set; }
}