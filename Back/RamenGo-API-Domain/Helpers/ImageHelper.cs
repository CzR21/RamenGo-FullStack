using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Domain.Helpers
{
    public static class ImageHelper
    {
        public static string GetRamenImage(string ramenImage)
        {
            return ramenImage switch
            {
                "Chasu" => "https://ramen-go-frontend.s3.amazonaws.com/assets/ramens/chasu.png",
                "Yasai Vegetarian" => "https://ramen-go-frontend.s3.amazonaws.com/assets/ramens/vegetable.png",
                "Karaague" => "https://ramen-go-frontend.s3.amazonaws.com/assets/ramens/karaague.png",
                _ => throw new Exception("Invalid ramen.")
            };
        }
    }
}
