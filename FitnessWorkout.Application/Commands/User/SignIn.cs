using Convey.CQRS.Commands;

namespace FitnessWorkout.Application.Commands.User;

public class SignIn : ICommand
{
    public string Email { get; set; }
    public string Password { get; set; }
}