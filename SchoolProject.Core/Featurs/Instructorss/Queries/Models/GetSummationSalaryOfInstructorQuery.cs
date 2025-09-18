using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;

namespace SchoolProject.Core.Featurs.Instructorss.Queries.Models
{
    public class GetSummationSalaryOfInstructorQuery : IRequest<Response<decimal>>
    {
    }
}

