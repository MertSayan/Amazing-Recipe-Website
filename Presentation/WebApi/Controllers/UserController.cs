using Application.Constants;
using Application.Features.Mediatr.Users.Commands;
using Application.Features.Mediatr.Users.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //admin görebilecek
        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var values = await _mediator.Send(new GetUserQuery());
            return Ok(values);
        }
        [HttpGet("byId")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var values = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("RecentRegisters")]
        public async Task<IActionResult> RecentRegisters()
        {
            var values = await _mediator.Send(new GetRecentRegistersQuery());
            return Ok(values);
        }
        [HttpGet("GetUserByIdWithOutPassword{id}")]
        public async Task<IActionResult> GetUserByIdWithOutPassword(int id)
        {
            var values = await _mediator.Send(new GetUserByIdForAdminPageQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm]CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityUpdated);
        }
        [HttpDelete]   
        public async Task<IActionResult> RemoveUser(int id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok(Messages<User>.EntityDeleted);
        }
    }
}
