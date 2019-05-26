using BookOfRecipes.Wpf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfRecipes.Wpf.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Carbs { get; set; }
        public int Calories { get; set; }
        public int Proteins { get; set; }
        public int Fat { get; set; }

        // Voor Json
        public Ingredient() { }

        public Ingredient(string name, int price, int carbs, int calories, int proteins, int fat)
        {
            Name = name;
            Price = price;
            Carbs = carbs;
            Calories = calories;
            Proteins = proteins;
            Fat = fat;
        }

        public bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Name);
        }
    }
}
