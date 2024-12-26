﻿using Application.Features.Mediatr.Recipes.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Queries
{
    public class GetPagedRecipeQuery:IRequest<List<GetPagedRecipeQueryResult>>
    {
        public GetPagedRecipeQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
