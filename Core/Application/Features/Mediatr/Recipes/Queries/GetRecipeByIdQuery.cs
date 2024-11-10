using Application.Features.Mediatr.Recipes.Results;
using MediatR;

namespace Application.Features.Mediatr.Recipes.Queries
{
    public class GetRecipeByIdQuery:IRequest<GetRecipeByIdQueryResult>
    {
        public int Id { get; set; }

        public GetRecipeByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
