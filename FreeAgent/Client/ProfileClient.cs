using FreeAgent.Models;
using RestSharp;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class ProfileClient : BaseClient
    {
        public ProfileClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "payroll_profiles";

        public async Task<ProfilesWrapper> AllProfilesAsync(int year)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}");
            request.AddParameter("year", year, ParameterType.UrlSegment);

            return await Client.ExecuteAsync<ProfilesWrapper>(request);
        }
    }
}

