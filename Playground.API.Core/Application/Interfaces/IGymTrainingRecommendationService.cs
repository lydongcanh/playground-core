using Playground.API.Core.Application.DTOs;

namespace Playground.API.Core.Application.Interfaces;

public interface IGymTrainingRecommendationService
{
    Task<string> GetTrainingPlanAsync(GetGymTrainingPlanRequest request);
}