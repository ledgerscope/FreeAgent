using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class ProfitAndLoss
    {
        [JsonProperty("from")]
        public DateTime From { get; set; }
        [JsonProperty("to")]
        public DateTime To { get; set; }
        [JsonProperty("income")]
        public decimal Income { get; set; }
        [JsonProperty("expenses")]
        public decimal Expenses { get; set; }
        [JsonProperty("operating_profit")]
        public decimal OperatingProfit { get; set; }
        [JsonProperty("retained_profit")]
        public decimal RetainedProfit { get; set; }
        [JsonProperty("retained_profit_brought_forward")]
        public decimal RetainedProfitBroughtForward { get; set; }
        [JsonProperty("retained_profit_carried_forward")]
        public decimal RetainedProfitCarriedForward { get; set; }
        [JsonProperty("less")]
        public List<LessItem> Less { get; set; }
    }

    public class LessItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("total")]
        public decimal Total { get; set; }
    }

    public class ProfitAndLossWrapper
    {
        public ProfitAndLossWrapper()
        {
            profit_and_loss_summary = null;
        }
        public ProfitAndLoss profit_and_loss_summary { get; set; }
    }
}

