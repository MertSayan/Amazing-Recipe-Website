using Application.Features.Mediatr.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Queries
{
    public class GetUserByIdForAdminPageQuery:IRequest<GetUserByIdForAdminPageQueryResult>
    {
        public int Id { get; set; }

        public GetUserByIdForAdminPageQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
