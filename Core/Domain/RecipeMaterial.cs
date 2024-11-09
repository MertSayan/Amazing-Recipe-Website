using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecipeMaterial:Entity
    {
        public int RecipeMaterialId { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
