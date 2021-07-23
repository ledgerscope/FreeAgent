using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class StockItem : BaseModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("opening_quantity")]
        public int OpeningQuantity { get; set; }
        [JsonProperty("opening_balance")]
        public decimal OpeningBalance { get; set; }
        [JsonProperty("cost_of_sale_category")]
        public Uri CostOfSaleCategory { get; set; }
        [JsonProperty("stock_on_hand")]
        public int StockOnHand { get; set; }
    }

    public class StockItemWrapper
    {
        public StockItemWrapper()
        {
            stockItem = null;
        }

        public StockItem stockItem { get; set; }
    }

    public class StockItemsWrapper
    {
        public StockItemsWrapper()
        {
            stockItems = new List<StockItem>();
        }

        public List<StockItem> stockItems { get; set; }
    }
}

