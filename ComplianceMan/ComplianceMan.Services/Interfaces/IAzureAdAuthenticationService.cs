using ComplianceMan.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Interfaces
{
    public interface IAzureAdAuthenticationService
    {
        Task<User> HandleAzureAdAuthentication(string username, string accessToken);
    }
}
