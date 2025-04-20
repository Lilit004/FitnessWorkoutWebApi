namespace FitnessWorkout.Core.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WorkoutId { get; set; }
    public string? ComplexityLevel { get; set; }
    
    public Workout Workout { get; set; }
    public ICollection<UserExercise> UserEx { get; set; }
}