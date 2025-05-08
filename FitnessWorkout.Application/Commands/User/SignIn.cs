using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.WebApi.Requests;

namespace FitnessWorkout.Application.Commands.User;

public class SignIn : IQuery<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}