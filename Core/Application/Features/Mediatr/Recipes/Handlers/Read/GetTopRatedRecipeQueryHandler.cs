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
    public class GetTopRatedRecipeQueryHandler:IRequestHandler<GetTopRatedRecipeQuery,List<GetTopRatedRecipeQueryResult>>
    {
        private readonly IRecipeRepository _repository;

        public GetTopRatedRecipeQueryHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }


        public Task<List<GetTopRatedRecipeQueryResult>> Handle(GetTopRatedRecipeQuery request, CancellationToken cancellationToken)
        {
            var topRecipes = _repository.GetTopRatedRecipes(3); // En yüksek 3 tarifi çekiyoruz
            return topRecipes;
        }
    }
}
