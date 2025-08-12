using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Commands.Auth;

namespace TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid registration data.");
            }

            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok("User registered successfully.");
            }

            return BadRequest("User registration failed.");
        }
    }
}
