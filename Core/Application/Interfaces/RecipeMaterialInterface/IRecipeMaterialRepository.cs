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
        //Task<List<RecipeMaterial>> GetByFilterAsync(Expression<Func<RecipeMaterial, bool>> filter);

        //Task RemoveAsync(RecipeMaterial recipeMaterial);
        Task DeleteByRecipeIdAsync(int recipeId);

        Task<List<GetRecipeQueryResult>> GetAllRecipeMaterialWithRecipesAndUsers();
    }
}
