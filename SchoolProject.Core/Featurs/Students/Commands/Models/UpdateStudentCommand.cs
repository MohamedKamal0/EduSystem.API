using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.BasesRespond;

namespace SchoolProject.Core.Featurs.Students.Commands.Models
{
    //هنا هترجع وتقله ان اتعمله ابديت بنجاح علشان كده بعت استرنج
    public class UpdateStudentCommand:IRequest<Response<string>>
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }
        public int DepartmentId { get; set; }

    }
}
