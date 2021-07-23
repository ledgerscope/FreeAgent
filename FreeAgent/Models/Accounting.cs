using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class TrialBalanceSummary
    {
        [JsonProperty("category")]
        public Uri Category { get; set; }
        [JsonProperty("nominal_code")]
        public string NominalCode { get; set; }
        [JsonProperty("display_nominal_code")]
        public string DisplayNominalCode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("total")]
        public decimal Total { get; set; }
        [JsonProperty("bank_account")]
        public Uri BankAccount { get; set; }
        [JsonProperty("user")]
        public Uri User { get; set; }
    }

    public class TrialBalanceSummaryWrapper
    {
        public TrialBalanceSummaryWrapper()
        {
            trial_balance_summary = new List<TrialBalanceSummary>();
        }

        public List<TrialBalanceSummary> trial_balance_summary { get; set; }
    }
}

