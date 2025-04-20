using FitnessWorkout.Application.DTO.Exercise;
using FitnessWorkout.Core.Entities;

namespace FitnessWorkout.Application.DTO.Workout;

public class WorkoutDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ExerciseDto> Exercises { get; set; } = [];
}