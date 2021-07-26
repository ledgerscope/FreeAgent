using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Company : BaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("subdomain")]
        public string Subdomain { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("mileage_units")]
        public string MileageUnits { get; set; }
        [JsonProperty("company_start_date")]
        public DateTime CompanyStartDate { get; set; }
        [JsonProperty("trading_start_date")]
        public DateTime TradingStartDate { get; set; }
        [JsonProperty("first_accounting_year_end")]
        public DateTime FirstAccountingYearEnd { get; set; }
        [JsonProperty("freeagent_start_date")]
        public DateTime FreeagentStartDate { get; set; }
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("address3")]
        public string Address3 { get; set; }
        [JsonProperty("town")]
        public string Town { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("company_registration_number")]
        public string CompanyRegistrationNumber { get; set; }
        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }
        [JsonProperty("contact_phone")]
        public string ContactPhone { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("business_type")]
        public string BusinessType { get; set; }
        [JsonProperty("business_category")]
        public string BusinessCategory { get; set; }
        [JsonProperty("short_date_format")]
        public string ShortDateFormat { get; set; }
        [JsonProperty("sales_tax_name")]
        public string SalesTaxName { get; set; }
        [JsonProperty("sales_tax_registration_number")]
        public string SalesTaxRegistrationNumber { get; set; }
        [JsonProperty("sales_tax_registration_status")]
        public string SalesTaxRegistrationStatus { get; set; }
        [JsonProperty("sales_tax_effective_date")]
        public DateTime SalesTaxEffectiveDate { get; set; }
        [JsonProperty("sales_tax_rates")]
        public List<string> SalesTaxRates { get; set; }
        [JsonProperty("sales_tax_is_value_added")]
        public bool SalesTaxIsValueAdded { get; set; }
        [JsonProperty("cis_enabled")]
        public bool CisEnabled { get; set; }
        [JsonProperty("locked_attributes")]
        public List<string> LockedAttributes { get; set; }
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        // Additional properties for VAT-registered UK companies
        [JsonProperty("vat_first_return_period_ends_on")]
        public DateTime VatFirstReturnPeriodEndsOn { get; set; }
        [JsonProperty("initial_vat_basis")]
        public string InitialVatBasis { get; set; }
        [JsonProperty("initially_on_frs")]
        public bool InitiallyOnFrs { get; set; }
        [JsonProperty("initial_vat_frs_type")]
        public string InitialVatFrsType { get; set; }
        [JsonProperty("sales_tax_deregistration_effective_date")]
        public DateTime SalesTaxDeregistrationEffectiveDate { get; set; }

        // Additional properties for US and Universal companies
        [JsonProperty("second_sales_tax_name")]
        public string SecondSalesTaxName { get; set; }
        [JsonProperty("second_sales_tax_rates")]
        public List<string> SecondSalesTaxRates { get; set; }
        [JsonProperty("second_sales_tax_is_compound")]
        public bool SecondSalesTaxIsCompound { get; set; }
    }

    public static class CompanyType
    {
        public static string UkLimitedCompany = "UkLimitedCompany";
        public static string UkSoleTrader = "UkSoleTrader";
        public static string UkPartnership = "UkPartnership";
        public static string UkLimitedLiabilityPartnership = "UkLimitedLiabilityPartnership";
        public static string UsSoleProprietor = "UsSoleProprietor";
        public static string UsPartnership = "UsPartnership";
        public static string UsLimitedLiabilityCompany = "UsLimitedLiabilityCompany";
        public static string UsSCorp = "UsSCorp";
        public static string UsCCorp = "UsCCorp";
        public static string UniversalCompany = "UniversalCompany";
    }

    public class CompanyWrapper
    {
        public CompanyWrapper()
        {
            company = new Company();
        }

        public Company company { get; set; }
    }

    public class TaxTimeline
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("nature")]
        public string Nature { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("amount_due")]
        public decimal AmountDue { get; set; }
        [JsonProperty("is_personal")]
        public bool IsPersonal { get; set; }
    }

    public class TaxTimelineWrapper
    {
        public TaxTimelineWrapper()
        {
            timeline_items = new List<TaxTimeline>();
        }
        public List<TaxTimeline> timeline_items { get; set; }
    }
}
