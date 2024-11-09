using Application.Constants;
using Application.Features.Mediatr.Materials.Commands;
using Application.Features.Mediatr.Materials.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        IMediator _mediator;

        public MaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialList()
        {
            var values = await _mediator.Send(new GetMaterialQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterial(CreateMaterialCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Material>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMaterial(UpdateMaterialCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Material>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveMaterial(int id)
        {
            await _mediator.Send(new RemoveMaterialCommand(id));
            return Ok(Messages<Material>.EntityDeleted);
        }
    }
}
