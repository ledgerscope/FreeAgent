using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class CreditNoteReconciliationClient : ResourceClient<CreditNoteReconciliationWrapper, CreditNoteReconciliationsWrapper, CreditNoteReconciliation>
    {
        public CreditNoteReconciliationClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "credit_note_reconciliations";

        public override CreditNoteReconciliationWrapper WrapperFromSingle(CreditNoteReconciliation single)
        {
            return new CreditNoteReconciliationWrapper { creditNoteReconciliation = single };
        }

        public override List<CreditNoteReconciliation> ListFromWrapper(CreditNoteReconciliationsWrapper wrapper)
        {
            return wrapper.creditNoteReconciliations;
        }

        public override CreditNoteReconciliation SingleFromWrapper(CreditNoteReconciliationWrapper wrapper)
        {
            return wrapper.creditNoteReconciliation;
        }
    }
}

