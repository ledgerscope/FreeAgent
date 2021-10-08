using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class EmailAddressClient : BaseClient
    {
        public EmailAddressClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "email_addresses";

        public async Task<List<string>> All()
        {
            var request = CreateBasicRequest(Method.GET);
            var response = await Client.Execute<EmailAddressesWrapper>(request);

            if (response != null) return response.email_addresses;

            return null;
        }
    }
}
