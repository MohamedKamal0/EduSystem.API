using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Authentication.Commands.Models;
using SchoolProject.Data.Entity;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Featurs.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand,AuthModel>,
         IRequestHandler<RefreshTokenCommand, AuthModel>,
        IRequestHandler<RevokeTokenCommand, bool>,
        IRequestHandler<LoginQuery, AuthModel>,
         IRequestHandler<AddRoleCommand, string>

    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManger;
        private readonly IAuthenticationServices _authenticationService;

        public AuthenticationCommandHandler(UserManager<User> userManager, SignInManager<User> signInManger,
            IAuthenticationServices authenticationService)
        {

            _userManager = userManager;
            _signInManger = signInManger;
            _authenticationService = authenticationService;
        }

        public async Task<AuthModel> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var registerModel = new RegisterModel
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            };

            return await _authenticationService.RegisterAsync(registerModel);
        }

        public async Task<AuthModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RefreshTokenAsync(request.Token);
        }

        public async  Task<bool> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RevokeTokenAsync(request.Token);
        }

        public async Task<AuthModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var tokenRequestModel = new TokenRequestModel
            {
                Email = request.Email,
                Password = request.Password
            };

            return await _authenticationService.GetTokenAsync(tokenRequestModel);
        }

        public async Task<string> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var addRoleModel = new AddRoleModel
            {
                UserId = request.UserId,
                Role = request.Role
            };

            return await _authenticationService.AddRoleAsync(addRoleModel);
        }
    }
}
