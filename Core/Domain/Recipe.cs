﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Recipe:Entity
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  
        public string? RecipeImageUrl { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Rate> RateList { get; set; }
        public List<RecipeMaterial> MaterialList { get; set; }
    }
}
