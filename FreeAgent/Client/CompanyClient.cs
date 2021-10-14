using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class CompanyClient : BaseClient
    {
        public CompanyClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "company";

        public async Task<Company> SingleAsync()
        {
            var request = CreateBasicRequest(Method.GET);
            var response = await Client.ExecuteAsync<CompanyWrapper>(request);

            if (response != null) return response.company;

            return null;
        }

        public async Task<List<TaxTimeline>> TaxTimelineAsync()
        {
            var request = CreateBasicRequest(Method.GET, "/tax_timeline");
            var response = await Client.ExecuteAsync<TaxTimelineWrapper>(request);

            if (response != null) return response.timeline_items;

            return null;
        }
    }
}
