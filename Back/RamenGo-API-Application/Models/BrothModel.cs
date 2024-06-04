using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Application.Models
{
    public class BrothModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("imageInactive")]
        public string ImageInactive { get; set; }

        [JsonProperty("imageActive")]
        public string ImageActive { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
