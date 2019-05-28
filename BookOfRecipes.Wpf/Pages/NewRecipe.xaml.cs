using System;
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
         private string[] validUnits = {"g", "kg", "l", "ml"};
     
        public NewRecipe(NavigationService navigationService, Data data)
        {
            this.data = data;
            this.navigationService = navigationService;
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            listIngredientPerRecipeList.ItemsSource = ingredientAmount;
            cmbUnits.ItemsSource = validUnits;
            cmbIngredients.ItemsSource = GetIngredientNames();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            IngredientAmount amount = (IngredientAmount) button.DataContext;
            ingredientAmount.Remove(amount);
            listIngredientPerRecipeList.Items.Refresh();
            btnIngredientAdd.IsEnabled = false;
        }

        private void AddIngredient_OnClick(object sender, RoutedEventArgs e)
        {
            string unit = (string) cmbIngredients.SelectedItem;
            string ingredientName = (string) cmbIngredients.SelectedItem;
            int amount = int.Parse(txtAmount.Text);
            Ingredient selectedIngredient = data.GetIngredientByName(ingredientName);
            ingredientAmount.Add(new IngredientAmount(selectedIngredient, amount, unit));
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
        
        private List<string> GetIngredientNames()
        {
            List<string> names = new List<string>();
            foreach (Ingredient ingredient in data.Ingredients)
            {
                names.Add(ingredient.Name);
            }
            return names;
        }
        

        private void TxtAmount_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeIngredientButtonState();
        }
        
        private void CmbUnits_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeIngredientButtonState();
        }
        
        private void CmbIngredients_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeIngredientButtonState();
        }
        
        private void ChangeIngredientButtonState()
        {
            btnIngredientAdd.IsEnabled = IngredientValid();
        }
        private bool IngredientValid()
        {
            string ingredientName = (string) cmbIngredients.SelectedItem;
            bool amountIsValidInt = int.TryParse(txtAmount.Text, out int amount);
            
            return !String.IsNullOrWhiteSpace(ingredientName) && amountIsValidInt;
        }



    }
}