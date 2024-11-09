using Application.Features.Mediatr.Materials.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Materials.Handlers.Write
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand>
    {
        private readonly IRepository<Material> _repository;

        public CreateMaterialCommandHandler(IRepository<Material> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Material
            {
                MaterialName = request.MaterialName,
            });
        }
    }
}
