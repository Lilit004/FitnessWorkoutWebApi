using Convey.CQRS.Queries;
using FitnessWorkout.Application.DTO.Workouts;
using FitnessWorkout.Core.Entities;

namespace FitnessWorkout.Application.Query.Workouts;

public class GetUserWorkouts : IQuery<List<UserWorkoutDto>>
{
    public int UserId { get; set; }
}