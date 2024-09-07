using Playground.API.Core.Application.Enums;

namespace Playground.API.Core.Application.DTOs;

public record GetGymTrainingPlanRequest
{
    public FitnessLevel FitnessLevel { get; set; }
    public TrainingGoal TrainingGoal { get; set; }
    public int TimeCommitmentInMinute { get; set; }
    public string AdditionalContext { get; set; }
}