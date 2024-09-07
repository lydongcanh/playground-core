using Playground.API.Core.Application.DTOs;
using Playground.API.Core.Application.Interfaces;

namespace Playground.API.Core.Application.Services;

public class GymTrainingRecommendationService(ILlmFacade llmFacade) : IGymTrainingRecommendationService
{
    public async Task<string> GetTrainingPlanAsync(GetGymTrainingPlanRequest request)
    {
        var prompt = $"I am a {request.FitnessLevel.ToString()} person " +
                     $"with a goal of building {request.TrainingGoal.ToString()}." +
                     $"I have {request.TimeCommitmentInMinute} minute today to work out." +
                     (string.IsNullOrWhiteSpace(request.AdditionalContext) ? $"{request.AdditionalContext}." : "") +
                     "Please recommend suitable exercises for me.";

        return await llmFacade.GenerateRawResponseAsync(prompt);
    }
}