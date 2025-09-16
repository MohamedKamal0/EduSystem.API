using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Models
{
    public class RevokeTokenCommand : IRequest<bool>
    {
        public string Token { get; set; } = string.Empty;
    }
}
