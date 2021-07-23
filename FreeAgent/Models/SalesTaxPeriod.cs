using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    /// <summary>
    /// Only available to US and Universal companies
    /// </summary>
    public class SalesTaxPeriod : BaseModel
    {
        [JsonProperty("sales_tax_name")]
        public string SalesTaxName { get; set; }
        [JsonProperty("sales_tax_registration_status")]
        public string SalesTaxRegistrationStatus { get; set; }
        [JsonProperty("sales_tax_rate_1")]
        public decimal SalesTaxRate1 { get; set; }
        [JsonProperty("sales_tax_rate_2")]
        public decimal SalesTaxRate2 { get; set; }
        [JsonProperty("sales_tax_rate_3")]
        public decimal SalesTaxRate3 { get; set; }
        [JsonProperty("sales_tax_is_value_added")]
        public bool SalesTaxIsValueAdded { get; set; }
        [JsonProperty("sales_tax_registration_number")]
        public string SalesTaxRegistrationNumber { get; set; }
        [JsonProperty("effective_date")]
        public DateTime EffectiveDate { get; set; }
        [JsonProperty("is_locked")]
        public bool IsLocked { get; set; }
        [JsonProperty("locked_reason")]
        public string LockedReason { get; set; }

        // Additional properties for Universal companies (optional)
        [JsonProperty("second_sales_tax_name")]
        public string SecondSalesTaxName { get; set; }
        [JsonProperty("second_sales_tax_rate_1")]
        public decimal SecondSalesTaxRate1 { get; set; }
        [JsonProperty("second_sales_tax_rate_2")]
        public decimal SecondSalesTaxRate2 { get; set; }
        [JsonProperty("second_sales_tax_rate_3")]
        public decimal SecondSalesTaxRate3 { get; set; }
        [JsonProperty("second_sales_tax_is_compound")]
        public bool SecondSalesTaxIsCompound { get; set; }
    }

    public static class RegistrationStatus
    {
        public static string NotRegistered = "Not Registered";
        public static string Registered = "Registered";
    }

    public class SalesTaxPeriodWrapper
    {
        public SalesTaxPeriodWrapper()
        {
            salesTaxPeriod = null;
        }

        public SalesTaxPeriod salesTaxPeriod { get; set; }
    }

    public class SalesTaxPeriodsWrapper
    {
        public SalesTaxPeriodsWrapper()
        {
            salesTaxPeriods = new List<SalesTaxPeriod>();
        }

        public List<SalesTaxPeriod> salesTaxPeriods { get; set; }
    }
}

