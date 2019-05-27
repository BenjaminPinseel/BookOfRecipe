using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BookOfRecipes.Wpf.Models;

namespace BookOfRecipes.Wpf.Pages
{
    public partial class NewRecipe : Page
    {
        private Data data;
        private List<IngredientAmount> ingredientAmount = new List<IngredientAmount>();
     
        public NewRecipe(Data data)
        {
            this.data = data;
            InitializeComponent();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            IngredientAmount amount = (IngredientAmount) button.DataContext;
            ingredientAmount.Remove(amount);
            listIngredientPerRecipeList.Items.Refresh();
        }
    }
}