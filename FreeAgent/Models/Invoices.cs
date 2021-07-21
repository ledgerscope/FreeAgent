using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Invoice : UpdatableModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
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
        [JsonProperty("due_on")]
        public DateTime DueOn { get; set; }
        [JsonProperty("payment_terms_in_days")]
        public int PaymentTermsInDays { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("cis_rate")]
        public string CisRate { get; set; }
        [JsonProperty("cis_deduction_rate")]
        public decimal CisDeductionRate { get; set; }
        [JsonProperty("cis_deduction")]
        public decimal CisDeduction { get; set; }
        [JsonProperty("cis_deduction_suffered")]
        public decimal CisDeductionSuffered { get; set; }
        [JsonProperty("comments")]
        public string Comments { get; set; }
        [JsonProperty("send_new_invoice_emails")]
        public bool SendNewInvoiceEmails { get; set; }
        [JsonProperty("send_reminder_emails")]
        public bool SendReminderEmails { get; set; }
        [JsonProperty("send_thank_you_emails")]
        public bool SendThankYouEmails { get; set; }
        [JsonProperty("discount_percent")]
        public decimal DiscountPercent { get; set; }
        [JsonProperty("client_contact_name")]
        public string ClientContactName { get; set; }
        [JsonProperty("payment_terms")]
        public string PaymentTerms { get; set; }
        [JsonProperty("po_reference")]
        public string PoReference { get; set; }
        [JsonProperty("bank_account")]
        public string BankAccount { get; set; }
        [JsonProperty("omit_header")]
        public bool OmitHeader { get; set; }
        [JsonProperty("show_project_name")]
        public bool ShowProjectName { get; set; }
        [JsonProperty("always_show_bic_and_iban")]
        public bool AlwaysShowBicAndIban { get; set; }
        [JsonProperty("ec_status")]
        public string EcStatus { get; set; }
        [JsonProperty("place_of_supply")]
        public string PlaceOfSupply { get; set; }
        [JsonProperty("net_value")]
        public decimal NetValue { get; set; }
        [JsonProperty("exchange_rate")]
        public decimal ExchangeRate { get; set; }
        [JsonProperty("involves_sales_tax")]
        public bool InvolvesSalesTax { get; set; }
        [JsonProperty("sales_tax_value")]
        public decimal SalesTaxValue { get; set; }
        [JsonProperty("second_sales_tax_value")]
        public decimal SecondSalesTaxValue { get; set; }
        [JsonProperty("total_value")]
        public decimal TotalValue { get; set; }
        [JsonProperty("paid_value")]
        public decimal PaidValue { get; set; }
        [JsonProperty("due_value")]
        public decimal DueValue { get; set; }
        [JsonProperty("is_interim_uk_vat")]
        public bool IsInterimUKVat { get; set; }
        [JsonProperty("paid_on")]
        public DateTime PaidOn { get; set; }
        [JsonProperty("written_off_date")]
        public DateTime WrittenOffDate { get; set; }
        [JsonProperty("recurring_invoice")]
        public Uri RecurringInvoice { get; set; }
        [JsonProperty("payment_url")]
        public Uri PaymentUrl { get; set; }
        [JsonProperty("payment_methods")]
        public Dictionary<string, bool> PaymentMethods { get; set; }
        [JsonProperty("invoice_items")]
        public List<InvoiceItem> InvoiceItems { get; set; }
    }

    public class InvoiceItem
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("position")]
        public decimal Position { get; set; }
        [JsonProperty("item_type")]
        public string ItemType { get; set; }
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("sales_tax_rate")]
        public decimal SalesTaxRate { get; set; }
        [JsonProperty("second_sales_tax_rate")]
        public decimal SecondSalesTaxRate { get; set; }
        [JsonProperty("sales_tax_status")]
        public string SalesTaxStatus { get; set; }
        [JsonProperty("second_sales_tax_status")]
        public string SecondSalesTaxStatus { get; set; }
        [JsonProperty("stock_item")]
        public Uri StockItem { get; set; }
        [JsonProperty("category")]
        public Uri Category { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
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




