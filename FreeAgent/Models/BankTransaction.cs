using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class BankTransaction : UpdatableModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("bank_account")]
        public Uri BankAccount { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("full_description")]
        public string FullDescription { get; set; }
        [JsonProperty("uploaded_at")]
        public DateTime UploadedAt { get; set; }
        [JsonProperty("unexplained_amount")]
        public decimal UnexplainedAmount { get; set; }
        [JsonProperty("is_manual")]
        public bool IsManual { get; set; }
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        [JsonProperty("matching_transactions_count")]
        public int MatchingTransactionsCount { get; set; }
        [JsonProperty("bank_transaction_explanations")]
        public List<BankTransactionExplanation> BankTransactionExplanations { get; set; }
    }

    public class BankTransactionWrapper
    {
        public BankTransactionWrapper()
        {
            bank_transaction = null;
        }

        public BankTransaction bank_transaction { get; set; }
    }

    public class BankTransactionsWrapper
    {
        public BankTransactionsWrapper()
        {
            bank_transactions = new List<BankTransaction>();
        }

        public List<BankTransaction> bank_transactions { get; set; }
    }
}



