﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfRecipes.Wpf.Models
{
    public class Data
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Data()
        {
            Ingredients = new List<Ingredient>();
            Recipes = new List<Recipe>();
        }
    }
}
