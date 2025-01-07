using Application.Features.Mediatr.Rates.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Rates.Queries
{
    public class GetTotalRateValueByRecipeIdQuery:IRequest<GetTotalRateValueByRecipeIdQueryResult>
    {
        public int RecipeId { get; set; }

        public GetTotalRateValueByRecipeIdQuery(int recipeId)
        {
            RecipeId = recipeId;
        }
    }
}
