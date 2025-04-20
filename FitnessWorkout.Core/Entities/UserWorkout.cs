namespace FitnessWorkout.Core.Entities;

public class UserWorkout
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int WorkoutId { get; set; }
    public int StatusId { get; set; }
    public string? EstimatedTime { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public User User { get; set; }
    public Workout Workout { get; set; }
    public Status Status { get; set; }
    public List<UserExercise> UserEx { get; set; }
}