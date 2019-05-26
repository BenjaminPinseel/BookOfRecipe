using BookOfRecipes.Wpf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfRecipes.Wpf.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public Price PriceRange { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int Carbs { get; private set; }
        public int Calories { get; private set; }
        public int Proteins { get; private set; }
        public int Fat { get; private set; }

        // Voor json
        public Recipe() { }

        public Recipe(string name, Price priceRange, List<Ingredient> ingredients)
        {
            Name = name;
            PriceRange = priceRange;
            Ingredients = ingredients;
        }
    }
}
