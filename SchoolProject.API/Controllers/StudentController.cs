using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Featurs.Students.Commands.Models;
using SchoolProject.Core.Featurs.Students.Queries.Models;
//using SchoolProject.Core.Featurs.Students.Queries.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator medlitor)
        {

            _mediator = medlitor;
        }
        [HttpGet("/student/List")]
        [Authorize]
        public async Task<IActionResult> GetStudentList()
        {
            var result = await _mediator.Send(new GetstudentListQueriey());
            return Ok(result);
        }
        [HttpGet("/student/paginated")]
        
        public async Task<IActionResult>pagnation([FromQuery] GetStudentPaginetedQuery query)
        {
            var result =await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("/student/{id}")]
        public async Task<IActionResult> GetStudentId([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQueriey(id));
            return Ok(result);
        }
        [HttpGet("/student/name")]
        public async Task<IActionResult> GetStudentName( string name)
        {
            var result = await _mediator.Send(new GetStudentByNameQueriey(name));
            return Ok(result);
        }
        [HttpPost("/student/create")]
        public async Task<IActionResult> Create([FromBody]AddStudentCommand  command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("/student/update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("/student/delete")]
        public async Task<IActionResult> Delete([FromBody]  int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));
            return Ok(result);
        }
    }
}

 