using Application.Features.Mediatr.Recipes.Results;

namespace Application.Dtos
{
    public class RecipeListeleInput
    {

        public int Start { get; set; }
        public int Length { get; set; }
        public int Draw {  get; set; }

        public string? Title { get; set; }
        public string? CategoryName { get; set; }
        public string? UserName { get; set; }

        public SearchDto? Search { get; set; }
    }

    public class SearchDto
    {
        public string? Value { get; set; }
        public string? Regex { get; set; }
    }

    public class PagedListDto
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<GetRecipeForAdminQueryResult>? Data { get; set; }
    }


}
