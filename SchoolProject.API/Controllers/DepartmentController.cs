using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Featurs.Departments.Queries.Models;
using SchoolProject.Core.Featurs.Students.Queries.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator )
        {
            _mediator = mediator;
        }
        [HttpGet("/department/{id}")]
        public async Task<IActionResult> GetDepartmentId([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdQuery(id));
            return Ok(result);
        }
        [HttpGet("/department/studentcount")]
        public async Task<IActionResult> GetDepartmentStudentCount( )
        {
            var result = await _mediator.Send(new GetDepartmentStudentCountQuery());
            return Ok(result);
        }

    }
}
