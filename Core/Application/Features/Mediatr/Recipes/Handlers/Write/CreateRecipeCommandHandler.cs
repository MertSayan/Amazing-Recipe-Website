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
                // MVC katmanındaki wwwroot/recipes dizinine kaydetmek için tam yolu belirtin
                var uploadsFolderPath = Path.Combine("C:\\csharpprojeler\\YemekUygulaması\\Frontend\\YemekWebUI", "wwwroot", "recipes");

                // Eğer "recipes" klasörü yoksa oluşturuluyor
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                // Dosya uzantısını alıyoruz
                var fileExtension = Path.GetExtension(request.RecipeImage.FileName);

                // Benzersiz bir dosya adı oluşturuyoruz
                var uniqueFileName = $"{Guid.NewGuid()}_{request.Title}{fileExtension}";

                // Dosya yolunu oluşturuyoruz
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                // Dosyayı kaydediyoruz
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.RecipeImage.CopyToAsync(fileStream);
                }

                // MVC projesinde erişilebilir hale getirmek için dosya yolunu ayarlayın
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
