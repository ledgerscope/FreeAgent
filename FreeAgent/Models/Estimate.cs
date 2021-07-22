using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Estimate : UpdatableModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("estimate_type")]
        public string EstimateType { get; set; }
        [JsonProperty("contact")]
        public Uri Contact { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("discount_percent")]
        public decimal DiscountPercent { get; set; }
        [JsonProperty("client_contact_name")]
        public string ClientContactName { get; set; }
        [JsonProperty("ec_status")]
        public string EcStatus { get; set; }
        [JsonProperty("place_of_supply")]
        public string PlaceOfSupply { get; set; }
        [JsonProperty("net_value")]
        public decimal NetValue { get; set; }
        [JsonProperty("total_value")]
        public decimal TotalValue { get; set; }
        [JsonProperty("include_sales_tax_on_total_value")]
        public bool IncludeSalesTaxOnTotalValue { get; set; }
        [JsonProperty("involves_sales_tax")]
        public bool InvolvesSalesTax { get; set; }
        [JsonProperty("estimate_items")]
        public List<EstimateItem> EstimateItems { get; set; }
    }

    public class EstimateItem : UpdatableModel
    {
        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("item_type")]
        public string ItemType { get; set; }
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("sales_tax_rate")]
        public decimal SalesTaxRate { get; set; }
        [JsonProperty("second_sales_tax_rate")]
        public decimal SecondSalesTaxRate { get; set; }
        [JsonProperty("sales_tax_value")]
        public decimal SalesTaxValue { get; set; }
        [JsonProperty("second_sales_tax_value")]
        public decimal SecondSalesTaxValue { get; set; }
        [JsonProperty("sales_tax_status")]
        public string SalesTaxStatus { get; set; }
        [JsonProperty("second_sales_tax_status")]
        public string SecondSalesTaxStatus { get; set; }
        [JsonProperty("category")]
        public Uri Category { get; set; }
    }

    public static class EstimateStatus
    {
        public static string Draft = "Draft";
        public static string Sent = "Sent";
        public static string Open = "Open";
        public static string Approved = "Approved";
        public static string Rejected = "Rejected";
        public static string Invoiced = "Invoiced";
    }

    public static class EstimateType
    {
        public static string Estimate = "Estimate";
        public static string Quote = "Quote";
        public static string Proposal = "Proposal";
    }

    public static class EstimateECStatus
    {
        public static string UKNonEc = "UK/Non-EC";
        public static string ECGoods = "EC Goods";
        public static string ECServices = "EC Services";
        public static string ECVatMoss = "EC VAT MOSS";
    }

    public static class EstimateItemType
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
        public static string Comments = "Comments";
        public static string Bills = "Bills";
        public static string Discount = "Discount";
        public static string Credit = "Credit";
        public static string NoUnit = "-no unit-";
    }

    public static class EstimateViewFilter
    {
        public static string Recent = "recent";
        public static string Draft = "draft";
        public static string NonDraft = "non_draft";
        public static string Sent = "sent";
        public static string Approved = "approved";
        public static string Rejected = "rejected";
        public static string Invoiced = "invoiced";
    }

    public class EstimateWrapper
    {
        public EstimateWrapper()
        {
            estimate = null;
        }

        public Estimate estimate { get; set; }
    }

    public class EstimatesWrapper
    {
        public EstimatesWrapper()
        {
            estimates = new List<Estimate>();
        }

        public List<Estimate> estimates { get; set; }
    }

    public class EstimateEmailWrapper
    {
        public EstimateEmailWrapper()
        {
            estimate = new EstimateEmail();
        }

        public EstimateEmail estimate { get; set; }
    }

    public class EstimateEmail
    {
        public EstimateEmail()
        {
            email = new EstimateEmailDetail();
        }

        public EstimateEmailDetail email { get; set; }
    }

    public class EstimateEmailDetail
    {
        public string to { get; set; }

        public string @from { get; set; }

        public string subject { get; set; }

        public string body { get; set; }
    }
}




