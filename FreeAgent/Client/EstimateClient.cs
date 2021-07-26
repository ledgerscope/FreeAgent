using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class EstimateClient : ResourceClient<EstimateWrapper, EstimatesWrapper, Estimate>
    {
        public EstimateClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "estimates";

        public override void CustomizeAllRequest(RestRequest request)
        {
            request.AddParameter("nested_estimate_items", "true", ParameterType.GetOrPost);
        }

        public override EstimateWrapper WrapperFromSingle(Estimate single)
        {
            return new EstimateWrapper { estimate = single };
        }

        public override List<Estimate> ListFromWrapper(EstimatesWrapper wrapper)
        {
            return wrapper.estimates;
        }

        public override Estimate SingleFromWrapper(EstimateWrapper wrapper)
        {
            return wrapper.estimate;
        }

        public List<Estimate> AllForContact(string contact)
        {
            return All((request) => request.AddParameter("contact", contact, ParameterType.GetOrPost));
        }

        public List<Estimate> AllForProject(string project)
        {
            return All((request) => request.AddParameter("project", project, ParameterType.GetOrPost));
        }

        public List<Estimate> AllForInvoice(string invoice)
        {
            return All((request) => request.AddParameter("invoice", invoice, ParameterType.GetOrPost));
        }

        public List<Estimate> AllWithFilter(string filter)
        {
            return All((request) => request.AddParameter("view", filter, ParameterType.GetOrPost));
        }

        public bool SendEmail(string estimateId, EstimateEmail email)
        {
            var request = CreateBasicRequest(Method.POST, "/{id}/send_email");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", estimateId);
            request.AddJsonBody(new EstimateEmailWrapper() { estimate = email });

            var response = Client.Execute(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public bool MarkAsSent(string estimateId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_sent");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", estimateId);

            var response = Client.Execute(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public bool MarkAsDraft(string estimateId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_draft");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", estimateId);

            var response = Client.Execute(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public bool DeleteLine(string lineId)
        {
            var request = CreateBasicRequest(Method.DELETE, "/{id}", resourceOverride: "estimate_items");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", lineId);

            var response = Client.Execute(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }
    }
}
