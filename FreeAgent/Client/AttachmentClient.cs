using FreeAgent.Models;
using RestSharp;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class AttachmentClient : BaseClient
    {
        public AttachmentClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "attachments";

        public async Task<AttachmentWrapper> GetAsync(string id)
        {
            var request = CreateBasicRequest(Method.GET, "/{id}");
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return await Client.ExecuteAsync<AttachmentWrapper>(request);
        }
    }
}
