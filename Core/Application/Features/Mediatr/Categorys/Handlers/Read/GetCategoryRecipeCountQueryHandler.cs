using Application.Features.Mediatr.Categorys.Queries;
using Application.Features.Mediatr.Categorys.Results;
using Application.Interfaces.RecipeInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Categorys.Handlers.Read
{
    public class GetCategoryRecipeCountQueryHandler : IRequestHandler<GetCategoryRecipeCountQuery, List<GetCategoryRecipeCountQueryResult>>
    {
        private readonly IRecipeRepository _repository;

        public GetCategoryRecipeCountQueryHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryRecipeCountQueryResult>> Handle(GetCategoryRecipeCountQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetRecipeCategoryOrderBy();
            return values;
        }
    }
}
