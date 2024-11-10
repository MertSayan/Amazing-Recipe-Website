﻿using Application.Constants;
using Application.Features.Mediatr.Recipes.Commands;
using Application.Features.Mediatr.Recipes.Queries;
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

        public RecipeController(IMediator mediator)
        {
            _mediator = mediator;
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
            var values = await _mediator.Send(new GetRecipeByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(CreateRecipeCommand command)
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