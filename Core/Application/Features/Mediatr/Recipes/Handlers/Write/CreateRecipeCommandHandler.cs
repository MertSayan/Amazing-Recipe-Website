using Application.Features.Mediatr.Recipes.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Recipes.Handlers.Write
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand>
    {
        private readonly IRepository<Recipe> _recipeRepository;
        private readonly IRepository<RecipeMaterial> _recipeMaterialRepository;

        public CreateRecipeCommandHandler( IRepository<Recipe> recipeRepository, IRepository<RecipeMaterial> recipeMaterialRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeMaterialRepository = recipeMaterialRepository;
        }

        public async Task Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            string photoPath = null;
            if (request.RecipeImage != null && request.RecipeImage.Length > 0)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "recipes");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var fileExtension = Path.GetExtension(request.RecipeImage.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}_{request.Title}{fileExtension}"; 
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.RecipeImage.CopyToAsync(fileStream);
                }

                photoPath = $"/recipes/{uniqueFileName}";

                
            }
            var recipe = new Recipe
            {
                MaterialList = new List<RecipeMaterial>(),
                Title=request.Title,
                RecipeImageUrl=photoPath,
                CategoryId=request.CategoryId,
                Description=request.Description,
                UserId=request.UserId,
            };
            await _recipeRepository.CreateAsync(recipe);

            var recipeMaterials = request.MaterialIds.Select(materialId => new RecipeMaterial
            {
                MaterialId = materialId,
                RecipeId = recipe.RecipeID,
            }).ToList();
            await _recipeMaterialRepository.CreateRangeAsync(recipeMaterials);
        }
    }
}
