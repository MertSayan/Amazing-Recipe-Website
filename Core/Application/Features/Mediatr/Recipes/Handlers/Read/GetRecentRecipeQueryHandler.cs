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
    public class GetRecentRecipeQueryHandler : IRequestHandler<GetRecentRecipeQuery, List<GetRecentRecipeQueryResult>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecentRecipeQueryHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRecentRecipeQueryResult>> Handle(GetRecentRecipeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetRecentRecipe();
            return values.Select(x=> new GetRecentRecipeQueryResult
            {
                CategoryName=x.Category.Name,
                CreatedDate=x.CreatedDate,
                Title=x.Title,
                UserName=x.User.Name,

            }).ToList();
        }
    }
}
