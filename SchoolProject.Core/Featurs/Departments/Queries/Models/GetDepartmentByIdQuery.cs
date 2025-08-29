
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Departments.Queries.Result;

namespace SchoolProject.Core.Featurs.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery:IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public GetDepartmentByIdQuery(int id) 
        { 
        Id = id;
        }

    }
}
