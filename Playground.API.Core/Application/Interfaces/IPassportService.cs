using Playground.API.Core.Application.DTOs;

namespace Playground.API.Core.Application.Interfaces;

public interface IPassportService
{
    Task<CreatePassportResponse> CreatePassportAsync(CreatePassportRequest request, CancellationToken cancellationToken);
}