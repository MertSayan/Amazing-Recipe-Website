using Application.Features.Mediatr.Abouts.Queries;
using Application.Features.Mediatr.Abouts.Results;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Abouts.Handlers.Read
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAboutQueryResult
            {
                AboutId=x.AboutId,
                Description=x.Description
            }).ToList();
        }
    }
}
