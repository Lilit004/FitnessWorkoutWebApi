using Convey.CQRS.Commands;
using FitnessWorkout.Application.Commands.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkout.API.Controllers;

[Route("users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public UsersController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<ActionResult> AddUser([FromBody] AddUser command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
    
    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<ActionResult> SignIn([FromBody] SignIn command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
    
    [Authorize]
    [HttpPost("sign-out")]
    public async Task<ActionResult> SignOut([FromBody] SignOut command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
    
}