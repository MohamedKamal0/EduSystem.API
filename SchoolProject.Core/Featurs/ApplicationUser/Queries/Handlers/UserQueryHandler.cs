using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.ApplicationUser.Queries.Models;
using SchoolProject.Core.Featurs.ApplicationUser.Queries.Results;
using SchoolProject.Core.Pagnation;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Featurs.ApplicationUser.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUserListQuery, PaginatedResult<GetUserListResponse>>,
                IRequestHandler<GetUserByIdQuery, Response<GetUsreByIdResponse>>

    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserQueryHandler(IMapper mapper,UserManager<User> userManager )
        {

            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<PaginatedResult<GetUserListResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {

            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetUserListResponse>(users)
                                            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;

        }

        public async Task<Response<GetUsreByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            
            if (user == null)
            {
                return NotFound<GetUsreByIdResponse>("User Not Found");
            }
            var result = _mapper.Map<GetUsreByIdResponse>(user);
            return Success(result);

        }
    }
}
