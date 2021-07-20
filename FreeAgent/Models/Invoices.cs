using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent
{
    public class Invoice : UpdatableModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        public Invoice() : base()
        {
            invoice_items = new List<InvoiceItem>();
        }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("long_status")]
        public string LongStatus { get; set; }
        [JsonProperty("contact")]
        public Uri Contact { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
        [JsonProperty("include_timeslips")]
        public string IncludeTimeslips { get; set; }
        [JsonProperty("include_expenses")]
        public string IncludeExpenses { get; set; }
        [JsonProperty("include_estimates")]
        public string IncludeEstimates { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }



        public double discount_percent { get; set; }


        public string due_on { get; set; }

        public double exchange_rate { get; set; }

        public int payment_terms_in_days { get; set; }

        public string currency { get; set; }

        public string ec_status { get; set; }

        public string written_off_date { get; set; }

        public double net_value { get; set; }

        public double sales_tax_value { get; set; }

        public double due_value { get; set; }

        public double paid_value { get; set; }

        public string comments { get; set; }

        public List<InvoiceItem> invoice_items { get; set; }
    }

    public class InvoiceItem
    {
        public string url { get; set; }

        public int position { get; set; }

        public string item_type { get; set; }

        public double quantity { get; set; }

        public double price { get; set; }

        public string description { get; set; }

        public double sales_tax_rate { get; set; }

        public double second_sales_tax_rate { get; set; }

        public string category { get; set; }
    }

    public static class InvoiceStatus
    {
        public static string Draft = "Draft";
        public static string ScheduledToEmail = "Scheduled To Email";
        public static string Open = "Open";
        public static string ZeroValue = "Zero Value";
        public static string Overdue = "Overdue";
        public static string Paid = "Paid";
        public static string Overpaid = "Overpaid";
        public static string Refunded = "Refunded";
        public static string WrittenOff = "Written-off";
        public static string PartWrittenOff = "Part written-off";
    }

    public static class InvoiceECStatus
    {
        public static string NonEc = "Non-Ec";
        public static string ECGoods = "EC Goods";
        public static string ECServices = "EC Services";
    }

    public static class InvoiceItemType
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
        public static string NoUnit = "No Unit";
    }

    public static class InvoiceViewFilter
    {
        public static string RecentOpenOrOverdue = "recent_open_or_overdue";
        public static string OpenOrOverdue = "open_or_overdue";
        public static string Draft = "draft";
        public static string ScheduledToEmail = "scheduled_to_email";
        public static string ThankYouEmails = "thank_you_emails";
        public static string ReminderEmails = "reminder_emails";
        private static string lastNMonths = "last_{0}_months";

        public static string LastNMonths(int months = 1)
        {
            return string.Format(lastNMonths, months);
        }
    }

    public class InvoiceWrapper
    {
        public InvoiceWrapper()
        {
            invoice = null;
        }

        public Invoice invoice { get; set; }
    }

    public class InvoicesWrapper
    {
        public InvoicesWrapper()
        {
            invoices = new List<Invoice>();
        }

        public List<Invoice> invoices { get; set; }
    }

    public class InvoiceEmailWrapper
    {
        public InvoiceEmailWrapper()
        {
            invoice = new InvoiceEmail();
        }

        public InvoiceEmail invoice { get; set; }
    }

    public class InvoiceEmail
    {
        public InvoiceEmail()
        {
            email = new InvoiceEmailDetail();
        }

        public InvoiceEmailDetail email { get; set; }
    }

    public class InvoiceEmailDetail
    {
        public string to { get; set; }

        public string @from { get; set; }

        public string subject { get; set; }

        public string body { get; set; }
    }
}




