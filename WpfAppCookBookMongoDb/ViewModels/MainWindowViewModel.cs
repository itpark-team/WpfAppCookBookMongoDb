using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppCookBookMongoDb.Db;
using WpfAppCookBookMongoDb.Models;
using WpfAppCookBookMongoDb.Repositories;

namespace WpfAppCookBookMongoDb.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private HomefoodRepository _homefoodRepository;

        public MainWindowViewModel()
        {
            _homefoodRepository = new HomefoodRepository(ConnetionManager.Instance.GetHomefoodCollection());

            FoodRecipes = new ObservableCollection<FoodRecipe>(_homefoodRepository.GetAll());

            FoodRecipeForAdd = new FoodRecipe()
            {
                FoodCost = (decimal)23.1,
                Rating = (decimal)4.5,
                Name = "Заполни меня",
                PicturePath = "http://www.topglobus.ru/skin/recepty/h/kulinarnyj-recept-apelsinovyj-desert.jpg",
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient()
                    {
                        Id = new ObjectId(),
                        Name = "Мука",
                        Amount = "2 с.л."
                    },
                    new Ingredient()
                    {
                        Id = new ObjectId(),
                        Name = "Яйца",
                        Amount = "3 шт."
                    },
                    new Ingredient()
                    {
                        Id = new ObjectId(),
                        Name = "Сахар",
                        Amount = "4 ч.л."
                    },
                }
            };
        }

        [ObservableProperty]
        public ObservableCollection<FoodRecipe> _foodRecipes;

        [ObservableProperty]
        public FoodRecipe _selectedFoodRecipe;

        [ObservableProperty]
        public FoodRecipe _foodRecipeForAdd;

        [RelayCommand]
        public void TestMethod()
        {
            MessageBox.Show(FoodRecipeForAdd.Name);
        }

        [RelayCommand]
        public void AddNewRecipe()
        {

            FoodRecipe insertRecipe = new FoodRecipe()
            {
                FoodCost = FoodRecipeForAdd.FoodCost,
                Name = FoodRecipeForAdd.Name,
                PicturePath = FoodRecipeForAdd.PicturePath,
                Rating = FoodRecipeForAdd.Rating,
                Ingredients = new List<Ingredient>(FoodRecipeForAdd.Ingredients)
            };

            _homefoodRepository.AddNew(insertRecipe);

            FoodRecipes.Add(insertRecipe);
        }

        [RelayCommand]
        public void DeleteCurrentRecipe()
        {
            if (SelectedFoodRecipe == null) { return; }
            _homefoodRepository.DeleteOne(SelectedFoodRecipe);

            FoodRecipes.Remove(SelectedFoodRecipe);
        }
    }
}
