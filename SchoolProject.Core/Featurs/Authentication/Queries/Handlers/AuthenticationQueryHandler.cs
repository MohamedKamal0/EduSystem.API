using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Authentication.Queries.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Featurs.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
           IRequestHandler<AuthorizeUserQuery, Response<string>>
    {
        private readonly IAuthenticationServices _authenticationService;
        public AuthenticationQueryHandler(IAuthenticationServices authenticationService) { 
        
            _authenticationService = authenticationService;
        }
        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
    //        var result = await _authenticationService.ValidateToken(request.AccessToken);
      //      if (result == "NotExpired")
        //        return Success(result);
            return Unauthorized<string>();
        }
    }
}
