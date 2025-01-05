using Application.Dtos;
using Application.Features.Mediatr.Categorys.Results;
using Application.Features.Mediatr.Recipes.Results;
using Domain;

namespace Application.Interfaces.RecipeInterface
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllRecipe();
        Task<List<GetTopRatedRecipeQueryResult>> GetTopRatedRecipes(int topCount);
        Task<List<Recipe>> GetRecipeByUserId (int userId);

        Task<List<Recipe>> GetRecentRecipe();

        Task<List<GetCategoryRecipeCountQueryResult>> GetRecipeCategoryOrderBy();

        Task<List<Recipe>> GetPagedRecipeAsync(int pageNumber, int pageSize);

        Task<List<Recipe>> GetPagedRecipeByCategoryAsync(int pageNumber, int pageSize,string categoryName);
        Task<List<Recipe>> GetPagedRecipeByAuthorAsync(int pageNumber, int pageSize,string authorName);

        Task<PagedListDto> GetRecipes(RecipeListeleInput input);

    }
}
