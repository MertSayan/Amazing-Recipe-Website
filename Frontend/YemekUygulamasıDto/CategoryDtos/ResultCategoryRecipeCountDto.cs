using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekUygulamasıDto.CategoryDtos
{
    public class ResultCategoryRecipeCountDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int RecipeCount { get; set; }
    }
}
