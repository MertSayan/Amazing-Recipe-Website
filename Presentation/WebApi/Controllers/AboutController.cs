using Application.Constants;
using Application.Features.Mediatr.Abouts.Commands;
using Application.Features.Mediatr.Abouts.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAboutList()
        {
            var values = await _mediator.Send(new GetAboutQuery());
            return Ok(values);  
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var values = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<About>.EntityAdded);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<About>.EntityUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> CreateAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok(Messages<About>.EntityDeleted);
        }
    }
}
