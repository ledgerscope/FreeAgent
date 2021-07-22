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
        [JsonProperty("suffers_cis_deduction")]
        public bool SuffersCisDeduction { get; set; } //TODO_FA: See if this maybe goes to ControlTransactionItemModel (check other entities: Bills, ...)
    }
}

