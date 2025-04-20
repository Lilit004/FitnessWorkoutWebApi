using AutoMapper;
using Convey.CQRS.Queries;
using FitnessWorkout.Application.DTO.Exercise;
using FitnessWorkout.Application.DTO.Workout;
using FitnessWorkout.Application.DTO.Workouts;
using FitnessWorkout.Application.Query.Workouts;
using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;

namespace FitnessWorkout.Application.QueryHandlers.Workouts;

public class GetWorkoutsHandler : IQueryHandler<GetWorkouts, List<WorkoutDto>>
{
    private readonly IWorkoutRepository _repository;
    private readonly IMapper _mapper;

    public GetWorkoutsHandler(IWorkoutRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<List<WorkoutDto>> HandleAsync(GetWorkouts query, CancellationToken cancellationToken = new CancellationToken())
    {
        var workouts = await _repository.GetWorkouts();
        var workoutDto = workouts.Select(x => new WorkoutDto
        {
            Id = x.Id,
            Name = x.Name,
            Exercises = x.Exercises.Select(ex => new ExerciseDto
            {
                Id = ex.Id,
                Name = ex.Name,
                ComplexityLevel = ex.ComplexityLevel
            }).ToList()
        }).ToList();
        return workoutDto;
    }
}