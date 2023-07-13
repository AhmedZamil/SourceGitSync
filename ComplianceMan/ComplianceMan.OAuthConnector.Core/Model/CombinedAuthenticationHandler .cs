using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Milbix.OAuthConnector.Core.Model
{
    public class CombinedAuthenticationHandler : RemoteAuthenticationHandler<RemoteAuthenticationOptions>
    {
        public CombinedAuthenticationHandler(
            IOptionsMonitor<RemoteAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
        {
            var azureADResult = await Context.AuthenticateAsync("AzureAD");
            if (azureADResult.Succeeded)
            {
                // Add the provider claim
                var identity = (ClaimsIdentity)azureADResult.Principal.Identity;
                identity.AddClaim(new Claim("provider", "AzureAD"));

                return HandleRequestResult.Success(azureADResult.Ticket);
            }

            var googleResult = await Context.AuthenticateAsync("Google");
            if (googleResult.Succeeded)
            {
                // Add the provider claim
                var identity = (ClaimsIdentity)googleResult.Principal.Identity;
                identity.AddClaim(new Claim("provider", "Google"));

                return HandleRequestResult.Success(googleResult.Ticket);
            }
            var githubResult = await Context.AuthenticateAsync("GitHub");
            if (githubResult.Succeeded)
            {
                // Add the provider claim
                var identity = (ClaimsIdentity)githubResult.Principal.Identity;
                identity.AddClaim(new Claim("provider", "GitHub"));

                return HandleRequestResult.Success(githubResult.Ticket);
            }

            var MilbixResult = await Context.AuthenticateAsync("Milbix");
            if (MilbixResult.Succeeded)
            {
                // Add the provider claim
                var identity = (ClaimsIdentity)MilbixResult.Principal.Identity;
                identity.AddClaim(new Claim("provider", "Milbix"));

                return HandleRequestResult.Success(azureADResult.Ticket);
            }

            return HandleRequestResult.Fail("Authentication failed");
        }
    }
}
