using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Application.DTOs
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
