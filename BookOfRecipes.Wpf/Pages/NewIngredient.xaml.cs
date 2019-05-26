using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BookOfRecipes.Wpf.Models;

namespace BookOfRecipes.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for NewIngredient.xaml
    /// </summary>
    public partial class NewIngredient : Page
    {
        private Data data;
        private NavigationService navigationService;
        private Ingredient newIngredient = new Ingredient();
        
        public NewIngredient(NavigationService navigationService, Data data)
        {
            this.data = data;
            this.navigationService = navigationService;
            Initialize();
        }

        private void Initialize()
        {
            DataContext = newIngredient;
            InitializeComponent();
            btnAddIngredient.IsEnabled = false;
        }

        private void TextField_Changed(object sender, TextChangedEventArgs e)
        {
            if (btnAddIngredient != null)
            {
                btnAddIngredient.IsEnabled = IsButtonEnabled();
            }
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            data.Ingredients.Add(newIngredient);
            navigationService.Navigate(new IngredientList(data));
        }

        private bool IsButtonEnabled()
        {
            bool nameValid = !String.IsNullOrWhiteSpace(txtName.Text);
            bool priceValid = int.TryParse(txtPrice.Text, out int price);
            bool carbsValid = int.TryParse(txtCarbs.Text, out int carbs);
            bool proteinsValid = int.TryParse(txtProteins.Text, out int proteins);
            bool fatValid = int.TryParse(txtFat.Text, out int fat);
            bool caloriesValid = int.TryParse(txtCalories.Text, out int calories);

            return nameValid && priceValid && carbsValid && proteinsValid && fatValid && caloriesValid;
        }
    
    }


}
