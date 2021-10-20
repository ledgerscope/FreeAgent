using FreeAgent.Models;
using RestSharp;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class ProfitAndLossClient : BaseClient
    {
        public ProfitAndLossClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "accounting";

        public async Task<ProfitAndLoss> AllAsync()
        {
            var request = CreateBasicRequest(Method.GET, "/profit_and_loss/summary");
            var response = await Client.ExecuteAsync<ProfitAndLossWrapper>(request);

            if (response != null) return response.profit_and_loss_summary;

            return null;
        }
    }
}

