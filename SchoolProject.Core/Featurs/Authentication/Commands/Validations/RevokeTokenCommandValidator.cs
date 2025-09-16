using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.Authentication.Commands.Models;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Validations
{
    public class RevokeTokenCommandValidator : AbstractValidator<RevokeTokenCommand>
    {
        public RevokeTokenCommandValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Token is required");
        }
    }
}