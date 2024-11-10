using Application.Constants;
using Application.Features.Mediatr.Recipes.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Handlers.Write
{
    public class RemoveRecipeCommandHandler : IRequestHandler<RemoveRecipeCommand>
    {
        private readonly IRepository<Recipe> _repository;

        public RemoveRecipeCommandHandler(IRepository<Recipe> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRecipeCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
            else
            {
                throw new Exception(Messages<Recipe>.EntityNotFound);
            }
        }
    }
}
