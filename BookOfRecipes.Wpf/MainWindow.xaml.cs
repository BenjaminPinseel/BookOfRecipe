using BookOfRecipes.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using BookOfRecipes.Wpf.Files;
using BookOfRecipes.Wpf.Pages;
using Microsoft.Win32;

namespace BookOfRecipes.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string dialogFilter = "Json files(*.json)|*.json";
        private FileHandling fileHandling;
        private Data data = new Data();
       
        public MainWindow()
        {
            fileHandling = new FileHandling();
            Initialize();
        }
        
        private void Initialize()
        {
            InitializeComponent();
            OpenRecipeView();
        }

        private void BtnRecipes_Click(object sender, RoutedEventArgs e)
        {
            frmMainFrame.NavigationService.Navigate(new RecipeList(data));
        }

        private void BtnIngredients_Click(object sender, RoutedEventArgs e)
        {
            frmMainFrame.NavigationService.Navigate(new IngredientList(data));
        }
        
        private void BtnAddIngredients_Click(object sender, RoutedEventArgs e)
        {
            frmMainFrame.NavigationService.Navigate(new NewIngredient(frmMainFrame.NavigationService, data));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog {Filter = dialogFilter};
            if (saveFileDialog.ShowDialog() == true)
            {
                fileHandling.Save(saveFileDialog.FileName, data);
            }
            OpenRecipeView();
        }
        
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog{Filter = dialogFilter};
            if (openFileDialog.ShowDialog() == true)
            {
                data = fileHandling.Load(openFileDialog.FileName);
            }

            Ingredient tomaat = new Ingredient("Tomaat", 1, 5, 50,2,3); 
            Ingredient garnaal = new Ingredient("Garnaal", 10, 0, 100,2,3); 
            
            data.Ingredients.Add(tomaat);
            data.Ingredients.Add(garnaal);
            
            IngredientAmount aantalTomaat = new IngredientAmount(tomaat, 300, "gram");
            IngredientAmount aantalGarnaal = new IngredientAmount(garnaal, 100, "gram");

            IngredientAmount[] ingredienten = new IngredientAmount[] {aantalGarnaal, aantalTomaat};
            Recipe tomaatGarnaal = new Recipe("Tomaat Garnaal","Overheerlijk recept !", ingredienten.ToList());
            
            data.Recipes.Add(tomaatGarnaal);
            OpenRecipeView();
        }

        private void OpenRecipeView()
        {
            frmMainFrame.NavigationService.Navigate(new RecipeList(data));
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
