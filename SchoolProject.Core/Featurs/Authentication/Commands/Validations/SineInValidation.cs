using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.Authentication.Commands.Models;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Validations
{
    public class SineInValidation : AbstractValidator<SignInCommand>
    {


        public SineInValidation()
        {
            ApplyValidationRoles();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationRoles()
        {

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("UserName Must not Be Empty")
                .NotNull().WithMessage("UserName Must not Be Null");
            
            RuleFor(x => x.Password)
                            .NotEmpty().WithMessage("Password Must not Be Empty")
                            .NotNull().WithMessage("Password Must not Be Null");

            RuleFor(x => x.Email)
                            .NotEmpty().WithMessage("Email Must not Be Empty")
                            .NotNull().WithMessage("Email Must not Be Null");
        }


        public void ApplyCustomValidationsRules()
        {
        }

    }
}
