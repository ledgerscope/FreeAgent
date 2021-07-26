using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class EmailAddressClient : BaseClient
    {
        public EmailAddressClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "email_addresses";

        public List<string> All()
        {
            var request = CreateBasicRequest(Method.GET);
            var response = Client.Execute<EmailAddressesWrapper>(request);

            if (response != null) return response.emailAddresses;

            return null;
        }
    }
}
