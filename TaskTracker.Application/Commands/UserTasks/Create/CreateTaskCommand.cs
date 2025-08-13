using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Commands.UserTasks.Create
{
    public class CreateTaskCommand : IRequest<TaskDto>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedToUserId { get; set; }
    }
}
