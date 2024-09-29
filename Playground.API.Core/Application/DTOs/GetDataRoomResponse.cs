namespace Playground.API.Core.Application.DTOs;

public record GetDataRoomResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<GetFolderResponse> Folders { get; set; } = new List<GetFolderResponse>();
}