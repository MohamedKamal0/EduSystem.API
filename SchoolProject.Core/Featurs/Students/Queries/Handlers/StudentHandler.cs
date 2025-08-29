using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SchoolProject.Core.BasesRespond;
using SchoolProject.Core.Featurs.Students.Queries.Models;
using SchoolProject.Core.Featurs.Students.Queries.Result;
using SchoolProject.Core.Pagnation;
using SchoolProject.Data.Entity;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implemintation;

namespace SchoolProject.Core.Featurs.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler,
        IRequestHandler<GetstudentListQueriey, Response<List<GetStudentResponse>>>,
        IRequestHandler<GetStudentByIdQueriey, Response<GetStudentByIdResponse>>,
        IRequestHandler<GetStudentByNameQueriey, Response<GetStudentByNameResponse>>,
                IRequestHandler<GetStudentPaginetedQuery, PaginatedResult<GetStudentPaginetedResponse>>


    {
        private readonly IStudentService _studentServer;
        private readonly IMapper _mapper;
        public StudentHandler(IStudentService studentServer, IMapper mapper)
        {
            _studentServer = studentServer;
            _mapper = mapper;
        }
        public async Task<Response<List<GetStudentResponse>>> Handle(GetstudentListQueriey request, CancellationToken cancellationToken)
        {


            var studentList = await _studentServer.GetStudentsListAsync();
            var studentListMaper = _mapper.Map<List<GetStudentResponse>>(studentList);
            return Success(studentListMaper);
        }

        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQueriey request, CancellationToken cancellationToken)
        {
            var student = await _studentServer.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<GetStudentByIdResponse>();
            var result = _mapper.Map<GetStudentByIdResponse>(student);
            return Success(result);

        }

        public async Task<Response<GetStudentByNameResponse>> Handle(GetStudentByNameQueriey request, CancellationToken cancellationToken)
        {
            var student = await _studentServer.GetStudentByNameAsync(request.Name);
            if (student == null)
                return NotFound<GetStudentByNameResponse>();
            var result = _mapper.Map<GetStudentByNameResponse>(student);
            return Success(result);
        }


        public async Task<PaginatedResult<GetStudentPaginetedResponse>> Handle(GetStudentPaginetedQuery request, CancellationToken cancellationToken)
        {

            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
            var FilterQuery = _studentServer.FilterStudentPaginated(request.OrderBy, request.Search);
            var PaginatedList = await _mapper.ProjectTo<GetStudentPaginetedResponse>(FilterQuery).
                ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta = new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
    }
}