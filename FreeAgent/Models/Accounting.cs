using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    /// <summary>
    /// TrialBalanceSummary is inheriting from BaseModel just so we can make AccountingClient inherit from ResourceClient,
    /// and thus use the All method which takes care of paging.
    /// The only drawback is that we have Url property now on TrialBalanceSummary which will always be null (API doesn't return Url 
    /// for TrialBalanceSummary), so we shouldn't use TrialBalanceSummary.Url anywhere!
    /// </summary>
    public class TrialBalanceSummary : BaseModel
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
            trial_balance_summary = null;
        }

        public TrialBalanceSummary trial_balance_summary { get; set; }
    }

    public class TrialBalancesSummaryWrapper
    {
        public TrialBalancesSummaryWrapper()
        {
            trial_balance_summary = new List<TrialBalanceSummary>();
        }

        public List<TrialBalanceSummary> trial_balance_summary { get; set; }
    }
}

