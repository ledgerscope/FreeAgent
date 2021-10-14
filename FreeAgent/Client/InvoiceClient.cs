using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class InvoiceClient : ResourceClient<InvoiceWrapper, InvoicesWrapper, Invoice>
    {
        public InvoiceClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "invoices";

        public override void CustomizeAllRequest(RestRequest request)
        {
            request.AddParameter("nested_invoice_items", "true", ParameterType.GetOrPost);
        }

        public override InvoiceWrapper WrapperFromSingle(Invoice single)
        {
            return new InvoiceWrapper { invoice = single };
        }

        public override List<Invoice> ListFromWrapper(InvoicesWrapper wrapper)
        {
            return wrapper.invoices;
        }

        public override Invoice SingleFromWrapper(InvoiceWrapper wrapper)
        {
            return wrapper.invoice;
        }

        public Task<List<Invoice>> AllForProjectAsync(string projectId)
        {
            return AllAsync((request) => request.AddParameter("project", projectId, ParameterType.GetOrPost));
        }

        public Task<List<Invoice>> AllForContactAsync(string contactId)
        {
            return AllAsync((request) => request.AddParameter("contact", contactId, ParameterType.GetOrPost));
        }

        public Task<List<Invoice>> AllWithFilterAsync(string filter)
        {
            return AllAsync((request) => request.AddParameter("view", filter, ParameterType.GetOrPost));
        }

        public async Task<bool> SendEmailAsync(string invoiceId, InvoiceEmail email)
        {
            var request = CreateBasicRequest(Method.POST, "/{id}/send_email");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", invoiceId);
            request.AddJsonBody(new InvoiceEmailWrapper() { invoice = email });

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> MarkAsSentAsync(string invoiceId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_sent");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", invoiceId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> MarkAsDraftAsync(string invoiceId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_draft");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", invoiceId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> DeleteLineAsync(string lineId)
        {
            var request = CreateBasicRequest(Method.DELETE, "/{id}", resourceOverride: "invoice_items");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", lineId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }
    }
}

