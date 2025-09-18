using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.IRepository.Functions
{
    public interface IInstructorFunctionRepository
    {
        public decimal GetSalarySummationOfInstructor(string query);

    }
}
