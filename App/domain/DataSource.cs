using App.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App.domain
{
    public class DataSource
    {

        #region API
        public async Task<RootObject> GetWeatherAsync(double lat, double lon)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={App.API_KEY}");
            var jsonstring = await response.Content.ReadAsStringAsync();
            var doc = JsonConvert.DeserializeObject<RootObject>(jsonstring);
            return doc;
        }

        public void GetLocalData()
        {
           
        }
        #endregion
    }
}
