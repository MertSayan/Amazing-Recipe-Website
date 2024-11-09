using Application.Features.Mediatr.Materials.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Materials.Queries
{
    public class GetMaterialQuery:IRequest<List<GetMaterialQueryResult>>
    {

    }
}
