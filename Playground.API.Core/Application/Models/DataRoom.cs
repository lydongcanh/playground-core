namespace Playground.API.Core.Application.Models;

public record DataRoom
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Folder> Folders { get; set; } = new List<Folder>();
}