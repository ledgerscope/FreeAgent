using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<List<Estimate>> AllForContactAsync(string contact)
        {
            return AllAsync((request) => request.AddParameter("contact", contact, ParameterType.GetOrPost));
        }

        public Task<List<Estimate>> AllForProjectAsync(string project)
        {
            return AllAsync((request) => request.AddParameter("project", project, ParameterType.GetOrPost));
        }

        public Task<List<Estimate>> AllForInvoiceAsync(string invoice)
        {
            return AllAsync((request) => request.AddParameter("invoice", invoice, ParameterType.GetOrPost));
        }

        public Task<List<Estimate>> AllWithFilterAsync(string filter)
        {
            return AllAsync((request) => request.AddParameter("view", filter, ParameterType.GetOrPost));
        }

        public async Task<bool> SendEmailAsync(string estimateId, EstimateEmail email)
        {
            var request = CreateBasicRequest(Method.POST, "/{id}/send_email");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", estimateId);
            request.AddJsonBody(new EstimateEmailWrapper() { estimate = email });

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> MarkAsSentAsync(string estimateId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_sent");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", estimateId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> MarkAsDraftAsync(string estimateId)
        {
            var request = CreateBasicRequest(Method.PUT, "/{id}/transitions/mark_as_draft");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", estimateId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }

        public async Task<bool> DeleteLineAsync(string lineId)
        {
            var request = CreateBasicRequest(Method.DELETE, "/{id}", resourceOverride: "estimate_items");

            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", lineId);

            var response = await Client.ExecuteAsync(request);

            if (response != null)
                return response.StatusCode == System.Net.HttpStatusCode.OK;

            return false;
        }
    }
}

