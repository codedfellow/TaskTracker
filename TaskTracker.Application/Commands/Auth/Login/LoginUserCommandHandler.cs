using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Contracts.Data;
using TaskTracker.Application.Contracts.Providers;
using static BCrypt.Net.BCrypt;

namespace TaskTracker.Application.Commands.Auth.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IJwtTokenProvider _jwtTokenGenerator;

        public LoginUserCommandHandler(IApplicationDbContext context, IJwtTokenProvider jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken); 

            if (user == null || !Verify(request.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }

            string token = _jwtTokenGenerator.Create(user);

            return new LoginCommandResponse
            {
                Token = token, // Replace with actual token generation logic
            };
        }
    }
}
