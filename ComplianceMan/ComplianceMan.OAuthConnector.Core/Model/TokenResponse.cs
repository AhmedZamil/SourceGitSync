using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Milbix.OAuthConnector.Core.Model
{
    public class TokenResponse
    {
        // Not sure yet about the properties about store the token response
        // I think I have to customize this class based on the response structure of OAuth provider ( will be looking into that)
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string Error { get; set; }
        public bool IsError { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }


        // @scott say for I will be adding Other properties such as RefreshToken, ExpiresIn, TokenType, etc.
    }

    //public class TokenResponse
    //{
    //    public string AccessToken { get; set; }
    //    public DateTimeOffset ExpiresOn { get; set; }
    //    // Add other properties as needed
    //}

}
