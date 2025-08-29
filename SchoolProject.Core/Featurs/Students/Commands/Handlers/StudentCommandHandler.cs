using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Students.Commands.Models;
using SchoolProject.Data.Entity;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Featurs.Students.Commands.Handlers
{
    public class StudentCommandHandler:ResponseHandler,
        IRequestHandler<AddStudentCommand,Response<string>>,
                IRequestHandler<UpdateStudentCommand, Response<string>>,
                        IRequestHandler<DeleteStudentCommand, Response<string>>


    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        public StudentCommandHandler(IMapper mapper, IStudentService studentService) 
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMaper = _mapper.Map<Student>(request);

            var result = await _studentService.AddAsync(studentMaper);
             if (result == "Succes") return Created("Added successfuly");
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {

            //Check if the Id is Exist Or not
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            //return NotFound
            if (student == null) return NotFound<string>();
            //mapping Between request and student
            var studentmapper = _mapper.Map(request, student);
            //Call service that make Edit
            var result = await _studentService.EditeAsync(studentmapper);
            //return response
            if (result == "Success") return Success("Edieded successfuly");
            
            
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {

            //Check if the Id is Exist Or not
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            //return NotFound
            if (student == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _studentService.DeleteAsync(student);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
    }
}
