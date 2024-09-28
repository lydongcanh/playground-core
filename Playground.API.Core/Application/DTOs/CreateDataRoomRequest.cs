namespace Playground.API.Core.Application.DTOs;

public record CreateDataRoomRequest
{
    public required string Name { get; set; }
}