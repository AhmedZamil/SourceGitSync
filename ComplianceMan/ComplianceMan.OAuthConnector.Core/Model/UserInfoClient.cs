using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Milbix.OAuthConnector.Core.Model
{
    public class UserInfoClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _userInfoEndpoint;

        public UserInfoClient(string userInfoEndpoint)
        {
            _httpClient = new HttpClient();
            _userInfoEndpoint = userInfoEndpoint;
        }

        public async Task<UserInfoResponse> GetUserInfoAsync(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync(_userInfoEndpoint);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get user info: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var userInfo = new UserInfoResponse(content);

            return userInfo;
        }
    }
}
