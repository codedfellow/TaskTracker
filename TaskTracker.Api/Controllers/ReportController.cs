using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Queries.Auth.Users.GetAll;
using TaskTracker.Application.Queries.Reports.CompletedTasks;

namespace TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("completion")]
        public async Task<IActionResult> GetCompletedTasks()
        {
            var query = new CompletedTasksReportQuery();
            var completedTasks = await _mediator.Send(query);
            return Ok(completedTasks);
        }
    }
}
