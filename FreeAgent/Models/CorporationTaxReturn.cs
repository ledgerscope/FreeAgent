using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class CorporationTaxReturn : BaseModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("period_ends_on")]
        public DateTime PeriodEndsOn { get; set; }
        [JsonProperty("period_starts_on")]
        public DateTime PeriodStartsOn { get; set; }
        [JsonProperty("amount_due")]
        public decimal AmountDue { get; set; }
        [JsonProperty("payment_due_on")]
        public DateTime PaymentDueOn { get; set; }
        [JsonProperty("payment_status")]
        public string PaymentStatus { get; set; }
        [JsonProperty("filing_due_on")]
        public DateTime FilingDueOn { get; set; }
        [JsonProperty("filing_status")]
        public string FilingStatus { get; set; }
        [JsonProperty("filed_at")]
        public DateTime FiledAt { get; set; }
        [JsonProperty("filed_reference")]
        public string FiledReference { get; set; }

        public static class CorporationTaxReturnFilingStatus
        {
            public static string Draft = "draft";
            public static string Unfiled = "unfiled";
            public static string Pending = "pending";
            public static string Rejected = "rejected";
            public static string Filed = "filed";
            public static string MarkedAsFiled = "marked_as_filed";
        }
    }

    public class CorporationTaxReturnWrapper
    {
        public CorporationTaxReturnWrapper()
        {
            corporation_tax_return = null;
        }

        public CorporationTaxReturn corporation_tax_return { get; set; }
    }

    public class CorporationTaxReturnsWrapper
    {
        public CorporationTaxReturnsWrapper()
        {
            corporation_tax_returns = new List<CorporationTaxReturn>();
        }

        public List<CorporationTaxReturn> corporation_tax_returns { get; set; }
    }
}




