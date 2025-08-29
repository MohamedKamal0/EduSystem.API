using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.ApplicationUser.Commands.Models;

namespace SchoolProject.Core.Featurs.ApplicationUser.Commands.Validatiors
{
    public class AddUserValidatiors:AbstractValidator<AddUserCommand>
    {

        public AddUserValidatiors()
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
           
            RuleFor(x => x.Password)
                            .NotEmpty().WithMessage("Password Must not Be Empty")
                            .NotNull().WithMessage("Password Must not Be Null");

            RuleFor(x => x.ConfirmPassword)
                          .Equal(x => x.Password).WithMessage("ConfirmPassword Must Be Equal Password");
                            

        }


        public void ApplyCustomValidationsRules()
        {
        }
    }
}
