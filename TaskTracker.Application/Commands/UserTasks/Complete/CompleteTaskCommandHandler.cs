using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Commands.UserTasks.Update;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Helpers;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Commands.UserTasks.Complete
{
    public class CompleteTaskCommandHandler : IRequestHandler<CompleteTaskCommand, TaskDto>
    {
        private readonly IApplicationDbContext _context;

        public CompleteTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDto> Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.UserTasks.FindAsync(request.Id, cancellationToken);

            if (task is null)
            {
                throw new Exception("Task not found");
            }

            task.Status = TaskStatusEnum.Completed;
            task.CompletedAt = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            var user = await _context.Users.FindAsync(task.AssignedToUserId, cancellationToken);

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                CreatedAt = task.CreatedAt,
                CompletedAt = task.CompletedAt,
                Status = task.Status,
                AssignedToUserId = task.AssignedToUserId,
                AssignedToUserEmail = user.Email,
                StatusText = TaskStatusEnumHelper.GetTaskStatusString(task.Status)
            };
        }
    }
}
