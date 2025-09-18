using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Departments.Queries.Result;

namespace SchoolProject.Core.Featurs.Departments.Queries.Models
{
    public class GetDepartmentStudentCountQuery:IRequest<Response<List<GetDepartmentStudentCountResult>>>
    {
    }
}
