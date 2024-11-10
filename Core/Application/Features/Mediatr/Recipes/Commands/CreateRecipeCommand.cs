using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Recipes.Commands
{
    public class CreateRecipeCommand:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public IFormFile RecipeImage { get; set; }
        public List<int> MaterialIds { get; set; }


    }
}
