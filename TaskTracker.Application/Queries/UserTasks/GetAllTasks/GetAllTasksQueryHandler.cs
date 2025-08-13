using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Helpers;
using TaskTracker.Application.Queries.Auth.Users.GetAll;

namespace TaskTracker.Application.Queries.UserTasks.GetAllTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskDto>?>
    {
        private readonly IApplicationDbContext _context;
        public GetAllTasksQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TaskDto>?> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var allTasks = _context.UserTasks.AsQueryable();

            var currentPageTasks = await allTasks
                .OrderByDescending(t => t.CreatedAt) // Example sorting: newest first
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Join(_context.Users, 
                    task => task.AssignedToUserId, 
                    user => user.Id, 
                    (task, user) => new { task, User = user }) // Joining with Users to get User details
                .Select(res => new TaskDto
                {
                    Id = res.task.Id,
                    Title = res.task.Title,
                    Description = res.task.Description,
                    CreatedAt = res.task.CreatedAt,
                    AssignedToUserId = res.task.AssignedToUserId,
                    AssignedToUserEmail = res.User.Email, // Assuming User has an Email property
                    Status = res.task.Status,
                    StatusText = TaskStatusEnumHelper.GetTaskStatusString(res.task.Status),
                })
                .ToListAsync();

            return currentPageTasks;
        }
    }
}
