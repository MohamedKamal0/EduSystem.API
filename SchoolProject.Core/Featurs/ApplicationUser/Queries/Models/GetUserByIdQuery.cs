using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.ApplicationUser.Queries.Results;

namespace SchoolProject.Core.Featurs.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery:IRequest<Response<GetUsreByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
