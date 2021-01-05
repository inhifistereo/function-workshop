using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace function
{
    public class Products
    {
        [JsonProperty("productDescription")]
        public string productDescription { get; set; }
        [JsonProperty("productId")]
        public string propertyId { get; set; }
        [JsonProperty("productName")]
        public string productName { get; set; }
        [JsonProperty("timestamp")]
        public DateTime timestamp { get; set; }
    }
}
