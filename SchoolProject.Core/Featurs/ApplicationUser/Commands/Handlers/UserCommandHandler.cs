using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Featurs.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>
    {
        private  readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserCommandHandler(IMapper mapper, UserManager<User> userManager) 
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user != null)
                return BadRequest<string>("Email is Already Exist");
            
            var userName = await _userManager.FindByNameAsync(request.UserName);
           
            if(userName != null)
                return BadRequest<string>("UserName is Already Exist");
            

            var identityUser = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(identityUser, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest<string>(errors);
            }
            return Created("");
        }
    }
}
