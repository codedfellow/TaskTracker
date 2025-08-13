using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Domain.Entities;
using static BCrypt.Net.BCrypt;

namespace TaskTracker.Application.Commands.Auth.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public RegisterUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken);

            if (role == null)
            {
                throw new Exception("Invalid role specified.");
            }

            bool userExists = await _context.Users.AnyAsync(u => u.Email.Trim() == request.Email.Trim(), cancellationToken);

            if (userExists)
            {
                throw new Exception("User with this email already exists.");
            }

            var user = new User
            {
                Email = request.Email,
                PasswordHash = HashPassword(request.Password),
                RoleId = role.Id
            };

            await _context.Users.AddAsync(user,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
