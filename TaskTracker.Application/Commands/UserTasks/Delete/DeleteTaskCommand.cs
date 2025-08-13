using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Commands.UserTasks.Delete
{
    public class DeleteTaskCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
