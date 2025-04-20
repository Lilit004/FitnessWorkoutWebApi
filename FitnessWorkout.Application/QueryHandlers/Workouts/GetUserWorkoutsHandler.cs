using Convey.CQRS.Queries;
using FitnessWorkout.Application.DTO.Workouts;
using FitnessWorkout.Application.Query.Workouts;
using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;

namespace FitnessWorkout.Application.QueryHandlers.Workouts;

public class GetUserWorkoutsHandler : IQueryHandler<GetUserWorkouts, List<UserWorkoutDto>>
{
    private readonly IWorkoutRepository _workoutRepository;

    public GetUserWorkoutsHandler(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    
    public async Task<List<UserWorkoutDto>> HandleAsync(GetUserWorkouts query, CancellationToken cancellationToken = new CancellationToken())
    {
        var userWorkouts = await _workoutRepository.GetUserWorkouts(query.UserId);
        var userWorkoutDtos = userWorkouts.Select(x => new UserWorkoutDto
        {
            Id = x.Id,
            WorkoutName = x.Workout.Name,
            Status = x.Status.Name,
            EstimatedTime = x.EstimatedTime,
            StartDate = x.StartDate,
            EndDate = x.EndDate
        }).ToList();
        return userWorkoutDtos;
    }
}