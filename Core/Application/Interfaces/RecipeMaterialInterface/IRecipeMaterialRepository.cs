using Application.Features.Mediatr.Recipes.Results;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RecipeMaterialInterface
{
    public interface IRecipeMaterialRepository
    {
        Task DeleteByRecipeIdAsync(int recipeId);

        Task<List<GetRecipeQueryResult>> GetAllRecipeMaterialWithRecipesAndUsers();
        Task<GetRecipeByIdQueryResult> GetRecipeByIdAsync(int recipeId);
    }
}
