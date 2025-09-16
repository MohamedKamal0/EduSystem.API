using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Models
{
    public class AddRoleCommand : IRequest<string>
    {
        public string UserId { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
