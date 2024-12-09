using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekUygulamasıDto.RecipeDtos
{
    public class ResultAllRecipeForAdminDto
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RecipeImageUrl { get; set; }
        public string Username { get; set; }

        public string CategoryName { get; set; }
    }
}
