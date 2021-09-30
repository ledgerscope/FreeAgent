using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

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

        public enum Order { Earliest, Latest };

        public List<CreditNote> GetCreditNoteSorted(Order order)
        {
            var request = CreateBasicRequest(Method.GET);

            request.AddParameter("page", 1, ParameterType.GetOrPost);
            request.AddParameter("per_page", 1, ParameterType.GetOrPost);

            // To sort in descending order, the sort parameter can be prefixed with a hyphen
            var sort = order == Order.Earliest ? "dated_on" : "-dated_on";

            request.AddParameter("sort", sort, ParameterType.GetOrPost);

            var response = Client.Execute<CreditNotesWrapper>(request);

            return response.credit_notes;
        }

        public List<CreditNote> AllForProject(string projectId)
        {
            return All((request) => request.AddParameter("project", projectId, ParameterType.GetOrPost));
        }

        public List<CreditNote> AllForContact(string contactId)
        {
            return All((request) => request.AddParameter("contact", contactId, ParameterType.GetOrPost));
        }

        public List<CreditNote> AllWithFilter(string filter)
        {
            return All((request) => request.AddParameter("view", filter, ParameterType.GetOrPost));
        }

        public bool SendEmail(string creditNoteId, CreditNoteEmail email)
        {
            var request = CreateBasicRequest(Method.POST, "/{id}/send_email");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", creditNoteId);
            request.AddJsonBody(new CreditNoteEmailWrapper() { credit_note = email });

            var response = Client.Execute(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public bool MarkAsSent(string creditNoteId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_sent");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", creditNoteId);

            var response = Client.Execute(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public bool MarkAsDraft(string creditNoteId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_draft");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", creditNoteId);

            var response = Client.Execute(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public bool DeleteLine(string lineId)
        {
            var request = CreateBasicRequest(Method.DELETE, "/{id}", resourceOverride: "credit_note_items");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", lineId);

            var response = Client.Execute(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }
    }
}

