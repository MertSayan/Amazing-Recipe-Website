using Application.Constants;
using Application.Features.Mediatr.Materials.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Materials.Handlers.Write
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand>
    {
        private readonly IRepository<Material> _repository;

        public UpdateMaterialCommandHandler(IRepository<Material> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.MaterialId);
            if (value != null)
            {
                value.MaterialName = request.MaterialName;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Material>.EntityNotFound);
            }
        }
    }
}
