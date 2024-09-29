using Playground.API.Core.Application.DTOs;

namespace Playground.API.Core.Application.Interfaces;

public interface IDataRoomService
{
    Task<GenerateDummyFileResponse> GenerateDummyFileAsync(GenerateDummyFileRequest request, CancellationToken cancellationToken);
    Task<Guid> CreateDataRoomAsync(CreateDataRoomRequest request, CancellationToken cancellationToken);
    Task<Guid> CreateFolderAsync(Guid dataRoomId, CreateFolderRequest request, CancellationToken cancellationToken);
    Task<Guid> CreateFileAsync(Guid dataRoomId, Guid folderId, CreateFileRequest request, CancellationToken cancellationToken);
    Task<GetDataRoomResponse> GetDataRoomAsync(Guid id, CancellationToken cancellationToken);
}