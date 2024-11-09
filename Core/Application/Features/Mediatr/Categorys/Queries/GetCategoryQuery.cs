using Application.Features.Mediatr.Categorys.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Categorys.Queries
{
    public class GetCategoryQuery:IRequest<List<GetCategoryQueryResult>>
    {
    }
}
