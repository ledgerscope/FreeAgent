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
            credit_note_reconciliation = null;
        }

        public CreditNoteReconciliation credit_note_reconciliation { get; set; }
    }

    public class CreditNoteReconciliationsWrapper
    {
        public CreditNoteReconciliationsWrapper()
        {
            credit_note_reconciliations = new List<CreditNoteReconciliation>();
        }

        public List<CreditNoteReconciliation> credit_note_reconciliations { get; set; }
    }
}




