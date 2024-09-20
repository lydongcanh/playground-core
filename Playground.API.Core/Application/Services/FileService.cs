using System.Text;
using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.Core.Application.Services;

public class FileService(ILlmFacade llmFacade) : IFileService
{
    public async Task<GenerateDummyFileResponse> GenerateDummyFileAsync(GenerateDummyFileRequest request, CancellationToken cancellationToken)
    {
        var fileName = $"{request.FileName}.txt";
        var generateDummyFileContentPrompt = $"Generate text file content based on the file name: {request.FileName}";
        var fileContent = await llmFacade.GenerateRawResponseAsync(generateDummyFileContentPrompt);
        
        return new GenerateDummyFileResponse
        {
            FileName = fileName,
            FileContent = Encoding.UTF8.GetBytes(fileContent)
        };
    }
}
