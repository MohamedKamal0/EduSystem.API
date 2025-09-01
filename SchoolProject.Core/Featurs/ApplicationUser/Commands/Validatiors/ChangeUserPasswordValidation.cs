using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.ApplicationUser.Commands.Models;

namespace SchoolProject.Core.Featurs.ApplicationUser.Commands.Validatiors
{
    public class ChangeUserPasswordValidation : AbstractValidator<ChangeUserPasswordCommand>
    {

        public ChangeUserPasswordValidation()
        {
            ApplyValidationRoles();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationRoles()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Must not Be Empty")
                .NotNull().WithMessage("Id Must not Be Null");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("CurrentPassword Must not Be Empty")
                .NotNull().WithMessage("CurrentPassword Must not Be Null");
            
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("NewPassword Must not Be Empty")
                .NotNull().WithMessage("NewPassword Must not Be Null");
  
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage("ConfirmPassword Must Be Equal NewPassword");


        }


        public void ApplyCustomValidationsRules()
        {
        }

    }
}
