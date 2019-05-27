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

        public string Preparation { get; set; }

        public List<IngredientAmount> Ingredients { get; set; }

        public string Price
        {
            get { return CalculatePrice(); }
        }

        public int Carbs
        {
            get { return CalculateTotalCarbs(); }
        }

        public int Calories
        {
            get { return CalculateTotalCalories(); }
        }

        public int Proteins
        {
            get { return CalculateTotalProteins(); }
        }

        public int Fat
        {
            get { return CalculateTotalFat(); }
        }

// Voor json
        public Recipe()
        {
        }

        public Recipe(string name, string preparation, List<IngredientAmount> ingredients)
        {
            Name = name;
            Preparation = preparation;
            Ingredients = ingredients;
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

        private int CalculateTotalCarbs()
        {
            int total = 0;
            foreach (IngredientAmount amount in Ingredients)
            {
                total += amount.Ingredient.Carbs * amount.Amount;
            }

            return total;
        }
        
        private int CalculateTotalCalories()
        {
            int total = 0;
            foreach (IngredientAmount amount in Ingredients)
            {
                total += amount.Ingredient.Calories * amount.Amount;
            }

            return total;
        }
        
        private int CalculateTotalFat()
        {
            int total = 0;
            foreach (IngredientAmount amount in Ingredients)
            {
                total += amount.Ingredient.Fat * amount.Amount;
            }

            return total;
        }
        
        private int CalculateTotalProteins()
        {
            int total = 0;
            foreach (IngredientAmount amount in Ingredients)
            {
                total += amount.Ingredient.Proteins * amount.Amount;
            }

            return total;
        }
    }
}