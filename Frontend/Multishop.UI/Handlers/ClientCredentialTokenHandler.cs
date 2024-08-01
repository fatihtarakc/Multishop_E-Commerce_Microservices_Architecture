using Multishop.UI.Services.Abstract;
using System.Net.Http.Headers;

namespace Multishop.UI.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IUserService userService;
        public ClientCredentialTokenHandler(IUserService userService)
        {
            this.userService = userService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await userService.TokenGetFirstOrDefaultAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}