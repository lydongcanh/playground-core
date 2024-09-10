using Mscc.GenerativeAI;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.Core.Infrastructure;

public class LlmFacade : ILlmFacade
{
    public async Task<string> GenerateRawResponseAsync(string prompt)
    {   
        var model = new GenerativeModel();
        var response = await model.GenerateContent(prompt);
        
        return response.Text ?? "";
    }
}