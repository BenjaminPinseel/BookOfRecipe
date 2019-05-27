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
        private List<IngredientAmount> ingredientAmounts = new List<IngredientAmount>();
        public string Name { get; set; }
        public string Description { get; set; }

        public List<IngredientAmount> Ingredients
        {
            get { return ingredientAmounts; }
        }

        public string Price
        {
            get { return CalculatePrice(); }
        }

        public int Carbs
        {
            get
            {
                int total = 0;
                foreach (IngredientAmount amount in Ingredients)
                {
                    total += amount.Ingredient.Carbs * amount.Amount;
                }

                return total;
            }
        }

        public int Calories
        {
            get
            {
                int total = 0;
                foreach (IngredientAmount amount in Ingredients)
                {
                    total += amount.Ingredient.Calories * amount.Amount;
                }

                return total;
            }
        }

        public int Proteins
        {
            get
            {
                int total = 0;
                foreach (IngredientAmount amount in Ingredients)
                {
                    total += amount.Ingredient.Proteins * amount.Amount;
                }

                return total;
            }
        }

        public int Fat
        {
            get
            {
                int total = 0;
                foreach (IngredientAmount amount in Ingredients)
                {
                    total += amount.Ingredient.Fat * amount.Amount;
                }

                return total;
            }
        }

// Voor json
        public Recipe()
        {
        }

        public Recipe(string name, string description, List<IngredientAmount> ingredients)
        {
            Name = name;
            Description = description;
            ingredientAmounts = ingredients;
        }

        private string CalculatePrice()
        {
            int total = 0;
            foreach (IngredientAmount amount in Ingredients)
            {
                total += amount.Ingredient.Price * amount.Amount;
            }

            if (total < 5)
            {
                return "€";
            }

            if (total < 10)
            {
                return "€€";
            }

            if (total < 20)
            {
                return "€€€";
            }

            return "€€€€";
        }
    }
}