using FreeAgent.Helpers;
using RestSharp;

namespace FreeAgent
{
    public abstract class BaseClient
    {
        public BaseClient(FreeAgentClient client)
        {
            Client = client;
        }

        public FreeAgentClient Client;
        public string Version => FreeAgentClient.Version;
        public RequestHelper Helper => Client.Helper;
        public virtual string ResourceName => "unknown";

        protected void SetAuthentication(RestRequest request)
        {
            request.AddHeader("Authorization", "Bearer " + Client.CurrentAccessToken.access_token);
        }

        public virtual void CustomizeAllRequest(RestRequest request)
        {
            //
        }

        public virtual RestRequest CreateBasicRequest(Method method, string appendToUrl = "", string resourceOverride = null)
        {
            var request = new RestRequest(method)
            {
                Resource = "v{version}/{resource}" + appendToUrl
            };
            request.AddParameter("version", Version, ParameterType.UrlSegment);

            if (string.IsNullOrEmpty(resourceOverride))
            {
                request.AddParameter("resource", ResourceName, ParameterType.UrlSegment);
            }
            else
            {
                request.AddParameter("resource", resourceOverride, ParameterType.UrlSegment);
            }

            SetAuthentication(request);

            return request;
        }
    }
}

