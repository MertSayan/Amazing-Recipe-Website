using Application.Features.Mediatr.Recipes.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Queries
{
    public class GetTopRatedRecipeQuery:IRequest<List<GetTopRatedRecipeQueryResult>>
    {
        public int Count { get; set; }

        public GetTopRatedRecipeQuery(int count)
        {
            Count = count;
        }
    }
}
