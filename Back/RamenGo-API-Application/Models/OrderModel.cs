using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Application.Models
{
    public class OrderRequestModel
    {
        [JsonProperty("brothId")]
        public string BrothId { get; set; }

        [JsonProperty("proteinId")]
        public string ProteinId { get; set; }
    }

    public class OrderResponseModel
    {
        [JsonProperty("id")]
        public string BrothId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

    public class OrderIdModel
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }
    }
}
