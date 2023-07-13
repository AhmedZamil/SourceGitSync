using Milbix.OAuthConnector.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milbix.OAuthConnector.Core.Interface
{
    public interface IGenericOAuthConnector<T> where T : ProviderOptions
    {
        string GetAuthorizationUrl(string provider);
        Task<TokenResponse> ExchangeCodeForTokenAsync(string provider, string code);
        Task<UserInfoResponse> GetUserInfoAsync(string provider, string accessToken);
        Task<HttpResponseMessage> CallApiAsync(string apiUrl, string accessToken);
    }
}
