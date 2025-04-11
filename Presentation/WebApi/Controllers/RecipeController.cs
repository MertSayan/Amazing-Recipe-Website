using Application.Constants;
using Application.Dtos;
using Application.Features.Mediatr.Recipes.Commands;
using Application.Features.Mediatr.Recipes.Handlers.Read;
using Application.Features.Mediatr.Recipes.Queries;
using Application.Interfaces.RecipeInterface;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        IMediator _mediator;
        private readonly IRecipeRepository _recipeRepository;


        public RecipeController(IMediator mediator, IRecipeRepository recipeRepository)
        {
            _mediator = mediator;
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
           var values= await _mediator.Send(new GetRecipeQuery());
            return Ok(values);
        }
        [HttpGet("RecipeById")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var value = await _mediator.Send(new GetRecipeByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("TopRatedRecipes")]
        public async Task<IActionResult> GetTopRatedRecipes(int Count)
        {
            var values = await _mediator.Send(new GetTopRatedRecipeQuery(Count));
            return Ok(values);
        }

        [HttpGet("GetRecipeByUserIdQuery")]
        public async Task<IActionResult> GetRecipeByUserIdQuery(int id)
        {
            var values = await _mediator.Send(new GetRecipeByUserIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetAllRecipesForAdmin")]
        public async Task<IActionResult> GetAllRecipesForAdmin()
        {
            var values=await _mediator.Send(new GetRecipeForAdminQuery());
            return Ok(values);
        }

        [HttpGet("GetRecentRecipes")]
        public async Task<IActionResult> GetRecentRecipes()
        {
            var values = await _mediator.Send(new GetRecentRecipeQuery());
            return Ok(values);
        }
        [HttpGet("GetPagedRecipe")]
        public async Task<IActionResult> GetPagedRecipe(int pageNumber=1,int pageSize=3)
        {
            var values = await _mediator.Send(new GetPagedRecipeQuery(pageNumber,pageSize));
            return Ok(values);
        }
        [HttpGet("GetPagedRecipeByCategory")]
        public async Task<IActionResult> GetPagedRecipeByCategory(string categoryName,int pageNumber = 1, int pageSize = 3)
        {
            var values = await _mediator.Send(new GetPagedRecipeByCategoryQuery(pageNumber, pageSize,categoryName));
            return Ok(values);
        }
        [HttpGet("GetPagedRecipeByAuthor")]
        public async Task<IActionResult> GetPagedRecipeByAuthor(string authorName,int pageNumber = 1, int pageSize = 3)
        {
            var values = await _mediator.Send(new GetPagedRecipeByAuthorQuery(pageNumber, pageSize,authorName));
            return Ok(values);
        }

        [NonAction]
        [HttpGet("deneme")]
        public async Task<IActionResult> Deneme([FromQuery] RecipeListeleInput? input)
        {
            var recipes = await _recipeRepository.GetRecipes(input);
            return Ok(recipes);
        }
        [HttpPost("RecipeJqueryTable")]
        public async Task<IActionResult> RecipeJqueryTable([FromBody] RecipeListeleInput input)
        {
           var recipes=await _recipeRepository.GetRecipes(input);
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromForm]CreateRecipeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Recipe>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRecipe(UpdateRecipeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Recipe>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveRecipe(int id)
        {
            await _mediator.Send(new RemoveRecipeCommand(id));
            return Ok(Messages<Recipe>.EntityDeleted);
        }
        
    }
}
