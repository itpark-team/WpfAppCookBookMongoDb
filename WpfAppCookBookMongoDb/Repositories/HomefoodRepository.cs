using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppCookBookMongoDb.Models;

namespace WpfAppCookBookMongoDb.Repositories
{
    internal class HomefoodRepository
    {
        private IMongoCollection<FoodRecipe> _foodRecipes;

        public HomefoodRepository(IMongoCollection<FoodRecipe> foodRecipes)
        {
            _foodRecipes = foodRecipes;
        }


        public void AddNew(FoodRecipe foodRecipe)
        {
           
            _foodRecipes.InsertOne(foodRecipe);
        }

        public List<FoodRecipe> GetAll()
        {
           return _foodRecipes.Find(new BsonDocument()).ToList();
        }

        public void DeleteOne(FoodRecipe foodRecipe)
        {
            _foodRecipes.DeleteOne(item => item.Id == foodRecipe.Id);
        }
    }
}
