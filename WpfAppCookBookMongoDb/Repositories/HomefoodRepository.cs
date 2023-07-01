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


        public void AddNew()
        {
            FoodRecipe foodRecipe = new FoodRecipe()
            {
                FoodCost = (decimal)23.1,
                Rating = (decimal)4.5,
                Name = "Апельсиновый тарт",
                PicturePath = "apelsinovyj-desert.jpg",
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

            _foodRecipes.InsertOne(foodRecipe);
        }

        public List<FoodRecipe> GetAll()
        {
           return _foodRecipes.Find(new BsonDocument()).ToList();
        }

    }
}
