using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Commands.UserTasks.Create;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Helpers;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Commands.UserTasks.Update
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            if (request.Status is TaskStatusEnum.Completed)
            {
                throw new Exception("Kindly use the correct task completion endpoint");
            }

            var user = await _context.Users.FindAsync(request.AssignedToUserId, cancellationToken);

            if (user is null)
            {
                throw new Exception("Assigned user not found");
            }

            var task = await _context.UserTasks.FindAsync(request.Id, cancellationToken);

            if (task is null)
            {
                throw new Exception("Task not found");
            }

            task.Title = request.Title;
            task.Description = request.Description ?? string.Empty;
            task.DueDate = request.DueDate;
            task.AssignedToUserId = request.AssignedToUserId;
            task.Status = request.Status;

            await _context.SaveChangesAsync(cancellationToken);

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
