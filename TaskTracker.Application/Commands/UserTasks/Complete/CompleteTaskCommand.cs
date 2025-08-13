using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Commands.UserTasks.Complete
{
    public class CompleteTaskCommand : IRequest<TaskDto>
    {
        public Guid Id { get; set; }
    }
}
