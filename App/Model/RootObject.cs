using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    
    
    public class RootObject
    {
        [JsonProperty("weather")]
        public IList<Weather> Clima { get; set; }

        [JsonProperty("main")]
        public Main Principal { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    
    public partial class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Principal { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    
    public partial class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }
    }


}
