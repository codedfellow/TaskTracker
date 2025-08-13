using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Queries.Auth.Users.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>?>
    {
        private readonly IApplicationDbContext _context;
        public GetAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>?> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await _context.Users.Include(user => user.Role)
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    RoleId = user.RoleId,
                    RoleName = user.Role.Name // Assuming Role is a navigation property and has a Name property
                })
                .ToListAsync(cancellationToken);

            return allUsers;
        }
    }
}
