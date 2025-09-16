using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.Authentication.Commands.Models;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Validations
{
    public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
    {
        public AddRoleCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required")
                .Must(role => new[] { "Admin", "User", "Manager" }.Contains(role))
                .WithMessage("Role must be one of: Admin, User, Manager");
        }
    }
}
