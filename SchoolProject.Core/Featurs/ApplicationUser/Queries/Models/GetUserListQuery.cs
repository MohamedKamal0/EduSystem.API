using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.Featurs.ApplicationUser.Queries.Results;
using SchoolProject.Core.Pagnation;

namespace SchoolProject.Core.Featurs.ApplicationUser.Queries.Models
{
    public class GetUserListQuery: IRequest<PaginatedResult<GetUserListResponse>>
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
    }
}
