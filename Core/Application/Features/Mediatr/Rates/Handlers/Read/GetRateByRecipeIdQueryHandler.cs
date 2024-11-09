using Application.Features.Mediatr.Rates.Queries;
using Application.Features.Mediatr.Rates.Results;
using Application.Interfaces.RateInterface;
using MediatR;

namespace Application.Features.Mediatr.Rates.Handlers.Read
{
    public class GetRateByRecipeIdQueryHandler : IRequestHandler<GetRateByRecipeIdQuery, List<GetRateByRecipeIdQueryResult>>
    {
        private readonly IRateRepository _repository;

        public GetRateByRecipeIdQueryHandler(IRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRateByRecipeIdQueryResult>> Handle(GetRateByRecipeIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByFilterAsync(x=>x.RecipeId==request.RecipeId && x.DeletedDate==null);
            return values.Select(x=> new GetRateByRecipeIdQueryResult
            {
                RateId=x.RateId,
                Score=x.Score,
                UserName=x.User.Name,
            }).ToList();
        }
    }
}