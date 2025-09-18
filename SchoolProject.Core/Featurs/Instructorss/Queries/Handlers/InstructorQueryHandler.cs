using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Instructorss.Queries.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Featurs.Instructorss.Queries.Handlers
{
    public class InstructorQueryHandler : ResponseHandler,
                   IRequestHandler<GetSummationSalaryOfInstructorQuery, Response<decimal>>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        public InstructorQueryHandler(IInstructorService instructorService, IMapper mapper) 
        {
        
            _mapper = mapper;
            _instructorService = instructorService;
        }
        public async Task<Response<decimal>> Handle(GetSummationSalaryOfInstructorQuery request, CancellationToken cancellationToken)
        {
            var result = await _instructorService.GetSalarySummationOfInstructor();
            return Success(result);
        }
    }
}
