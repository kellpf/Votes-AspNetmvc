using Desafio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Repositories
{
    public class RestaurantRepository
    {
        public RestaurantRepository()
        {
      
        }

        public List<Restaurant> ReadFile(string fileJson)
        {
            var nameFile = $"Files/{fileJson}";
            var file = File.ReadAllText(nameFile);
            var json = JsonConvert.DeserializeObject<List<Restaurant>>(file);
            return json;
        }

        public List<Restaurant> GetRestaurants()
        {
            var file = $"Files/restaurant.json";
            var readFile = File.ReadAllText(file);
            var json = JsonConvert.DeserializeObject<List<Restaurant>>(readFile);

            return json;
        }
    }
}