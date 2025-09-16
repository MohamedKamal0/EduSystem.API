using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.Authentication.Commands.Models;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Validations
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }

    }
}
