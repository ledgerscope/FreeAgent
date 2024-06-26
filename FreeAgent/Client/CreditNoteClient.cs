using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class CreditNoteClient : ResourceClient<CreditNoteWrapper, CreditNotesWrapper, CreditNote>
    {
        public CreditNoteClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "credit_notes";

        public override void CustomizeAllRequest(RestRequest request)
        {
            request.AddParameter("nested_credit_note_items", "true", ParameterType.GetOrPost);
        }

        public override CreditNoteWrapper WrapperFromSingle(CreditNote single)
        {
            return new CreditNoteWrapper { credit_note = single };
        }

        public override List<CreditNote> ListFromWrapper(CreditNotesWrapper wrapper)
        {
            return wrapper.credit_notes;
        }

        public override CreditNote SingleFromWrapper(CreditNoteWrapper wrapper)
        {
            return wrapper.credit_note;
        }

        public IAsyncEnumerable<CreditNote> AllForProjectAsync(string projectId)
        {
            return AllAsync((request) => request.AddParameter("project", projectId, ParameterType.GetOrPost));
        }

        public IAsyncEnumerable<CreditNote> AllForContactAsync(string contactId)
        {
            return AllAsync((request) => request.AddParameter("contact", contactId, ParameterType.GetOrPost));
        }

        public IAsyncEnumerable<CreditNote> AllWithFilterAsync(string filter)
        {
            return AllAsync((request) => request.AddParameter("view", filter, ParameterType.GetOrPost));
        }

        public async Task<bool> SendEmailAsync(string creditNoteId, CreditNoteEmail email)
        {
            var request = CreateBasicRequest(Method.POST, "/{id}/send_email");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", creditNoteId);
            request.AddJsonBody(new CreditNoteEmailWrapper() { credit_note = email });

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> MarkAsSentAsync(string creditNoteId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_sent");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", creditNoteId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> MarkAsDraftAsync(string creditNoteId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_draft");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", creditNoteId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> DeleteLineAsync(string lineId)
        {
            var request = CreateBasicRequest(Method.DELETE, "/{id}", resourceOverride: "credit_note_items");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", lineId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }
    }
}

