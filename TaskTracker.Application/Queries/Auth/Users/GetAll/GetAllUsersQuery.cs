using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Queries.Auth.Users.GetAll
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}
