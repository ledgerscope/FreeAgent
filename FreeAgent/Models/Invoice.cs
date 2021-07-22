using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Invoice : SalesTransactionModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        //public Invoice()
        //{
        //    //InvoiceItems = new List<InvoiceItem>();
        //}

        [JsonProperty("include_timeslips")]
        public string IncludeTimeslips { get; set; }
        [JsonProperty("include_expenses")]
        public string IncludeExpenses { get; set; }
        [JsonProperty("include_estimates")]
        public string IncludeEstimates { get; set; }
        [JsonProperty("send_new_invoice_emails")]
        public bool SendNewInvoiceEmails { get; set; }
        [JsonProperty("send_reminder_emails")]
        public bool SendReminderEmails { get; set; }
        [JsonProperty("send_thank_you_emails")]
        public bool SendThankYouEmails { get; set; }
        [JsonProperty("always_show_bic_and_iban")]
        public bool AlwaysShowBicAndIban { get; set; }
        [JsonProperty("paid_value")]
        public decimal PaidValue { get; set; }
        [JsonProperty("recurring_invoice")]
        public Uri RecurringInvoice { get; set; }
        [JsonProperty("payment_url")]
        public Uri PaymentUrl { get; set; }
        [JsonProperty("payment_methods")]
        public Dictionary<string, bool> PaymentMethods { get; set; }
        [JsonProperty("invoice_items")]
        public List<InvoiceItem> InvoiceItems { get; set; }
    }

    public class InvoiceItem : SalesTransactionItemModel { }

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
        public static string UKNonEc = "UK/Non-EC";
        public static string ECGoods = "EC Goods";
        public static string ECServices = "EC Services";
        public static string ECVatMoss = "EC VAT MOSS";
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
        public static string Open = "open";
        public static string Overdue = "overdue";
        public static string OpenOrOverdue = "open_or_overdue";
        public static string Draft = "draft";
        public static string Paid = "paid";
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




