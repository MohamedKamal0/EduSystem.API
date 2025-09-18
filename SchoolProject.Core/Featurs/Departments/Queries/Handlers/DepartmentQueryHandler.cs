using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Departments.Queries.Models;
using SchoolProject.Core.Featurs.Departments.Queries.Result;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Featurs.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler:ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery,Response<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentStudentCountQuery,Response<List<GetDepartmentStudentCountResult>>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentQueryHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
        _mapper = mapper;
        }

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            //service Get By Id include St sub ins
           var response = await _departmentService.GetDepartmentById(request.Id);
            //check Is Not exist
            if (response == null) return NotFound<GetDepartmentByIdResponse>();
            //mapping 
            var mapper = _mapper.Map<GetDepartmentByIdResponse>(response);
            return Success(mapper);
        }

        public async Task<Response<List<GetDepartmentStudentCountResult>>> Handle(GetDepartmentStudentCountQuery request, CancellationToken cancellationToken)
        {
            var viewDepartmentResult = await _departmentService.GetViewDepartmentDataAsync();
            var result = _mapper.Map<List<GetDepartmentStudentCountResult>>(viewDepartmentResult);
            return Success(result);
        }
    }
}
