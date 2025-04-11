using Application.Dtos;
using Application.Features.Mediatr.Categorys.Results;
using Application.Features.Mediatr.Recipes.Results;
using Application.Interfaces.RecipeInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.RecipeRepositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly YemekContext _context;

        public RecipeRepository(YemekContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetAllRecipe()
        {
            var recipes=await _context.Recipes
                .Where(x=>x.DeletedDate==null)
                .Include(x=>x.Category)
                .Include(x=>x.User)
                .ToListAsync();
            return recipes;
        }

        public Task<IQueryable<Recipe>> GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recipe>> GetPagedRecipeAsync(int pageNumber, int pageSize)
        {


            return await _context.Recipes
                .Where(x => x.DeletedDate == null)
                .Include(x => x.User)
                .Include(x => x.Category)
                .OrderBy(x => x.Category.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }


        public async Task<List<Recipe>> GetPagedRecipeByAuthorAsync(int pageNumber, int pageSize, string authorName)
        {
            return await _context.Recipes
               .Where(x => x.DeletedDate == null)
               .Include(x => x.User)
               .Include(x => x.Category)
               .Where(x => x.User.Name == authorName)
               .OrderBy(x => x.CreatedDate)
               .Skip((pageNumber - 1) * pageSize) // sayfa 2 den başlamak istersen 2-1*6 dan mesela 1 sayfa kadar veriyi ( 6 veri) atlayıp döndürüyor :)
               .Take(pageSize)
               .ToListAsync();
        }

        public async Task<List<Recipe>> GetPagedRecipeByCategoryAsync(int pageNumber, int pageSize, string categoryName)
        {
            return await _context.Recipes
                .Where(x => x.DeletedDate == null)
                .Include(x => x.User)
                .Include(x => x.Category)
                .Where(x => x.Category.Name == categoryName)
                .OrderBy(x => x.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Recipe>> GetRecentRecipe()
        {
            var values=await _context.Recipes
                .Where(x=>x.DeletedDate==null)
                .Include(x=>x.User)
                .Include(x=>x.Category)
                .OrderByDescending(x=>x.CreatedDate)
                .Take(5)
                .ToListAsync();
            return values;
        }

        public async Task<List<Recipe>> GetRecipeByUserId(int userId)
        {
            var recipes=await _context.Recipes
                .Where(x=>x.UserId == userId && x.DeletedDate==null)
                .ToListAsync();
            return recipes;
        }

        public async Task<List<GetCategoryRecipeCountQueryResult>> GetRecipeCategoryOrderBy()
        {
            var result = await _context.Recipes
                .Where(x=>x.DeletedDate==null)
                .GroupBy(x => x.CategoryId) //categoryId ye göre grupladık
                .Select(x => new GetCategoryRecipeCountQueryResult
                {
                    CategoryId=x.Key,
                    CategoryName=x.FirstOrDefault().Category.Name,
                    RecipeCount=x.Count()
                }).ToListAsync();
            return result;
        }

        public async Task<PagedListDto> GetRecipes(RecipeListeleInput input)
        {
            var recipes = _context.Set<Recipe>()
                .Where(x=>x.DeletedDate==null)
                .OrderBy(x => x.Title)
                .Include(x=>x.Category)
                .Include(x=>x.User)
                .AsQueryable();

            var totalRecords = recipes.Count();

            recipes = recipes
                .WhereIf(!string.IsNullOrEmpty(input.Title), x => x.Title.ToLower().Contains(input.Title.ToLower()))
                .WhereIf(!string.IsNullOrEmpty(input.CategoryName), x => x.Category.Name.ToLower().Contains(input.CategoryName.ToLower()))
                .WhereIf(!string.IsNullOrEmpty(input.UserName), x => x.User.Name.ToLower().Contains(input.UserName.ToLower()))
                .WhereIf(!string.IsNullOrEmpty(input.Search.Value), x => x.Title.Contains(input.Search.Value) || x.Category.Name.Contains(input.Search.Value)
                    || x.User.Name.Contains(input.Search.Value));


            var filteredRecords = recipes.Count();

            var result= await recipes
                .Skip(input.Start)
                .Take(input.Length)
                .Select(x=> new GetRecipeForAdminQueryResult
                {
                    Title = x.Title,
                    CategoryName=x.Category.Name,
                    Description = x.Description,
                    RecipeId=x.RecipeID,
                    RecipeImageUrl=x.RecipeImageUrl,
                    UserName=x.User.Name,
                })
                .ToListAsync();

            return new PagedListDto
            {
                Data=result,
                Draw=input.Draw,
                RecordsTotal=totalRecords,
                RecordsFiltered=filteredRecords
            };

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
