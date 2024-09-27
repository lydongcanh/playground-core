namespace Playground.API.Core.Application.DTOs;

public record CreatePassportRequest
{
    public required string AccessToken { get; set; }
}