using Newtonsoft.Json;
using System;

namespace FreeAgent.Models
{
    public abstract class ControlTransactionModel : UpdatableModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("long_status")]
        public string LongStatus { get; set; }
        [JsonProperty("contact")]
        public Uri Contact { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("due_on")]
        public DateTime DueOn { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("comments")]
        public string Comments { get; set; }
        [JsonProperty("ec_status")]
        public string EcStatus { get; set; }
        [JsonProperty("exchange_rate")]
        public decimal ExchangeRate { get; set; }
        [JsonProperty("total_value")]
        public decimal TotalValue { get; set; }
        [JsonProperty("paid_on")]
        public DateTime PaidOn { get; set; }

        // Sales tax properties
        [JsonProperty("sales_tax_value")]
        public decimal SalesTaxValue { get; set; }
        [JsonProperty("second_sales_tax_value")]
        public decimal SecondSalesTaxValue { get; set; }
    }
}

