using Application.Features.Mediatr.Recipes.Queries;
using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeMaterialInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Handlers.Read
{
    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, GetRecipeByIdQueryResult>
    {
        private readonly IRecipeMaterialRepository _recipeMaterialRepository;

        public GetRecipeByIdQueryHandler(IRecipeMaterialRepository recipeMaterialRepository)
        {
            _recipeMaterialRepository = recipeMaterialRepository;
        }

        public async Task<GetRecipeByIdQueryResult> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _recipeMaterialRepository.GetRecipeByIdAsync(request.Id);
            return value;
        }
    }
}
