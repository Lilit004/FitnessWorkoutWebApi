using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.WebApi.Requests;
using FitnessWorkout.Application;
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
    private readonly IQueryDispatcher _queryDispatcher;

    public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
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
    public async Task<ActionResult> SignIn([FromBody] SignIn query)
    {
        var token = await _queryDispatcher.QueryAsync<string>(query);
        return Ok(new {token = token});
    }
    
    [Authorize]
    [HttpPost("sign-out")]
    public async Task<ActionResult> SignOut([FromBody] SignOut command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
    
}