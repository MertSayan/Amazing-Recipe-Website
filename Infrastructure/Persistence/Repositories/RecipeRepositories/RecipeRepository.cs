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

        public async Task<List<Recipe>> GetRecipeByUserId(int userId)
        {
            var recipes=await _context.Recipes
                .Where(x=>x.UserId == userId && x.DeletedDate==null)
                .ToListAsync();
            return recipes;
        }

        public async Task<List<GetTopRatedRecipeQueryResult>> GetTopRatedRecipes(int topCount)
        {
            var topRecipes = await _context.Rates
            .Where(x=>x.DeletedDate==null)
            .GroupBy(r => r.RecipeId) // RecipeId'ye göre gruplama
            .Select(g => new
            {
                RecipeId = g.Key,
                AverageScore = g.Average(r => r.Score) // Ortalama puanı hesaplama
            })
            .OrderByDescending(x => x.AverageScore) // En yüksekten en düşüğe sıralama
            
            .Take(topCount) // İlk n tarif seçme
            
            .Join(_context.Recipes.Where(x=>x.DeletedDate==null), // Recipe tablosu ile birleştirme
                  r => r.RecipeId,
                  recipe => recipe.RecipeID,
                  (r, recipe) => new GetTopRatedRecipeQueryResult   
                  {
                      RecipeId= recipe.RecipeID,
                      Title = recipe.Title,
                      Description = recipe.Description,
                      RecipeImageUrl=recipe.RecipeImageUrl
                  })
            
            .ToListAsync();

            return topRecipes;
        }
    }
}
