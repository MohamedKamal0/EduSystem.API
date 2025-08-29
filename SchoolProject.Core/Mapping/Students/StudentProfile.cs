using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolProject.Core.Featurs.Students.Commands.Models;
using SchoolProject.Core.Featurs.Students.Queries.Result;
using SchoolProject.Data.Entity;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            //   GetStudentListMapping();
            //  GetStudentByIDMapping();
            CreateMap<Student, GetStudentResponse>().ForMember
                (x => x.DepartmentName, opt => opt.MapFrom(x => x.Department.DName));
            
            CreateMap<Student, GetStudentByIdResponse>().ForMember
                (x => x.DepartmentName, opt => opt.MapFrom(x => x.Department.DName));
            CreateMap<Student, GetStudentByNameResponse>().ReverseMap();

            CreateMap<AddStudentCommand,Student>().ForMember
                (x => x.DID, opt => opt.MapFrom(x => x.DepartmentId));
            CreateMap<UpdateStudentCommand, Student>().ForMember
                (x => x.DID, opt => opt.MapFrom(x => x.DepartmentId)).
                ForMember(x => x.StudID, x => x.MapFrom(x => x.Id));

            CreateMap<Student, GetStudentPaginetedResponse>()
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudID))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }

    }
    }

