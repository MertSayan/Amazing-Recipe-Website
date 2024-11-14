using Application.Features.Mediatr.Recipes.Results;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RecipeInterface
{
    public interface IRecipeRepository
    {
        Task<List<GetRecipeQueryResult>> GetAllRecipe();
        Task<List<GetTopRatedRecipeQueryResult>> GetTopRatedRecipes(int topCount);
        Task<List<Recipe>> GetRecipeByUserId (int userId);
    }
}
