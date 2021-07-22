using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Project : UpdatableModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("contact")]
        public Uri Contact { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("contact_name")]
        public string ContactName { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("contract_po_reference")]
        public string ContractPoReference { get; set; }
        [JsonProperty("uses_project_invoice_sequence")]
        public bool UsesProjectInvoiceSequence { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("budget")]
        public decimal Budget { get; set; }
        [JsonProperty("budget_units")]
        public string BudgetUnits { get; set; }
        [JsonProperty("hours_per_day")]
        public decimal HoursPerDay { get; set; }
        [JsonProperty("normal_billing_rate")]
        public decimal NormalBillingRate { get; set; }
        [JsonProperty("billing_period")]
        public string BillingPeriod { get; set; }
        [JsonProperty("is_ir35")]
        public bool IsIr35 { get; set; }
        [JsonProperty("starts_on")]
        public DateTime StartsOn { get; set; }
        [JsonProperty("ends_on")]
        public DateTime EndsOn { get; set; }
        [JsonProperty("include_unbilled_time_in_profitability")]
        public bool IncludeUnbilledTimeInProfitability { get; set; }
    }

    public static class ProjectBudgetUnits
    {
        public static string Hours = "Hours";
        public static string Days = "Days";
        public static string Monetary = "Monetary";
    }

    public static class ProjectStatus
    {
        public static string Active = "Active";
        public static string Completed = "Completed";
        public static string Cancelled = "Cancelled";
        public static string Hidden = "Hidden";
    }

    public static class ProjectBillingPeriod
    {
        public static string Hour = "hour";
        public static string Day = "day";
    }

    public class ProjectWrapper
    {
        public ProjectWrapper()
        {
            project = null;
        }

        public Project project { get; set; }
    }

    public class ProjectsWrapper
    {
        public ProjectsWrapper()
        {
            projects = new List<Project>();
        }

        public List<Project> projects { get; set; }
    }
}




