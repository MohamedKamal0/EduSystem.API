using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Featurs.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Featurs.Students.Commands.Validatiors
{
    public class UpdateStudentValidatore:AbstractValidator<UpdateStudentCommand>
    {


        private readonly IStudentService _studentService;
        public UpdateStudentValidatore(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRoles();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must not Be Empty")
                .NotNull().WithMessage("Name Must not Be Null");

        }


        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model,Key, CancellationToken) => !await _studentService.IsNameArExistExcludeSelf(Key,model.Id))
                .WithMessage("Name Is Exist");
        }
    }
}
