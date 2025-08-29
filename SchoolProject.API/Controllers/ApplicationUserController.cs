using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Featurs.ApplicationUser.Commands.Models;
using SchoolProject.Core.Featurs.Students.Commands.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {


        private readonly IMediator _mediator;
        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/applicationuser/create")]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
