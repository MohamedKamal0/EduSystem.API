
using MediatR;
using SchoolProject.Core.Featurs.Students.Queries.Result;
using SchoolProject.Core.Pagnation;
using SchoolProject.Data.DataHelpers;

namespace SchoolProject.Core.Featurs.Students.Queries.Models
{
    public class GetStudentPaginetedQuery:IRequest<PaginatedResult<GetStudentPaginetedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public  StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }

    }
}
