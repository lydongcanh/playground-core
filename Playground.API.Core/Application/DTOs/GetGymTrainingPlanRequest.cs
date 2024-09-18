using Playground.API.Core.Application.Enums;

namespace Playground.API.Core.Application.DTOs;

public record GetGymTrainingPlanRequest
{
    public required FitnessLevel FitnessLevel { get; set; }
    public required TrainingGoal TrainingGoal { get; set; }
    public required int TimeCommitmentInMinute { get; set; }
    public string? AdditionalContext { get; set; }
}