using Application.Constants;
using Application.Features.Mediatr.Categorys.Commands;
using Application.Features.Mediatr.Categorys.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var values=await _mediator.Send(new GetCategoryQuery());
            return Ok(values);
        }
        [HttpGet("CategoryRecipeCount")]
        public async Task<IActionResult> CategoryRecipeCount()
        {
            var values = await _mediator.Send(new GetCategoryRecipeCountQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Category>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Category>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return Ok(Messages<Category>.EntityDeleted);
        }
    }
}
