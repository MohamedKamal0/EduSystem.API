using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;

namespace SchoolProject.Core.Featurs.Authentication.Queries.Models
{
   public class AuthorizeUserQuery:IRequest<Response<string>>
    {

        public string AccessToken { get; set; }

    }
}
