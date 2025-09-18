using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.BasesRespond;

namespace SchoolProject.Core.Featurs.Instructorss.Commands.Models
{
    public class AddInstructorCommand : IRequest<Response<string>>
    {

        public string? Name { get; set; }

        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }
        public IFormFile? Image { get; set; }
    }
}
