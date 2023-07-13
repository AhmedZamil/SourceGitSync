using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milbix.OAuthConnector.Core.Model
{
    public class UserInfoResponse
    {
        // trying to find out and Define properties to store the user information received from the userinfo endpoint

        public string Name { get; set; }
        public string Email { get; set; }

        public UserInfoResponse()
        {
            // Deserialize something like  JSON response from the userinfo endpoint and populate the properties
            // I think  JSON deserialization library like Newtonsoft.Json will better , trying to find out the working structure first
            // @scott I will try to Adapt this code based on the structure of the JSON response returned by OAuth provider ( not sure ) please allow some time.Hope I can
        }
        public UserInfoResponse(string json)
        {
            // Deserialize something like  JSON response from the userinfo endpoint and populate the properties
            // I think  JSON deserialization library like Newtonsoft.Json will better , trying to find out the working structure first
            // @scott I will try to Adapt this code based on the structure of the JSON response returned by OAuth provider ( not sure ) please allow some time.Hope I can
        }
    }
}
