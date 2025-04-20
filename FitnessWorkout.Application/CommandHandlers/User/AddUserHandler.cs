using AutoMapper;
using Convey.CQRS.Commands;
using FitnessWorkout.Application.Commands.User;
using FitnessWorkout.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FitnessWorkout.Application.CommandHandlers.Users;

public class AddUserHandler : ICommandHandler<AddUser>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public AddUserHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task HandleAsync(AddUser command, CancellationToken cancellationToken = new CancellationToken())
    {
        var user = _mapper.Map<User>(command);
        user.UserName = command.Email;
        await _userManager.CreateAsync(user, command.Password);
    }
}