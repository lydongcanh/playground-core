using System.Text;
using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.Core.Application.Services;

public class PassportService : IPassportService
{
    public async Task<CreatePassportResponse> CreatePassportAsync(CreatePassportRequest request, CancellationToken cancellationToken)
    {
        var passport = Convert.ToBase64String(Encoding.ASCII.GetBytes(request.AccessToken));
        return new CreatePassportResponse { Passport = passport };
    }
}