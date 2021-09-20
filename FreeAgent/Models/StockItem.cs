using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class StockItem : BaseModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("opening_quantity")]
        public decimal OpeningQuantity { get; set; }
        [JsonProperty("opening_balance")]
        public decimal OpeningBalance { get; set; }
        [JsonProperty("cost_of_sale_category")]
        public Uri CostOfSaleCategory { get; set; }
        [JsonProperty("stock_on_hand")]
        public decimal StockOnHand { get; set; }
    }

    public class StockItemWrapper
    {
        public StockItemWrapper()
        {
            stock_item = null;
        }

        public StockItem stock_item { get; set; }
    }

    public class StockItemsWrapper
    {
        public StockItemsWrapper()
        {
            stock_items = new List<StockItem>();
        }

        public List<StockItem> stock_items { get; set; }
    }
}

