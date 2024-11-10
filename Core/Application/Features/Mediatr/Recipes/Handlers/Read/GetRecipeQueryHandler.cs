using Application.Features.Mediatr.Recipes.Queries;
using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeMaterialInterface;
using MediatR;

namespace Application.Features.Mediatr.Recipes.Handlers.Read
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, List<GetRecipeQueryResult>>
    {
        private readonly IRecipeMaterialRepository _recipeMaterialRepository;

        public GetRecipeQueryHandler(IRecipeMaterialRepository recipeMaterialRepository)
        {
            _recipeMaterialRepository = recipeMaterialRepository;
        }

        public async Task<List<GetRecipeQueryResult>> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            var values = await _recipeMaterialRepository.GetAllRecipeMaterialWithRecipesAndUsers();
            return values;
        }
    }
}
