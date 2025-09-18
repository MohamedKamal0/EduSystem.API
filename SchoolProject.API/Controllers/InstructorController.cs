using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Featurs.Instructorss.Commands.Models;
using SchoolProject.Core.Featurs.Instructorss.Queries.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InstructorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddInstructor")]
        public async Task<IActionResult> AddInstructor([FromForm] AddInstructorCommand command)
        {
            var result = await _mediator.Send(command);
         
            return Ok(result);
        }
        [HttpGet("GetSummationSalaryOfInstructor")]
        public async Task<IActionResult> GetSummationSalaryOfInstructor()
        {
            var result = await _mediator.Send(new GetSummationSalaryOfInstructorQuery());
           
            return Ok(result);
        }
    }
}
