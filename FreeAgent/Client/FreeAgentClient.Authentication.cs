using FreeAgent.Models;
using System;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public partial class FreeAgentClient
    {
        public async Task<AccessToken> GetAccessTokenAsync(string code, string redirectUri = "")
        {
            _restClient.BaseUrl = BaseUrl;

            var request = _requestHelper.CreateAccessTokenRequest(code, redirectUri);

            var response = await ExecuteAsync<AccessToken>(request);

            if (response != null && !string.IsNullOrEmpty(response.access_token))
            {
                CurrentAccessToken = response;
            }

            return CurrentAccessToken;
        }

        public async Task<AccessToken> RefreshAccessTokenAsync()
        {
            _restClient.BaseUrl = BaseUrl;

            if (CurrentAccessToken.AccessTokenExpiration > DateTime.UtcNow.AddMinutes(5))
                return CurrentAccessToken;

            var timestamp = DateTime.UtcNow;

            var request = _requestHelper.CreateRefreshTokenRequest();
            var response = await ExecuteAsync<AccessToken>(request);

            if (response != null && !string.IsNullOrEmpty(response.access_token))
            {
                var token = CurrentAccessToken;

                token.refresh_token = response.refresh_token;
                token.access_token = response.access_token;
                token.expires_in = response.expires_in;
                token.refresh_token_expires_in = response.refresh_token_expires_in;
                token.Timestamp = timestamp;

                CurrentAccessToken = token;
                return CurrentAccessToken;
            }

            return null;
        }
    }
}
