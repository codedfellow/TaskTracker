using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Commands.UserTasks.Update;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Commands.UserTasks.Delete
{
    internal class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Guid> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.UserTasks.FindAsync(request.Id, cancellationToken);

            if (task is null)
            {
                throw new Exception("Task not found");
            }

            await _context.UserTasks
                .Where(t => t.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}
