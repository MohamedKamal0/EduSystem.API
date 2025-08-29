using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolProject.Core.Featurs.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile:Profile
    {
        public ApplicationUserProfile() 
        {
            CreateMap<AddUserCommand, User>();        
        }
    }
}
