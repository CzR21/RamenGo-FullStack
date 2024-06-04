using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Application.Models
{
    public class ErrorModel
    {
        [JsonProperty("error")]
        public string Error { get; set; } ///TGeste
    }
}
