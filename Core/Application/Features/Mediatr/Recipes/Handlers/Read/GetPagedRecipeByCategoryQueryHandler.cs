using Application.Features.Mediatr.Recipes.Queries;
using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeInterface;
using MediatR;

namespace Application.Features.Mediatr.Recipes.Handlers.Read
{
    public class GetPagedRecipeByCategoryQueryHandler : IRequestHandler<GetPagedRecipeByCategoryQuery, List<GetPagedRecipeByCategoryQueryResult>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public GetPagedRecipeByCategoryQueryHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<List<GetPagedRecipeByCategoryQueryResult>> Handle(GetPagedRecipeByCategoryQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetPagedRecipeByCategoryAsync(request.PageNumber, request.PageSize, request.CategoryName);
            return recipes.Select(x=> new GetPagedRecipeByCategoryQueryResult
            {
                CategoryName = x.Category.Name,
                Description = x.Description,
                RecipeId = x.RecipeID,
                RecipeImageUrl = x.RecipeImageUrl,
                Title = x.Title,
                UserName = x.User.Name,
            }).ToList();
        }
    }
}
