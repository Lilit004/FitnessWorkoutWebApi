using Convey.CQRS.Commands;

namespace FitnessWorkout.Application.Commands.Workout;

public class UpdateUserWorkout : ICommand
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int WorkoutId { get; set; }
    public int StatusId { get; set; }
    public string? EstimatedTime { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}