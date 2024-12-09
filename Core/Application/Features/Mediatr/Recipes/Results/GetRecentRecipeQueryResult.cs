using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Results
{
    public class GetRecentRecipeQueryResult
    {
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
