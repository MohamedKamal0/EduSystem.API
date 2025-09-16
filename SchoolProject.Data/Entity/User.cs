using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entity
{
    public class User:IdentityUser
    {

        public string FUllName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;


        public string Country { get; set; } = string.Empty;


        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}
