using Newtonsoft.Json;
using System;

namespace FreeAgent.Models
{
    public abstract class SalesTransactionModel : ControlTransactionModel
    {
        [JsonProperty("payment_terms_in_days")]
        public int PaymentTermsInDays { get; set; }
        [JsonProperty("cis_rate")]
        public string CisRate { get; set; }
        [JsonProperty("cis_deduction_rate")]
        public decimal CisDeductionRate { get; set; }
        [JsonProperty("cis_deduction")]
        public decimal CisDeduction { get; set; }
        [JsonProperty("cis_deduction_suffered")]
        public decimal CisDeductionSuffered { get; set; }
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
        [JsonProperty("place_of_supply")]
        public string PlaceOfSupply { get; set; }
        [JsonProperty("net_value")]
        public decimal NetValue { get; set; }
        [JsonProperty("involves_sales_tax")]
        public bool InvolvesSalesTax { get; set; }
        [JsonProperty("due_value")]
        public decimal DueValue { get; set; }
        [JsonProperty("is_interim_uk_vat")]
        public bool IsInterimUKVat { get; set; }
        [JsonProperty("written_off_date")]
        public DateTime WrittenOffDate { get; set; }
    }
}

