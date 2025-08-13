using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Queries.UserTasks.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<List<TaskDto>>
    {
        public int Page { get; set; } = 1; // Default: Page 1
        public int PageSize { get; set; } = 10;
    }
}
