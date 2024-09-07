namespace Playground.API.Core.Application.Interfaces;

public interface ILlmFacade
{
    Task<string> GenerateRawResponseAsync(string prompt);
}