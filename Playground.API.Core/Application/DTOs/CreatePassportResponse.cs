namespace Playground.API.Core.Application.DTOs;

public record CreatePassportResponse
{
    public required string Passport { get; set; }
}