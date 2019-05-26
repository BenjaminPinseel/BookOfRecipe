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
        public string Description { get; set; }
        public List<IngredientAmount> Ingredients { get; set; }

        public string Price
        {
            get { return "€€€"; }
        }

        public int Carbs { get; }
        public int Calories { get;  }
        public int Proteins { get; }
        public int Fat { get; }

        // Voor json
        public Recipe() { }

        public Recipe(string name, string description, List<IngredientAmount> ingredients)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
        }
    }
}
