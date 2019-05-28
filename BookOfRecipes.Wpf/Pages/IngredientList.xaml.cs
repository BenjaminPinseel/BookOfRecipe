using BookOfRecipes.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookOfRecipes.Wpf
{
    /// <summary>
    /// Interaction logic for IngredientList.xaml
    /// </summary>
    public partial class IngredientList : Page
    {
        private Data data;
        private Ingredient selectedIngredient;

        public IngredientList(Data data)
        {
            this.data = data;
            Initialize(); 
        }
        
        private void Initialize()
        {
            InitializeComponent();
            lstIngredientsList.ItemsSource = data.Ingredients;
            btnDeleteIngredient.IsEnabled = false;
        }

        private void LstIngredientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIngredient = (Ingredient)lstIngredientsList.SelectedItem;
            stpIngredientStack.DataContext = selectedIngredient;
            btnDeleteIngredient.IsEnabled = selectedIngredient != null;
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            data.Ingredients.Remove(selectedIngredient);
            lstIngredientsList.Items.Refresh();
        }
    }
}
