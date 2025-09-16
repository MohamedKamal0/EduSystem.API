using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Models
{
    public class LoginQuery : IRequest<AuthModel>
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
