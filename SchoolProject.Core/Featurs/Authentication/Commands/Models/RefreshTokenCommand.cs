using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<AuthModel>
    {
        public string Token { get; set; } = string.Empty;
    }
}
