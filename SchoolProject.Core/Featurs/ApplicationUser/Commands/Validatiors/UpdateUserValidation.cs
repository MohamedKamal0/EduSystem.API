using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.ApplicationUser.Commands.Models;

namespace SchoolProject.Core.Featurs.ApplicationUser.Commands.Validatiors
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {

        public UpdateUserValidation()
        {
            ApplyValidationRoles();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.FUllName)
                .NotEmpty().WithMessage("FullName Must not Be Empty")
                .NotNull().WithMessage("FullName Must not Be Null");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName Must not Be Empty")
                .NotNull().WithMessage("UserName Must not Be Null");

            RuleFor(x => x.Email)
                            .NotEmpty().WithMessage("Email Must not Be Empty")
                            .NotNull().WithMessage("Email Must not Be Null");

           
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address Must not Be Empty")
                .NotNull().WithMessage("Address Must not Be Null");
        }


        public void ApplyCustomValidationsRules()
        {
        }
    }
}
