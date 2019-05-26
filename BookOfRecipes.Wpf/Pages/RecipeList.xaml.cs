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
    /// Interaction logic for RecipeList.xaml
    /// </summary>
    public partial class RecipeList : Page
    {
        private Data data;
        private Recipe selectedRecipe;
        
        public RecipeList(Data data)
        {
            this.data = data;
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            lstRecipeList.ItemsSource = data.Recipes;
        }
        
        // TODO: add git
        private void LstRecipeList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRecipe = (Recipe)lstRecipeList.SelectedItem;
            stpRecipeDetail.DataContext = selectedRecipe;
            listIngredientPerRecipeList.ItemsSource = selectedRecipe.Ingredients;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            IngredientAmount amount = (IngredientAmount) button.DataContext;
            selectedRecipe.Ingredients.Remove(amount);
            listIngredientPerRecipeList.Items.Refresh();
        }
    }
}
