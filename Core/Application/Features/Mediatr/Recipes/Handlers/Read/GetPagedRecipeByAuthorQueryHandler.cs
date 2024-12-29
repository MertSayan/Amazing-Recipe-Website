using Application.Features.Mediatr.Recipes.Queries;
using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeInterface;
using MediatR;

namespace Application.Features.Mediatr.Recipes.Handlers.Read
{
    public class GetPagedRecipeByAuthorQueryHandler : IRequestHandler<GetPagedRecipeByAuthorQuery, List<GetPagedRecipeByAuthorQueryResult>>
    {
        private readonly  IRecipeRepository _recipeRepository;

        public GetPagedRecipeByAuthorQueryHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<List<GetPagedRecipeByAuthorQueryResult>> Handle(GetPagedRecipeByAuthorQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetPagedRecipeByAuthorAsync(request.PageNumber, request.PageSize, request.AuthorName);
            return recipes.Select(x=> new GetPagedRecipeByAuthorQueryResult
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
