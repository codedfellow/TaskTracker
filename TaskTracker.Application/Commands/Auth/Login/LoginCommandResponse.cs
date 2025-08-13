using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Application.Commands.Auth.Login
{
    public sealed record LoginCommandResponse
    {
        public string Token { get; set; }
    }
}
