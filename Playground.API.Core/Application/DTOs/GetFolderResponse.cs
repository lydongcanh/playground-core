namespace Playground.API.Core.Application.DTOs;

public record GetFolderResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<GetFolderResponse> ChildrenFolders { get; set; } = new List<GetFolderResponse>();
    public ICollection<GetFileResponse> Files { get; set; } = new List<GetFileResponse>();
}