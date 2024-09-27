using System.Text;
using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.Core.Application.Services;

public class FileService(ILlmFacade llmFacade) : IFileService
{
    public async Task<GenerateDummyFileResponse> GenerateDummyFileAsync(GenerateDummyFileRequest request, CancellationToken cancellationToken)
    {
        var fileName = $"{request.FileName}.txt";
        var generateDummyFileContentPrompt = $"Generate a creative content for the file: {fileName}. No need for further explanation.";
        var fileContent = await llmFacade.GenerateRawResponseAsync(generateDummyFileContentPrompt);
        
        return new GenerateDummyFileResponse
        {
            FileName = fileName,
            FileContent = Encoding.UTF8.GetBytes(fileContent)
        };
    }
}
