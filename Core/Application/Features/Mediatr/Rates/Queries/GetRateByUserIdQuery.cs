using Application.Features.Mediatr.Rates.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Rates.Queries
{
    public class GetRateByUserIdQuery:IRequest<List<GetRateByUserIdQueryResult>>
    {
        public int UserId { get; set; }

        public GetRateByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
