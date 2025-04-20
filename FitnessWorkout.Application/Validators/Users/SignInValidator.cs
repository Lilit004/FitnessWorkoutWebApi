using FitnessWorkout.Application.Commands.User;
using FitnessWorkout.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace FitnessWorkout.Application.Validators.Users;

public class SignInValidator : AbstractValidator<SignIn>
{
    public SignInValidator(UserManager<User> manager)
    {
        RuleFor(x => x.Email).Must((x, y) =>
        {
            var user = manager.FindByEmailAsync(y).Result;
            return user != null;
        }).WithMessage("User not found");
            
        RuleFor(x => x.Password).Must((x,y) =>
        {
             var user = manager.FindByEmailAsync(x.Email).Result;
             var isPasswordValid =  manager.CheckPasswordAsync(user, x.Password).Result;
             return isPasswordValid;
         }).WithMessage("Wrong password");
            
    }
}