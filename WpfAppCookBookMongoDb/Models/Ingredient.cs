using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCookBookMongoDb.Models
{
    internal class Ingredient
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Amount { get; set; }
    }
}
