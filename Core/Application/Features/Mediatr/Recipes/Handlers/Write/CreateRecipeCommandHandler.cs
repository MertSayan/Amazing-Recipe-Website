using Application.Features.Mediatr.Recipes.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Mediatr.Recipes.Handlers.Write
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand>
    {
        public Task Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
