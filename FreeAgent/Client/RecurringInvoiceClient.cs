using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class RecurringInvoiceClient : ResourceClient<RecurringInvoiceWrapper, RecurringInvoicesWrapper, RecurringInvoice>
    {
        public RecurringInvoiceClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "recurring_invoices";

        public override RecurringInvoiceWrapper WrapperFromSingle(RecurringInvoice single)
        {
            return new RecurringInvoiceWrapper { recurringInvoice = single };
        }

        public override List<RecurringInvoice> ListFromWrapper(RecurringInvoicesWrapper wrapper)
        {
            return wrapper.recurringInvoices;
        }

        public override RecurringInvoice SingleFromWrapper(RecurringInvoiceWrapper wrapper)
        {
            return wrapper.recurringInvoice;
        }
    }
}

