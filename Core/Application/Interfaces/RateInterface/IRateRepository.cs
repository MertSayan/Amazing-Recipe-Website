using Application.Features.Mediatr.Rates.Results;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RateInterface
{
    public interface IRateRepository
    {
        Task<List<Rate>> GetByFilterAsync(Expression<Func<Rate, bool>> filter);

        Task<GetTotalRateValueByRecipeIdQueryResult> GetTotalRateScore(int recipeId);

    }
}
