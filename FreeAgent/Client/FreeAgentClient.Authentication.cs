using FreeAgent.Models;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public partial class FreeAgentClient
    {
        public async Task<AccessToken> GetAccessToken(string code, string redirectUri = "")
        {
            _restClient.BaseUrl = BaseUrl;

            var request = _requestHelper.CreateAccessTokenRequest(code, redirectUri);

            var response = await Execute<AccessToken>(request);

            if (response != null && !string.IsNullOrEmpty(response.access_token))
            {
                CurrentAccessToken = response;
            }

            return CurrentAccessToken;
        }

        public async Task<AccessToken> RefreshAccessToken()
        {
            _restClient.BaseUrl = BaseUrl;

            var request = _requestHelper.CreateRefreshTokenRequest();
            var response = await Execute<AccessToken>(request);

            if (response != null && !string.IsNullOrEmpty(response.access_token))
            {
                var token = CurrentAccessToken;

                token.refresh_token = response.refresh_token;
                token.access_token = response.access_token;
                token.expires_in = response.expires_in;

                CurrentAccessToken = token;
                return CurrentAccessToken;
            }

            return null;
        }
    }
}
