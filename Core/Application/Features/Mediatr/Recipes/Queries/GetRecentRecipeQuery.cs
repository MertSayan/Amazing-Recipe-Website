using Application.Features.Mediatr.Recipes.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Queries
{
    public class GetRecentRecipeQuery:IRequest<List<GetRecentRecipeQueryResult>>
    {
    }
}
