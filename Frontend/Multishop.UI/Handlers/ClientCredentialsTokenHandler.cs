using Multishop.UI.Services.IdentityServices.Abstract;
using System.Net.Http.Headers;

namespace Multishop.UI.Handlers
{
    public class ClientCredentialsTokenHandler : DelegatingHandler
    {
        private readonly IIdentityService identityService;
        public ClientCredentialsTokenHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await identityService.ClientCredentialTokenGetFirstOrDefaultAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}