namespace FitnessWorkout.Core.Entities;

public class UserExercise
{
    public int Id { get; set; }
    public int UserWorkoutId { get; set; }
    public int ExerciseId { get; set; }
    
    public Exercise Exercise { get; set; }
    public UserWorkout UserWorkout { get; set; }
}