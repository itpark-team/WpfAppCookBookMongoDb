using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCookBookMongoDb.Models
{
    internal class FoodRecipe
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string PicturePath { get; set; }

        public decimal FoodCost { get; set; }

        public decimal Rating { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}
