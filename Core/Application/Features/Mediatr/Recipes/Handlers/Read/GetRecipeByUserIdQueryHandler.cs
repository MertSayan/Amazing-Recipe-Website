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
    public class GetRecipeByUserIdQueryHandler : IRequestHandler<GetRecipeByUserIdQuery, List<GetRecipeByUserIdQueryResult>>
    {
        private readonly IRecipeRepository _repositor;

        public GetRecipeByUserIdQueryHandler(IRecipeRepository repositor)
        {
            _repositor = repositor;
        }

        public async Task<List<GetRecipeByUserIdQueryResult>> Handle(GetRecipeByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repositor.GetRecipeByUserId(request.UserId);
            return values.Select(x => new GetRecipeByUserIdQueryResult
            {
                RecipeId=x.RecipeID,
                Description=x.Description,
                Title=x.Title,
                RecipeImageUrl=x.RecipeImageUrl
            }).ToList();
        }
    }
}
