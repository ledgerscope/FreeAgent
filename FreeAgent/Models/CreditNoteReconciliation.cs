using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class CreditNoteReconciliation : BaseModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("gross_value")]
        public decimal GrossValue { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("exchange_rate")]
        public decimal ExchangeRate { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("invoice")]
        public Uri Invoice { get; set; }
        [JsonProperty("credit_note")]
        public Uri CreditNote { get; set; }
    }

    public class CreditNoteReconciliationWrapper
    {
        public CreditNoteReconciliationWrapper()
        {
            creditNoteReconciliation = null;
        }

        public CreditNoteReconciliation creditNoteReconciliation { get; set; }
    }

    public class CreditNoteReconciliationsWrapper
    {
        public CreditNoteReconciliationsWrapper()
        {
            creditNoteReconciliations = new List<CreditNoteReconciliation>();
        }

        public List<CreditNoteReconciliation> creditNoteReconciliations { get; set; }
    }
}




