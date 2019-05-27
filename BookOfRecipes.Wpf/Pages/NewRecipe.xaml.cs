using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BookOfRecipes.Wpf.Models;

namespace BookOfRecipes.Wpf.Pages
{
    public partial class NewRecipe : Page
    {
        private Data data;
        private NavigationService navigationService;
        private List<IngredientAmount> ingredientAmount = new List<IngredientAmount>();
     
        public NewRecipe(NavigationService navigationService, Data data)
        {
            this.data = data;
            this.navigationService = navigationService;
            InitializeComponent();
            listIngredientPerRecipeList.ItemsSource = ingredientAmount;
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            IngredientAmount amount = (IngredientAmount) button.DataContext;
            ingredientAmount.Remove(amount);
            listIngredientPerRecipeList.Items.Refresh();
        }

        private void AddIngredient_OnClick(object sender, RoutedEventArgs e)
        {
            ingredientAmount.Add(new IngredientAmount());
            listIngredientPerRecipeList.Items.Refresh();
        }
        
        private void AddRecipe_OnClick(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string preparation = txtPreparation.Text;
            Recipe newRecipe = new Recipe(name, preparation, ingredientAmount);
            data.Recipes.Add(newRecipe);
            navigationService.Navigate(new RecipeList(data));
        }
    }
}