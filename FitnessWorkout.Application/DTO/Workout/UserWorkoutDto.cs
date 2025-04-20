using FitnessWorkout.Application.DTO.Exercise;
using FitnessWorkout.Core.Entities;

namespace FitnessWorkout.Application.DTO.Workouts;

public class UserWorkoutDto
{
    public int Id { get; set; }
    public string WorkoutName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? EstimatedTime { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<ExerciseDto> Exercises = [];
}