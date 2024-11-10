using Application.Constants;
using Application.Features.Mediatr.Recipes.Commands;
using Application.Interfaces;
using Application.Interfaces.RecipeMaterialInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Handlers.Write
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand>
    {
        private readonly IRepository<Recipe> _repository;
        private readonly IRecipeMaterialRepository _recipeMaterialRepository;
        private readonly IRepository<RecipeMaterial> _guncellerepository;

        public UpdateRecipeCommandHandler(IRepository<Recipe> repository, IRecipeMaterialRepository recipeMaterialRepository, IRepository<RecipeMaterial> guncellerepository)
        {
            _repository = repository;
            _recipeMaterialRepository = recipeMaterialRepository;
            _guncellerepository = guncellerepository;
        }

        public async Task Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {

            await _recipeMaterialRepository.DeleteByRecipeIdAsync(request.RecipeID);


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

            var value= await _repository.GetByIdAsync(request.RecipeID);
            if (value != null)
            {
                value.CategoryId=request.CategoryId;
                value.Description=request.Description;
                value.Title=request.Title;
                value.MaterialList = new List<RecipeMaterial>();
                value.RecipeImageUrl = photoPath;

                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Recipe>.EntityNotFound);
            }


            var recipeMaterials = request.MaterialIds.Select(materialId => new RecipeMaterial
            {
                MaterialId = materialId,
                RecipeId = request.RecipeID,
            }).ToList();
            await _guncellerepository.CreateRangeAsync(recipeMaterials);


        }
    }
}
