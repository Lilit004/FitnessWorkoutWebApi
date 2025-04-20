using Convey.CQRS.Commands;

namespace FitnessWorkout.Application.Commands.User;

public class AddUser : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}