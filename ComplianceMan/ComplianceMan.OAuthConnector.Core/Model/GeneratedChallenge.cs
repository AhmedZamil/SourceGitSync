using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milbix.OAuthConnector.Core.Model
{
    public class GeneratedChallenge
    {
        public AuthenticationProperties AuthenticationProperties { get; set; }
        public string Provider { get; set; }
    }
}
