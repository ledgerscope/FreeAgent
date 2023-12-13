using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Bill : ControlTransactionModel, IAttachmentModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("rebill_type")]
        public Uri RebillType { get; set; }
        [JsonProperty("rebill_factor")]
        public decimal RebillFactor { get; set; }
        [JsonProperty("rebill_to_project")]
        public Uri RebillToProject { get; set; }
        [JsonProperty("rebilled_on_invoice_item")]
        public Uri RebilledOnInvoiceItem { get; set; }
        [JsonProperty("recurring")]
        public string Recurring { get; set; }
        [JsonProperty("recurring_end_date")]
        public DateTime RecurringEndDate { get; set; }
        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }
        [JsonProperty("bill_items")]
        public List<BillItem> BillItems { get; set; }

        public static class BillStatus
        {
            public static string ZeroValue = "Zero Value";
            public static string Open = "Open";
            public static string Paid = "Paid";
            public static string Overdue = "Overdue";
            public static string Refunded = "Refunded";
        }
    }

    public static class BillECStatus
    {
        public static string UKNonEc = "UK/Non-EC";
        public static string ECGoods = "EC Goods";
        public static string ECServices = "EC Services";
        public static string ReverseCharge = "Reverse Charge";
    }

    public static class BillRecurring
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

    public class BillItem : ControlTransactionItemModel
    {
        [JsonProperty("bill")]
        public Uri Bill { get; set; }
        [JsonProperty("total_value")]
        public decimal TotalValue { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonProperty("depreciation_schedule")]
        public string DepreciationSchedule { get; set; }
        [JsonProperty("manual_sales_tax_amount")]
        public decimal ManualSalesTaxAmount { get; set; }
        [JsonProperty("total_value_ex_tax")]
        public decimal TotalValueExTax { get; set; }
    }

    public class BillWrapper
    {
        public BillWrapper()
        {
            bill = null;
        }

        public Bill bill { get; set; }
    }

    public class BillsWrapper
    {
        public BillsWrapper()
        {
            bills = new List<Bill>();
        }

        public List<Bill> bills { get; set; }
    }
}




