using Convey.CQRS.Queries;
using FitnessWorkout.Application.DTO.Workout;
using FitnessWorkout.Application.DTO.Workouts;
using FitnessWorkout.Core.Entities;

namespace FitnessWorkout.Application.Query.Workouts;

public class GetWorkouts : IQuery<List<WorkoutDto>>
{
    
}