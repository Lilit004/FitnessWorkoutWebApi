namespace FitnessWorkout.Core.Entities;

public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Exercise> Exercises { get; set; }
    public List<UserWorkout> UserWorkouts { get; set; }
}