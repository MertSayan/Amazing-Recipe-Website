﻿using Application.Features.Mediatr.Categorys.Results;
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
        Task<List<Recipe>> GetAllRecipe();
        Task<List<GetTopRatedRecipeQueryResult>> GetTopRatedRecipes(int topCount);
        Task<List<Recipe>> GetRecipeByUserId (int userId);

        Task<List<Recipe>> GetRecentRecipe();

        Task<List<GetCategoryRecipeCountQueryResult>> GetRecipeCategoryOrderBy();

        Task<List<Recipe>> GetPagedRecipeAsync(int pageNumber, int pageSize);

        Task<List<Recipe>> GetPagedRecipeByCategoryAsync(int pageNumber, int pageSize,string categoryName);
        Task<List<Recipe>> GetPagedRecipeByAuthorAsync(int pageNumber, int pageSize,string authorName);

    }
}
