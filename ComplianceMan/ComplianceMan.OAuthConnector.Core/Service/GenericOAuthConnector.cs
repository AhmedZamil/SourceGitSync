using Microsoft.Identity.Client;
using Milbix.OAuthConnector.Core.Interface;
using Milbix.OAuthConnector.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Milbix.OAuthConnector.Core.Service
{
    public class GenericOAuthConnector<T> : IGenericOAuthConnector<T> where T : ProviderOptions
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _redirectUri;
        private readonly string _authority;
        private readonly string _scopes;

        public GenericOAuthConnector(string clientId, string clientSecret, string redirectUri, string authority, string scopes)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
            _authority = authority;
            _scopes = scopes;
        }

        public string GetAuthorizationUrl(string provider)
        {
            string authorizationUrl;

            if (provider == "AzureAD")
            {
                var authorizeEndpoint = $"{_authority}/oauth2/v2.0/authorize";
                var queryParams = new Dictionary<string, string> {
                                { "client_id", _clientId },
                                { "response_type", "code" },
                                { "redirect_url", "https:localhost:5000" + _redirectUri },
                                { "scope", _scopes },
                                { "state", Guid.NewGuid().ToString() }
                            };

                var queryString = string.Join("&", queryParams.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));
                authorizationUrl = $"{authorizeEndpoint}?{queryString}";
            }
            else if (provider == "Google")
            {
                // Construct the Google authorization URL
                authorizationUrl = "https://accounts.google.com/o/oauth2/v2/auth" +
                    "?client_id=" + Uri.EscapeDataString(_clientId) +
                    "&redirect_uri=" + "https://localhost:5000" + Uri.EscapeDataString(_redirectUri) +
                    "&response_type=code" +
                    "&scope=" + Uri.EscapeDataString(_scopes) +
                    "&state=" + Guid.NewGuid().ToString();
            }
            else if (provider == "GitHub")
            {
                // Construct the GitHub authorization URL
                authorizationUrl = "https://github.com/login/oauth/authorize" +
                    "?client_id=" + Uri.EscapeDataString(_clientId) +
                    "&redirect_uri=" + "https://localhost:5000" + Uri.EscapeDataString(_redirectUri) +
                    "&scope=" + Uri.EscapeDataString(_scopes) +
                    "&state=" + Guid.NewGuid().ToString();
            }
            else
            {
                throw new ArgumentException("Invalid provider");
            }

            return authorizationUrl;
        }

        public async Task<TokenResponse> ExchangeCodeForTokenAsync(string provider, string code)
        {
            TokenResponse tokenResponse;

            if (provider == "AzureAD")
            {
                var app = ConfidentialClientApplicationBuilder.Create(_clientId)
                    .WithClientSecret(_clientSecret)
                    .WithAuthority(_authority)
                    .WithRedirectUri(_redirectUri)
                    .Build();

                var result = await app.AcquireTokenByAuthorizationCode(_scopes.Split(' '), code).ExecuteAsync();

                tokenResponse = new TokenResponse
                {
                    AccessToken = result.AccessToken,
                    ExpiresOn = result.ExpiresOn,
                    // Map other properties as needed
                };
            }
            else if (provider == "Google")
            {
                var httpClient = new HttpClient();
                var tokenEndpoint = "https://oauth2.googleapis.com/token";

                var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "code", code },
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "redirect_uri", _redirectUri },
                { "grant_type", "authorization_code" }
            });

                var response = await httpClient.PostAsync(tokenEndpoint, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
            }
            else if (provider == "GitHub")
            {
                var httpClient = new HttpClient();
                var tokenEndpoint = "https://github.com/login/oauth/access_token";

                var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "code", code },
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "redirect_uri", _redirectUri }
            });

                var response = await httpClient.PostAsync(tokenEndpoint, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var parsedResponse = HttpUtility.ParseQueryString(responseContent);
                var accessToken = parsedResponse.Get("access_token");
                var tokenType = parsedResponse.Get("token_type");

                tokenResponse = new TokenResponse
                {
                    AccessToken = accessToken,
                    TokenType = tokenType
                };
            }
            else
            {
                throw new ArgumentException("Invalid provider");
            }

            return tokenResponse;
        }

        public async Task<UserInfoResponse> GetUserInfoAsync(string provider, string accessToken)
        {
            UserInfoResponse userInfoResponse;

            if (provider == "AzureAD")
            {
                var app = ConfidentialClientApplicationBuilder.Create(_clientId)
                    .WithClientSecret(_clientSecret)
                    .WithAuthority(_authority)
                    .WithRedirectUri(_redirectUri)
                    .Build();

                var currentUser = await app.GetAccountsAsync();
                var result = await app.AcquireTokenSilent(_scopes.Split(' '), currentUser.FirstOrDefault())
                    .ExecuteAsync();

                userInfoResponse = new UserInfoResponse
                {
                    Name = result.Account.Username,
                    Email = result.Account.Username
                };
            }
            else if (provider == "Google")
            {
                var httpClient = new HttpClient();
                var userInfoEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(userInfoEndpoint);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                userInfoResponse = JsonConvert.DeserializeObject<UserInfoResponse>(responseContent);
            }
            else if (provider == "GitHub")
            {
                var httpClient = new HttpClient();
                var userInfoEndpoint = "https://api.github.com/user";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", "OAuthConnector");

                var response = await httpClient.GetAsync(userInfoEndpoint);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                userInfoResponse = JsonConvert.DeserializeObject<UserInfoResponse>(responseContent);
            }
            else
            {
                throw new ArgumentException("Invalid provider");
            }

            return userInfoResponse;
        }

        public async Task<HttpResponseMessage> CallApiAsync(string apiUrl, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            return response;
        }
    }

}
