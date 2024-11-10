using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.RecipeRepositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly YemekContext _context;

        public RecipeRepository(YemekContext context)
        {
            _context = context;
        }

        public async Task<List<GetRecipeQueryResult>> GetAllRecipe()
        {
            //var values = await _context.Recipes
            //    .Include(x => x.)
            return null;
        }
    }
}
