using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.WebApi.Requests;
using FitnessWorkout.Application.Commands.User;
using FitnessWorkout.Application.DTO;
using FitnessWorkout.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FitnessWorkout.Application.CommandHandlers.Users;

public class SignInHandler : IQueryHandler<SignIn, string>
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IJwtService _jwtService;

    public SignInHandler(SignInManager<User> signInManager,UserManager<User> userManager, IJwtService jwtService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtService = jwtService;
    }
    public async Task<string> HandleAsync(SignIn command, CancellationToken cancellationToken = new CancellationToken())
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        await _signInManager.CheckPasswordSignInAsync(user,command.Password,false);
        var token = _jwtService.GenerateToken(user);
        await _signInManager.SignInAsync(user, new AuthenticationProperties());
        return token;
    }
}