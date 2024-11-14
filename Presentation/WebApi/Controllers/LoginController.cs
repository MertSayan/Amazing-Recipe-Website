using Application.Constants;
using Application.Features.Mediatr.Users.Queries;
using Application.Tools;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Index(GetUserByMailAndPasswordQuery query)
        {
            var value = await _mediator.Send(query);
            if (value.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(value));
            }
            else
            {
                return BadRequest(Messages<User>.EntityCantMathes);
            }
        }
    }
}
