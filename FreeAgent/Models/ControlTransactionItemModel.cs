using Newtonsoft.Json;
using System;

namespace FreeAgent.Models
{
    public abstract class ControlTransactionItemModel : BaseModel
    {
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("sales_tax_rate")]
        public decimal SalesTaxRate { get; set; }
        [JsonProperty("second_sales_tax_rate")]
        public decimal SecondSalesTaxRate { get; set; }
        [JsonProperty("sales_tax_status")]
        public string SalesTaxStatus { get; set; }
        [JsonProperty("second_sales_tax_status")]
        public string SecondSalesTaxStatus { get; set; }
        [JsonProperty("stock_item")]
        public Uri StockItem { get; set; }
        [JsonProperty("category")]
        public Uri Category { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
    }
}

