using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Featurs.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>

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

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //check if user is exist
            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
        if(oldUser == null) return NotFound<string>("User Not Found");
            //mapping
            var newUser = _mapper.Map(request, oldUser);

            //if username is Exist
            var userByUserName = await _userManager.Users.FirstOrDefaultAsync
                (x => x.UserName == newUser.UserName && x.Id != newUser.Id);
            //username is Exist
            if(userByUserName != null) return BadRequest<string>("UserName is Already Exist");
            //update
            var result = await _userManager.UpdateAsync(newUser);
            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest<string>(errors);
            }
            
            return Success("User Updated Successfully");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if(user == null) return NotFound<string>("User Not Found");
            
            var result = await _userManager.DeleteAsync(user);
            
            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest<string>(errors);
            }

            return Success("User Deleted Successfully");
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {


            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if(user == null) return NotFound<string>("User Not Found");
          
            if(request.NewPassword != request.ConfirmPassword)
                return BadRequest<string>("New Password and Confirm Password do not match");
            var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(user, request.CurrentPassword);
            
            if(!isCurrentPasswordValid)
                return BadRequest<string>("Current Password is Incorrect");
            
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest<string>(errors);
            }
            return Success("Password Changed Successfully");

        }
    }
}
