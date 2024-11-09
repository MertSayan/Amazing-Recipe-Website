using Application.Features.Mediatr.Rates.Queries;
using Application.Features.Mediatr.Rates.Results;
using Application.Interfaces.RateInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Rates.Handlers.Read
{
    public class GetRateByUserIdQueryHandler : IRequestHandler<GetRateByUserIdQuery, List<GetRateByUserIdQueryResult>>
    {
        private readonly IRateRepository _repository;

        public GetRateByUserIdQueryHandler(IRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRateByUserIdQueryResult>> Handle(GetRateByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByFilterAsync(x=>x.UserId==request.UserId && x.DeletedDate==null);
            return values.Select(x=> new GetRateByUserIdQueryResult
            {
                RateId=x.RateId,
                RecipeName=x.Recipe.Title,
                Score=x.Score,
            }).ToList();
        }
    }
}
