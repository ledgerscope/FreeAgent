using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class RecurringInvoice : Invoice
    {
        [JsonProperty("frequency")]
        public string Frequency { get; set; }
        [JsonProperty("recurring_status")]
        public string RecurringStatus { get; set; }
        [JsonProperty("recurring_end_date")]
        public DateTime RecurringEndDate { get; set; }
        [JsonProperty("next_recurs_on")]
        public DateTime NextRecursOn { get; set; }
    }

    public static class RecurringFrequency
    {
        public static string Weekly = "Weekly";
        public static string TwoWeekly = "Two Weekly";
        public static string FourWeekly = "Four Weekly";
        public static string Monthly = "Monthly";
        public static string TwoMonthly = "Two Monthly";
        public static string Quarterly = "Quarterly";
        public static string Biannually = "Biannually";
        public static string Annually = "Annually";
        public static string TwoYearly = "2-Yearly";
    }

    public static class RecurringStatus
    {
        public static string Draft = "Draft";
        public static string Active = "Active";
    }

    public class RecurringInvoiceWrapper
    {
        public RecurringInvoiceWrapper()
        {
            recurring_invoice = null;
        }

        public RecurringInvoice recurring_invoice { get; set; }
    }

    public class RecurringInvoicesWrapper
    {
        public RecurringInvoicesWrapper()
        {
            recurring_invoices = new List<RecurringInvoice>();
        }

        public List<RecurringInvoice> recurring_invoices { get; set; }
    }
}




