using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Bill : ControlTransactionModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        //public Bill()
        //{
        //    //BillItems = new List<BillItem>();
        //    //EcStatus = ExpenseECStatus.None;
        //}

        [JsonProperty("category")]
        public Uri Category { get; set; }
        [JsonProperty("rebill_type")]
        public Uri RebillType { get; set; }
        [JsonProperty("rebill_factor")]
        public decimal RebillFactor { get; set; }
        [JsonProperty("rebill_to_project")]
        public Uri RebillToProject { get; set; }
        [JsonProperty("rebilled_on_invoice_item")]
        public Uri RebilledOnInvoiceItem { get; set; }
        [JsonProperty("recurring")]
        public bool Recurring { get; set; }
        [JsonProperty("recurring_end_date")]
        public DateTime RecurringEndDate { get; set; }
        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }
        [JsonProperty("bill_items")]
        public List<BillItem> BillItems { get; set; }
    }

    public static class BillStatus
    {
        public static string ZeroValue = "Zero Value";
        public static string Open = "Open";
        public static string Paid = "Paid";
        public static string Overdue = "Overdue";
        public static string Refunded = "Refunded";
    }

    public static class BillECStatus
    {
        public static string UKNonEc = "UK/Non-EC";
        public static string ECGoods = "EC Goods";
        public static string ECServices = "EC Services";
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




