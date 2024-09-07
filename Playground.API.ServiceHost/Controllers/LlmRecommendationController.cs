using Microsoft.AspNetCore.Mvc;
using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.ServiceHost.Controllers;

[ApiController]
[Route("[controller]")]
public class LlmRecommendationController(IGymTrainingRecommendationService gymTrainingRecommendationService) : ControllerBase
{
    [HttpPost]
    [Route("gym-training-plan")]
    public async Task<IActionResult> GetGymTrainingPlanAsync(GetGymTrainingPlanRequest request)
    {
        return Ok(await gymTrainingRecommendationService.GetTrainingPlanAsync(request));
    }
}