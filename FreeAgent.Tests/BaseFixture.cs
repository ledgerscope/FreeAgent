﻿using FreeAgent.Client;
using FreeAgent.Models;
using System;
using System.Net;

namespace FreeAgent.Tests
{
    public class BaseFixture
    {
        protected FreeAgentClient Client;
        protected AccessToken Token;

        public virtual void Configure()
        {

        }

        public virtual void SetupClient()
        {
            Configure();

            FreeAgentClient.UseSandbox = KeyStorage.UseSandbox;
            if (KeyStorage.UseProxy) FreeAgentClient.Proxy = new WebProxy("127.0.0.1", 8888);

            Client = new FreeAgentClient(KeyStorage.AppKey, KeyStorage.AppSecret);

            var sandbox_bttest_token = new AccessToken
            {
                access_token = "",
                refresh_token = KeyStorage.RefreshToken,
                token_type = "bearer"
            };

            Client.CurrentAccessToken = sandbox_bttest_token;


            Token = Client.RefreshAccessToken();

            if (Token == null || string.IsNullOrEmpty(Token.access_token) || string.IsNullOrEmpty(Token.refresh_token))
            {
                throw new Exception("Could not setup the Token");
            }
        }
    }
}
