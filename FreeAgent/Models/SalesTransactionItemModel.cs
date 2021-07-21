using Newtonsoft.Json;

namespace FreeAgent.Models
{
    public abstract class SalesTransactionItemModel : ControlTransactionItemModel
    {
        [JsonProperty("position")]
        public decimal Position { get; set; }
        [JsonProperty("item_type")]
        public string ItemType { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}

