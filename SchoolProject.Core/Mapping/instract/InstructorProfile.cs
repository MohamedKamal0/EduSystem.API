using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolProject.Core.Featurs.Instructorss.Commands.Models;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Mapping.instract
{
    public class InstructorProfile:Profile
    {

        public InstructorProfile() 
        {
            CreateMap<AddInstructorCommand,Instructor>()
                .ForMember(x=>x.Name,x=>x.MapFrom(x=>x.Name))
                .ForMember(x => x.Image, x => x.Ignore());


        }
    }
}
