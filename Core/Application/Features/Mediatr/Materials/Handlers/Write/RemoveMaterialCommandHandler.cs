using Application.Constants;
using Application.Features.Mediatr.Materials.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Materials.Handlers.Write
{
    public class RemoveMaterialCommandHandler : IRequestHandler<RemoveMaterialCommand>
    {
        private readonly IRepository<Material> _repository;

        public RemoveMaterialCommandHandler(IRepository<Material> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveMaterialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
            else
            {
                throw new Exception(Messages<Material>.EntityNotFound);
            }
        }
    }
}
