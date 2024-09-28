namespace Playground.API.Core.Application.Models;

public record Folder
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Guid DataRoomId { get; set; }
    public Guid? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }
    public ICollection<Folder> ChildrenFolders { get; set; } = new List<Folder>();
    public ICollection<File> Files { get; set; } = new List<File>();

    public bool IsRoot => ParentFolderId == null && ParentFolder == null;
    public bool IsLeaf => ChildrenFolders.Count == 0;
    public bool IsEmpty => ChildrenFolders.Count == 0 && Files.Count == 0;
}