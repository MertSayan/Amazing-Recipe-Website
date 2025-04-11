using Application.Features.Mediatr.Recipes.Queries;
using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Handlers.Read
{
    public class GetTopRatedRecipeQueryHandler : IRequestHandler<GetTopRatedRecipeQuery, List<GetTopRatedRecipeQueryResult>>
    {

        private readonly IRecipeRepository _repository;

        public GetTopRatedRecipeQueryHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTopRatedRecipeQueryResult>> Handle(GetTopRatedRecipeQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetTopRatedRecipes(request.Count);
            return users.Select(x => new GetTopRatedRecipeQueryResult
            {
                Description = x.Description,
                RecipeId = x.RecipeId,
                RecipeImageUrl = x.RecipeImageUrl,
                Title=x.Title
            }).ToList();
        }
    }
}
