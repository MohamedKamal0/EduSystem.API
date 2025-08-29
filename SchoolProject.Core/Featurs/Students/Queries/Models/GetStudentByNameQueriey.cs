using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Students.Queries.Result;

namespace SchoolProject.Core.Featurs.Students.Queries.Models
{
    public class GetStudentByNameQueriey:IRequest<Response<GetStudentByNameResponse>>
    {
        public string Name { get; set; }
        public GetStudentByNameQueriey(string name)
        {
            Name = name;
        }
    }
}
