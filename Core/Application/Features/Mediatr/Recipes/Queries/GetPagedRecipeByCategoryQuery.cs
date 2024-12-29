using Application.Features.Mediatr.Recipes.Results;
using MediatR;

namespace Application.Features.Mediatr.Recipes.Queries
{
    public class GetPagedRecipeByCategoryQuery:IRequest<List<GetPagedRecipeByCategoryQueryResult>>
    {
        public GetPagedRecipeByCategoryQuery(int pageNumber, int pageSize, string categoryName)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            CategoryName = categoryName;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string CategoryName { get; set; }
    }
}
