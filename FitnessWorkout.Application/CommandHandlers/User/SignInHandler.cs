using Convey.CQRS.Commands;
using FitnessWorkout.Application.Commands.User;
using FitnessWorkout.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace FitnessWorkout.Application.CommandHandlers.Users;

public class SignInHandler : ICommandHandler<SignIn>
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public SignInHandler(SignInManager<User> signInManager,UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public async Task HandleAsync(SignIn command, CancellationToken cancellationToken = new CancellationToken())
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        await _signInManager.CheckPasswordSignInAsync(user,command.Password,false);
        await _signInManager.SignInAsync(user, new AuthenticationProperties());
    }
}