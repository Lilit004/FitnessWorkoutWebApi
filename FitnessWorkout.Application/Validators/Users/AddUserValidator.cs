using FitnessWorkout.Application.Commands.User;
using FluentValidation;

namespace FitnessWorkout.Application.Validators.Users;

public class AddUserValidator : AbstractValidator<AddUser>
{
    public AddUserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required")
            .MinimumLength(2).WithMessage("This field must contain at least 2 characters").MaximumLength(100)
            .WithMessage("This field cannot contain more than 100 characters");
        
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required")
            .MinimumLength(2).WithMessage("This field must contain at least 2 characters").MaximumLength(100)
            .WithMessage("This field cannot contain more than 100 characters");
        
        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(16).WithMessage("Age must be at least 16 to participate in fitness programs.")
            .LessThanOrEqualTo(100).WithMessage("Age must be under 100.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must contain at least 8 characters")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter")
            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter")
            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number")
            .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one special character");

        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required")
            .Must((x, y) => y == x.Password)
            .WithMessage("Password and Confirm Password is not match");
    }
}