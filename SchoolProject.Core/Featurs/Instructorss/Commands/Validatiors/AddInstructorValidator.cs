using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.Instructorss.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Featurs.Instructorss.Commands.Validatiors
{
    public class AddInstructorValidator : AbstractValidator<AddInstructorCommand>
    {

        private readonly IInstructorService _instructorService;
        private readonly IDepartmentService _departmentService;
        public AddInstructorValidator(IInstructorService instructorService, IDepartmentService departmentService)
        {
            _instructorService = instructorService;
            _departmentService = departmentService;
            ApplyValidationRoles();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must not Be Empty")
                .NotNull().WithMessage("Name Must not Be Null");

            RuleFor(x => x.DID)
             .NotEmpty().WithMessage("Department Must not Be Empty")
                .NotNull().WithMessage("Department Must not Be Null");

        }


        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameExist(Key))
                .WithMessage("Name Is Exist");

       //     RuleFor(x => x.DID)
     // .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
   //  .WithMessage("Department does not exist");


        }
    }
}