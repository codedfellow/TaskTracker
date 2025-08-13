using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Queries.UserTasks.GetAllTasks;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Queries.Reports.CompletedTasks
{
    public class CompletedTasksReportQueryHandler : IRequestHandler<CompletedTasksReportQuery, ReportDto>
    {
        private readonly IApplicationDbContext _context;
        public CompletedTasksReportQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ReportDto> Handle(CompletedTasksReportQuery request, CancellationToken cancellationToken)
        {
            int totalTasks = await _context.UserTasks.CountAsync(cancellationToken);
            int completedTasks = await _context.UserTasks.CountAsync(t => t.Status == TaskStatusEnum.Completed, cancellationToken);
            double completionRate = totalTasks > 0 ? (double)completedTasks / totalTasks * 100 : 0;

            return new ReportDto
            {
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                CompletionRate = Math.Round(completionRate, 2) // Round to 2 decimal places
            };
        }
    }
}
