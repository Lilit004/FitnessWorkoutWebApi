using AutoMapper;
using Convey.CQRS.Commands;
using FitnessWorkout.Application.Commands.Workout;
using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;

namespace FitnessWorkout.Application.CommandHandlers.Workout;

public class UpdateUserWorkoutHandler : ICommandHandler<UpdateUserWorkout>
{
    private readonly IWorkoutRepository _repository;
    private readonly IMapper _mapper;

    public UpdateUserWorkoutHandler(IWorkoutRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task HandleAsync(UpdateUserWorkout command, CancellationToken cancellationToken = new CancellationToken())
    {
        var userWorkout = _mapper.Map<UserWorkout>(command);
        await _repository.UpdateUserWorkout(userWorkout);
    }
}