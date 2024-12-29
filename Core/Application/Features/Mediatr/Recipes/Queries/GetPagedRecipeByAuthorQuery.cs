using Application.Features.Mediatr.Recipes.Results;
using MediatR;

namespace Application.Features.Mediatr.Recipes.Queries
{
    public class GetPagedRecipeByAuthorQuery:IRequest<List<GetPagedRecipeByAuthorQueryResult>>
    {
        public GetPagedRecipeByAuthorQuery(int pageNumber, int pageSize, string authorName)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            AuthorName = authorName;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string AuthorName { get; set; }
    }
}
