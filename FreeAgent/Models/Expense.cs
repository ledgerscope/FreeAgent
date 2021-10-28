using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Expense : UpdatableModel, IAttachmentModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("user")]
        public Uri User { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("category")]
        public Uri Category { get; set; } // TODO_FA: Uri or string ?
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("gross_value")]
        public decimal GrossValue { get; set; }
        [JsonProperty("native_gross_value")]
        public decimal NativeGrossValue { get; set; }
        [JsonProperty("sales_tax_rate")]
        public decimal SalesTaxRate { get; set; }
        [JsonProperty("sales_tax_value")]
        public decimal SalesTaxValue { get; set; }
        [JsonProperty("native_sales_tax_value")]
        public decimal NativeSalesTaxValue { get; set; }
        [JsonProperty("second_sales_tax_rate")]
        public decimal SecondSalesTaxRate { get; set; }
        [JsonProperty("manual_sales_tax_amount")]
        public decimal ManualSalesTaxAmount { get; set; }
        [JsonProperty("sales_tax_status")]
        public string SalesTaxStatus { get; set; }
        [JsonProperty("second_sales_tax_status")]
        public string SecondSalesTaxStatus { get; set; }
        [JsonProperty("ec_status")]
        public string EcStatus { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("receipt_reference")]
        public string ReceiptReference { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
        [JsonProperty("rebill_type")]
        public string RebillType { get; set; }
        [JsonProperty("rebill_factor")]
        public decimal RebillFactor { get; set; }
        [JsonProperty("rebill_to_project")]
        public Uri RebillToProject { get; set; }
        [JsonProperty("rebilled_on_invoice")]
        public Uri RebilledOnInvoice { get; set; }
        [JsonProperty("recurring")]
        public string Recurring { get; set; }
        [JsonProperty("next_recurs_on")]
        public DateTime NextRecursOn { get; set; }
        [JsonProperty("recurring_end_date")]
        public DateTime RecurringEndDate { get; set; }
        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }

        // Additional properties for Mileage claims
        [JsonProperty("mileage")]
        public decimal Mileage { get; set; }
        [JsonProperty("vehicle_type")]
        public string VehicleType { get; set; }
        [JsonProperty("engine_type")]
        public string EngineType { get; set; }
        [JsonProperty("engine_size")]
        public string EngineSize { get; set; }
        [JsonProperty("reclaim_mileage")]
        public int ReclaimMileage { get; set; }
        [JsonProperty("initial_rate_mileage")]
        public decimal InitialRateMileage { get; set; }
        [JsonProperty("reclaim_mileage_rate")]
        public decimal ReclaimMileageRate { get; set; }
        [JsonProperty("rebill_mileage_rate")]
        public decimal RebillMileageRate { get; set; }
        [JsonProperty("have_vat_receipt")]
        public bool HaveVatReceipt { get; set; }
    }

    public static class ExpenseType
    {
        public static string Payment = "Payment";
        public static string Refund = "Refund";
    }

    public static class ExpenseECStatus
    {
        public static string UKNonEc = "UK/Non-EC";
        public static string ECGoods = "EC Goods";
        public static string ECServices = "EC Services";
    }

    public static class VehicleType
    {
        public static string Car = "Car";
        public static string Motorcycle = "Motorcycle";
        public static string Bicycle = "Bicycle";
    }

    public static class EngineType
    {
        public static string Petrol = "Petrol";
        public static string Diesel = "Diesel";
        public static string LPG = "LPG";
        public static string Electric = "Electric";
    }

    public class ExpenseWrapper
    {
        public ExpenseWrapper()
        {
            expense = null;
        }
        public Expense expense { get; set; }
    }

    public class ExpensesWrapper
    {
        public ExpensesWrapper()
        {
            expenses = new List<Expense>();
        }

        public List<Expense> expenses { get; set; }
    }
}




