using Convey.CQRS.Commands;
using FitnessWorkout.Application.Commands.User;
using FitnessWorkout.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace FitnessWorkout.Application.CommandHandlers.Users;

public class SignOutHandler : ICommandHandler<SignOut>
{
    private readonly SignInManager<User> _signInManager;
    public SignOutHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }
    public async Task HandleAsync(SignOut command, CancellationToken cancellationToken = new CancellationToken())
    {
        await _signInManager.SignOutAsync();
    }
}