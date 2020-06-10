using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class DataService
    {
        private string Url = "https://zgrabauskasportfolio.azurewebsites.net/api/workoutapi/";
        public async Task<List<Treniruote>> GetTreniruotes()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(Url);

            var workouts = JsonConvert.DeserializeObject<List<Treniruote>>(json);

            return workouts;
        }
    }
}
