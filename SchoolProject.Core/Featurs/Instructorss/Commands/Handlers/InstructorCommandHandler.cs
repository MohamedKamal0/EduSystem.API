using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Instructorss.Commands.Models;
using SchoolProject.Data.Entity;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Featurs.Instructorss.Commands.Handlers
{
    public class InstructorCommandHandler : ResponseHandler,
IRequestHandler<AddInstructorCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        public InstructorCommandHandler(IMapper mapper, IInstructorService instructorService)
        {
            _mapper = mapper;
            _instructorService = instructorService;

        }
        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(request);
            var result = await _instructorService.AddInstructorAsync(instructor, request.Image);
            switch (result)
            {
                case "NoImage": return BadRequest<string>();
                case "FailedToUploadImage": return BadRequest<string>();
                case "FailedInAdd": return BadRequest<string>();
            }
            return Success("");
        }
    }
}
