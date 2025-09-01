using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;

namespace SchoolProject.Core.Featurs.ApplicationUser.Commands.Models
{
    public class UpdateUserCommand:IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string FUllName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
    }
}
