using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AJAX.DummyData.Model
{
   public class Product
    {
        public int Id { get; set; }
        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
