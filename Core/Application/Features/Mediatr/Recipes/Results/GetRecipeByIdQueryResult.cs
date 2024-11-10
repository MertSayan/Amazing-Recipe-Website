using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Results
{
    public class GetRecipeByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string RecipeImageUrl { get; set; }
        public string UserName { get; set; }
        public List<string> Materials { get; set; }
    }
}
