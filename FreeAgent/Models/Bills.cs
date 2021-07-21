using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Bill : UpdatableModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        public Bill()
        {
            BillItems = new List<BillItem>();
            //EcStatus = ExpenseECStatus.None;
        }

        [JsonProperty("contact")]
        public Uri Contact { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("due_on")]
        public DateTime DueOn { get; set; }
        [JsonProperty("paid_on")]
        public DateTime PaidOn { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("long_status")]
        public string LongStatus { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("total_value")]
        public decimal TotalValue { get; set; }
        [JsonProperty("exchange_rate")]
        public decimal ExchangeRate { get; set; }
        [JsonProperty("ec_status")]
        public string EcStatus { get; set; }
        [JsonProperty("comments")]
        public string Comments { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
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
        public BillAttachment Attachment { get; set; }
        [JsonProperty("bill_items")]
        public List<BillItem> BillItems { get; set; }

        // Sales tax properties
        [JsonProperty("sales_tax_value")]
        public decimal SalesTaxValue { get; set; }
        [JsonProperty("salesecond_sales_tax_values_tax_value")]
        public decimal SecondSalesTaxValue { get; set; }
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

    public class BillAttachment
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("content_src")]
        public Uri ContentSrc { get; set; }
        [JsonProperty("content_type")]
        public string ContentType { get; set; }
        [JsonProperty("file_name")]
        public string FileName { get; set; }
        [JsonProperty("file_size")]
        public int FileSize { get; set; }
        //[JsonProperty("data ")]
        //public ? Data { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public static class BillAttachmentContentType
    {
        public const string Png = "image/png";
        public const string XPng = "image/x-png";
        public const string Jpeg = "image/jpeg";
        public const string Jpg = "image/jpg";
        public const string Gif = "image/gif";
        public const string Pdf = "application/x-pdf";
    }

    public class BillItem
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("bill")]
        public Uri Bill { get; set; }
        [JsonProperty("category")]
        public Uri Category { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("total_value")]
        public decimal TotalValue { get; set; }
        [JsonProperty("sales_tax_rate")]
        public decimal SalesTaxRate { get; set; }
        [JsonProperty("second_sales_tax_rate")]
        public decimal SecondSalesTaxRate { get; set; }
        [JsonProperty("sales_tax_status")]
        public string SalesTaxStatus { get; set; }
        [JsonProperty("second_sales_tax_status")]
        public string SecondSalesTaxStatus { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty("stock_item")]
        public Uri StockItem { get; set; }
        [JsonProperty("depreciation_schedule")]
        public string DepreciationSchedule { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
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




