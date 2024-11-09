using Application.Features.Mediatr.Materials.Queries;
using Application.Features.Mediatr.Materials.Results;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Materials.Handlers.Read
{
    public class GetMaterialQueryHandler : IRequestHandler<GetMaterialQuery, List<GetMaterialQueryResult>>
    {
        private readonly IRepository<Material> _repository;

        public GetMaterialQueryHandler(IRepository<Material> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetMaterialQueryResult>> Handle(GetMaterialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetMaterialQueryResult
            {
                MaterialId = x.MaterialId,
                MaterialName = x.MaterialName,
            }).ToList();
        }
    }
}
