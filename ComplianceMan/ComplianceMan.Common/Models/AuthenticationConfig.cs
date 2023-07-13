using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Common.Models
{
    public class AuthenticationConfig
    {
        public string ClientId { get; set; }
        public string TenantId { get; set; }
        public string RedirectUri { get; set; }
    }
}
