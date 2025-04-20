using AutoMapper;
using Convey.CQRS.Commands;
using FitnessWorkout.Application.Commands.Workout;
using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;

namespace FitnessWorkout.Application.CommandHandlers.Workout;

public class AddUserWorkoutHandler : ICommandHandler<AddUserWorkout>
{
    private readonly IMapper _mapper;
    private readonly IWorkoutRepository _workoutRepository;

    public AddUserWorkoutHandler(IMapper mapper, IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
        _mapper = mapper;
    }
    
    public async Task HandleAsync(AddUserWorkout command, CancellationToken cancellationToken = new CancellationToken())
    {
        var userWorkout = _mapper.Map<UserWorkout>(command);
        await _workoutRepository.AddUserWorkout(userWorkout);
    }
}