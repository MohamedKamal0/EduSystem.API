using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Students.Queries.Result;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Featurs.Students.Queries.Models
{
    //ده الجزء الي بيدخل الداتا اعتبره الانبت بتاعك
    public class GetStudentByIdQueriey:IRequest<Response<GetStudentByIdResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQueriey(int id)
        {
            Id = id;
        }
    }
}
