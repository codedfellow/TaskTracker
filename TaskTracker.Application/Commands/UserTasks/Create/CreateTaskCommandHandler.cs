using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Commands.Auth.Register;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Helpers;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Commands.UserTasks.Create
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskDto>
    {
        private readonly IApplicationDbContext _context;

        public CreateTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.AssignedToUserId, cancellationToken);

            if (user is null)
            {
                throw new Exception("Assigned user not found");
            }

            var task = new UserTask
            {
                Title = request.Title,
                Description = request.Description ?? string.Empty,
                DueDate = request.DueDate,
                AssignedToUserId = request.AssignedToUserId,
                CreatedAt = DateTime.Now,
                Status = TaskStatusEnum.InProgress,
            };

            await _context.UserTasks.AddAsync(task, cancellationToken);
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
