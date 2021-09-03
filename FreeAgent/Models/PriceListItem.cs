using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class PriceListItem : BaseModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty("item_type")]
        public string ItemType { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("vat_status")]
        public string VatStatus { get; set; }
        [JsonProperty("stock_item")]
        public Uri StockItem { get; set; }
        [JsonProperty("sales_tax_rate")]
        public decimal SalesTaxRate { get; set; }
        [JsonProperty("second_sales_tax_rate")]
        public decimal SecondSalesTaxRate { get; set; }
        [JsonProperty("category")]
        public Uri Category { get; set; }
    }

    public static class PriceListItemType
    {
        public static string Hours = "Hours";
        public static string Days = "Days";
        public static string Weeks = "Weeks";
        public static string Months = "Months";
        public static string Years = "Years";
        public static string Products = "Products";
        public static string Services = "Services";
        public static string Training = "Training";
        public static string Expenses = "Expenses";
        public static string Comment = "Comment";
        public static string Bills = "Bills";
        public static string Discount = "Discount";
        public static string Credit = "Credit";
        public static string VAT = "VAT";
        public static string Stock = "Stock";
    }

    public static class PriceListItemVatStatus
    {
        public static string Reduced = "reduced";
        public static string Standard = "standard";
        public static string Zero = "zero";
    }

    public class PriceListItemWrapper
    {
        public PriceListItemWrapper()
        {
            priceListItem = null;
        }

        public PriceListItem priceListItem { get; set; }
    }

    public class PriceListItemsWrapper
    {
        public PriceListItemsWrapper()
        {
            priceListItems = new List<PriceListItem>();
        }

        public List<PriceListItem> priceListItems { get; set; }
    }
}

