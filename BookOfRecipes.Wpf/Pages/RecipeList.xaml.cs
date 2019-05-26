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

        public RecipeList(Data data)
        {
            this.data = data;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            lstRecipeList.ItemsSource = data.Recipes;
        }
    }
}
