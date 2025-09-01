using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Featurs.ApplicationUser.Commands.Models;
using SchoolProject.Core.Featurs.ApplicationUser.Queries.Models;
using SchoolProject.Core.Featurs.Students.Commands.Models;
using SchoolProject.Core.Featurs.Students.Queries.Models;

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
        [HttpGet("/applicationuser/paginated")]
        public async Task<IActionResult> pagnationUser([FromQuery] GetUserListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("/applicationuser/{id}")]
        public async Task<IActionResult> GetUserId([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("/applicationuser/create")]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("/applicationuser/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("/applicationuser/delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            return Ok(result);
        }
        [HttpPut("/applicationuser/changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
