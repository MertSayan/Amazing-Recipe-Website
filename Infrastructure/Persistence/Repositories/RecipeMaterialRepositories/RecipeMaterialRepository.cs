using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeMaterialInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories.RecipeMaterialRepositories
{
    public class RecipeMaterialRepository : IRecipeMaterialRepository
    {
        private readonly YemekContext _context;

        public RecipeMaterialRepository(YemekContext context)
        {
            _context = context;
        }

        public async Task DeleteByRecipeIdAsync(int recipeId)
        {
            // RecipeId'ye göre RecipeMaterial'leri filtrele
            var recipeMaterials = await _context.RecipeMaterials
                .Where(x => x.RecipeId == recipeId)
                .ToListAsync();

            // Toplu olarak sil
            _context.RecipeMaterials.RemoveRange(recipeMaterials);

            // Değişiklikleri veritabanına kaydet
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetRecipeQueryResult>> GetAllRecipeMaterialWithRecipesAndUsers()
        {
            var values = await _context.RecipeMaterials
                 .Include(x => x.Recipe)
                     .ThenInclude(x => x.User)
                 .Include(x => x.Recipe.Category)
                 .Include(x => x.Material)
                 .Where(x => x.DeletedDate == null
                 && x.Recipe.DeletedDate == null )
                 .ToListAsync();

            var results = new List<GetRecipeQueryResult>();

            var groupedRecipes = values.GroupBy(rm => rm.Recipe).OrderBy(group => group.Key.RecipeID);

            foreach (var group in groupedRecipes)
            {
                var recipe = group.Key;

                var result = new GetRecipeQueryResult
                {
                    Id = recipe.RecipeID,
                    Title = recipe.Title,
                    Description = recipe.Description,
                    CategoryName = recipe.Category?.Name,
                    RecipeImageUrl = recipe.RecipeImageUrl,
                    UserName = recipe.User?.Name + " " + recipe.User?.Surname,
                    Materials = group.Select(rm => rm.Material.MaterialName).Distinct().ToList() // Her bir material ismini listeye ekliyoruz
                };

                results.Add(result);
            }

            return results;
        }

        public async Task<GetRecipeByIdQueryResult> GetRecipeByIdAsync(int recipeId)
        {
            var values = await _context.RecipeMaterials
                  .Include(x => x.Recipe)
                      .ThenInclude(x => x.User)
                  .Include(x => x.Recipe.Category)
                  .Include(x => x.Material)
                  .Where(x => x.DeletedDate == null && x.RecipeId == recipeId)
                  
                  .ToListAsync();

            var recipe = values.Select(x => x.Recipe).FirstOrDefault();

            if (recipe == null)
            {
                return null; // Tarif bulunamadıysa null döndürülür.
            }

            // Sonuçları alıyoruz
            var result = new GetRecipeByIdQueryResult
            {
                Id = recipe.RecipeID,
                Title = recipe.Title,
                Description = recipe.Description,
                CategoryName = recipe.Category?.Name,
                RecipeImageUrl = recipe.RecipeImageUrl,
                UserName = recipe.User?.Name + " " + recipe.User?.Surname,
                Materials = values.Select(x => x.Material.MaterialName).Distinct().ToList() // Malzemelerin adlarını alıyoruz
            };

            return result;
        }
    }
}
