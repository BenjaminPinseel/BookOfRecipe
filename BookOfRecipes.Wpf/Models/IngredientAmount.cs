namespace BookOfRecipes.Wpf.Models
{
    public class IngredientAmount
    {
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        
        public IngredientAmount() {}

        public IngredientAmount(Ingredient ingredient, int amount, string unit)
        {
            Ingredient = ingredient;
            Amount = amount;
            Unit = unit;
        }
        
        
    }
}