using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class JournalSet : UpdatableModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
        [JsonProperty("journal_entries")]
        public List<JournalEntry> JournalEntries { get; set; }

        // Additional properties for Opening Balances
        [JsonProperty("bank_accounts")]
        public List<JournalEntry> BankAccounts { get; set; }
        [JsonProperty("stock_items")]
        public List<JournalEntry> StockItems { get; set; }
    }

    public class JournalEntry : BaseModel
    {
        [JsonProperty("category")]
        public Uri Category { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("debit_value")]
        public decimal DebitValue { get; set; }

        // Additional properties for capital asset categories requiring a sub-code (601-607)
        [JsonProperty("capital_asset_type")]
        public Uri CapitalAssetType { get; set; }

        // Additional properties for user categories
        [JsonProperty("user")]
        public Uri User { get; set; }

        // Additional properties for stock categories
        [JsonProperty("stock_item")]
        public Uri StockItem { get; set; }
        [JsonProperty("stock_altering_quantity")]
        public int StockAlteringQuantity { get; set; }

        // Additional properties for bank account categories
        [JsonProperty("bank_account")]
        public Uri BankAccount { get; set; }
    }

    public class JournalSetWrapper
    {
        public JournalSetWrapper()
        {
            journal_set = null;
        }

        public JournalSet journal_set { get; set; }
    }

    public class JournalSetsWrapper
    {
        public JournalSetsWrapper()
        {
            journal_sets = new List<JournalSet>();
        }

        public List<JournalSet> journal_sets { get; set; }
    }
}




