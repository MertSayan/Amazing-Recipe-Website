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
    public class GetRecipeForAdminQueryHandler : IRequestHandler<GetRecipeForAdminQuery, List<GetRecipeForAdminQueryResult>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipeForAdminQueryHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRecipeForAdminQueryResult>> Handle(GetRecipeForAdminQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllRecipe();

            return values.Select(x=> new GetRecipeForAdminQueryResult
            {
                CategoryName=x.Category.Name,
                Description=x.Description,
                RecipeId=x.RecipeID,
                RecipeImageUrl=x.RecipeImageUrl,
                Title=x.Title,
                UserName=x.User.Name+" "+x.User.Surname,
            }).ToList();
        }
    }
}
