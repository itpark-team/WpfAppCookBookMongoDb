using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            FoodRecipes = _homefoodRepository.GetAll();
        }

        [ObservableProperty]
        public List<FoodRecipe> _foodRecipes;
    }
}
