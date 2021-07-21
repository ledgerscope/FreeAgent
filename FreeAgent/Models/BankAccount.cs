using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class BankAccount : UpdatableModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("is_personal")]
        public bool IsPersonal { get; set; }
        [JsonProperty("is_primary")]
        public bool IsPrimary { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("bank_name")]
        public string BankName { get; set; }
        [JsonProperty("opening_balance")]
        public decimal OpeningBalance { get; set; }
        [JsonProperty("bank_code")]
        public string BankCode { get; set; }
        [JsonProperty("current_balance")]
        public decimal CurrentBalance { get; set; }
        [JsonProperty("latest_activity_date")]
        public DateTime LatestActivityDate { get; set; }

        // Additional StandardBankAccount properties (AccountNumber applicable also for CreditCardAccount type)
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        [JsonProperty("sort_code")]
        public string SortCode { get; set; }
        [JsonProperty("secondary_sort_code")]
        public string SecondarySortCode { get; set; }
        [JsonProperty("iban")]
        public string Iban { get; set; }
        [JsonProperty("bic")]
        public string Bic { get; set; }

        // Additional PaypalAccount properties
        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public class BankAccountWrapper
    {
        public BankAccountWrapper()
        {
            bank_account = null;
        }

        public BankAccount bank_account { get; set; }
    }

    public class BankAccountsWrapper
    {
        public BankAccountsWrapper()
        {
            bank_accounts = new List<BankAccount>();
        }

        public List<BankAccount> bank_accounts { get; set; }
    }

    public static class BankAccountType
    {
        public static string StandardBankAccount = "StandardBankAccount";
        public static string PaypalAccount = "PaypalAccount";
        public static string CreditCardAccount = "CreditCardAccount";
    }
}



