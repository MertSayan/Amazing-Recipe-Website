using Application.Constants;
using Application.Features.Mediatr.Rates.Commands;
using Application.Features.Mediatr.Rates.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        IMediator _mediator;

        public RateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("byuser")]
        public async Task<IActionResult> GetRateByUserId(int id)
        {
            var values=await _mediator.Send(new GetRateByUserIdQuery(id));
            return Ok(values);
        }
        [HttpGet("byrecipe")]
        public async Task<IActionResult> GetRateByRecipeId(int id)
        {
            var values = await _mediator.Send(new GetRateByRecipeIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRate(CreateRateCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Rate>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRate(UpdateRateCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Rate>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveRate(int id)
        {
            await _mediator.Send(new RemoveRateCommand(id));
            return Ok(Messages<Rate>.EntityDeleted);
        }
    }
}
