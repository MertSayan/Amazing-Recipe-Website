using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekUygulamasıDto.RecipeDtos
{
    public class RecipeAreaDto
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RecipeImageUrl { get; set; }
    }
}
