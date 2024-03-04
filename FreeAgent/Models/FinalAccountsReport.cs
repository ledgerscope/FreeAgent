using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class FinalAccountsReport : BaseModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("period_ends_on")]
        public DateTime PeriodEndsOn { get; set; }
        [JsonProperty("period_starts_on")]
        public DateTime PeriodStartsOn { get; set; }
        [JsonProperty("filing_due_on")]
        public DateTime FilingDueOn { get; set; }
        [JsonProperty("filing_status")]
        public string FilingStatus { get; set; }
        [JsonProperty("filed_at")]
        public DateTime FiledAt { get; set; }
        [JsonProperty("filed_reference")]
        public string FiledReference { get; set; }

        public static class FinalAccountsReportFilingStatus
        {
            public static string Draft = "draft";
            public static string Unfiled = "unfiled";
            public static string Pending = "pending";
            public static string Rejected = "rejected";
            public static string Filed = "filed";
            public static string MarkedAsFiled = "marked_as_filed";
        }
    }

    public class FinalAccountsReportWrapper
    {
        public FinalAccountsReportWrapper()
        {
            final_accounts_report = null;
        }

        public FinalAccountsReport final_accounts_report { get; set; }
    }

    public class FinalAccountsReportsWrapper
    {
        public FinalAccountsReportsWrapper()
        {
            final_accounts_reports = new List<FinalAccountsReport>();
        }

        public List<FinalAccountsReport> final_accounts_reports { get; set; }
    }
}




