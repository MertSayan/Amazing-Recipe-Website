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
    public class GetTotalRateValueByRecipeIdQueryHandler : IRequestHandler<GetTotalRateValueByRecipeIdQuery, GetTotalRateValueByRecipeIdQueryResult>
    {
        private readonly IRateRepository _rateRepository;

        public GetTotalRateValueByRecipeIdQueryHandler(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task<GetTotalRateValueByRecipeIdQueryResult> Handle(GetTotalRateValueByRecipeIdQuery request, CancellationToken cancellationToken)
        {
            return await _rateRepository.GetTotalRateScore(request.RecipeId);
        }
    }
}
