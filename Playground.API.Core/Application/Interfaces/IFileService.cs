using Playground.API.Core.Application.DTOs;

namespace Playground.API.Core.Application.Interfaces;

public interface IFileService
{
    Task<GenerateDummyFileResponse> GenerateDummyFileAsync(GenerateDummyFileRequest request, CancellationToken cancellationToken);
}