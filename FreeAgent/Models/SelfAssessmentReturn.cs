using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class SelfAssessmentReturn : BaseModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("period_ends_on")]
        public DateTime PeriodEndsOn { get; set; }
        [JsonProperty("period_starts_on")]
        public DateTime PeriodStartsOn { get; set; }
        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }
        [JsonProperty("filing_due_on")]
        public DateTime FilingDueOn { get; set; }
        [JsonProperty("filing_status")]
        public string FilingStatus { get; set; }
        [JsonProperty("filed_at")]
        public DateTime FiledAt { get; set; }
        [JsonProperty("filed_reference")]
        public string FiledReference { get; set; }

        public static class SelfAssessmentReturnFilingStatus
        {
            public static string Unfiled = "unfiled";
            public static string Pending = "pending";
            public static string Rejected = "rejected";
            public static string ProvisionallyFiled = "provisionally_filed";
            public static string Filed = "filed";
            public static string MarkedAsFiled = "marked_as_filed";
        }
    }

    public class Payment
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("due_on")]
        public DateTime DueOn { get; set; }
        [JsonProperty("amount_due")]
        public decimal AmountDue { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class SelfAssessmentReturnWrapper
    {
        public SelfAssessmentReturnWrapper()
        {
            self_assessment_return = null;
        }

        public SelfAssessmentReturn self_assessment_return { get; set; }
    }

    public class SelfAssessmentReturnsWrapper
    {
        public SelfAssessmentReturnsWrapper()
        {
            self_assessment_returns = new List<SelfAssessmentReturn>();
        }

        public List<SelfAssessmentReturn> self_assessment_returns { get; set; }
    }
}




