using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using FitnessWorkout.Application.Commands.Workout;
using FitnessWorkout.Application.Query.Workouts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkout.API.Controllers;


[ApiController]
public class WorkoutsController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public WorkoutsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [Authorize]
    [HttpGet("workouts")]
    public async Task<ActionResult> GetWorkouts([FromQuery]GetWorkouts query)
    {
        var workouts = await _queryDispatcher.QueryAsync(query);
        return Ok(workouts);
    }

    [Authorize]
    [HttpPost("user/add-workout")]
    public async Task<ActionResult> AddUserWorkout([FromBody] AddUserWorkout command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
    
    [Authorize]
    [HttpGet("user/workouts")]
    public async Task<ActionResult> GetUserWorkouts([FromQuery]GetUserWorkouts query)
    {
        var workouts = await _queryDispatcher.QueryAsync(query);
        return Ok(workouts);
    }

    [Authorize]
    [HttpPut("user/update-workout")]
    public async Task<ActionResult> UpdateUserWorkout([FromBody] UpdateUserWorkout command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}