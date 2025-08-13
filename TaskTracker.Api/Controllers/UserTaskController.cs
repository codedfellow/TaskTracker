using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Commands.Auth.Register;
using TaskTracker.Application.Commands.UserTasks.Complete;
using TaskTracker.Application.Commands.UserTasks.Create;
using TaskTracker.Application.Commands.UserTasks.Delete;
using TaskTracker.Application.Commands.UserTasks.Update;
using TaskTracker.Application.Queries.Auth.Users.GetAll;
using TaskTracker.Application.Queries.UserTasks.GetAllTasks;

namespace TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserTaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command data.");
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command data.");
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask([FromQuery] DeleteTaskCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command data.");
            }

            var result = await _mediator.Send(command);
            return Ok("Task deleted");
        }

        [HttpPost("complete")]
        public async Task<IActionResult> CompleteTask([FromBody] CompleteTaskCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command data.");
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllTasksQuery query)
        {
            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }
    }
}
