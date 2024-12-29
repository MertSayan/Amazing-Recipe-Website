using Application.Features.Mediatr.Recipes.Queries;
using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Handlers.Read
{
    public class GetPagedRecipeQueryHandler : IRequestHandler<GetPagedRecipeQuery, List<GetPagedRecipeQueryResult>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public GetPagedRecipeQueryHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<List<GetPagedRecipeQueryResult>> Handle(GetPagedRecipeQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetPagedRecipeAsync(request.PageNumber,request.PageSize);
            return recipes.Select(x => new GetPagedRecipeQueryResult
            {
                CategoryName=x.Category.Name,
                Description=x.Description,
                RecipeId=x.RecipeID,
                RecipeImageUrl=x.RecipeImageUrl,
                Title=x.Title,
                UserName=x.User.Name,
            }).ToList();
        }
    }
}
