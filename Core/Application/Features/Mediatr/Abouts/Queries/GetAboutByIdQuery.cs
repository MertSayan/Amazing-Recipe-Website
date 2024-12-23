using Application.Features.Mediatr.Abouts.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Abouts.Queries
{
    public class GetAboutByIdQuery:IRequest<GetAboutByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAboutByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
