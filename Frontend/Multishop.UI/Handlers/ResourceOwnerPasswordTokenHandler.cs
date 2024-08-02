using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Multishop.UI.Services.Abstract;
using System.Net;
using System.Net.Http.Headers;

namespace Multishop.UI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAppUserService userService;
        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor, IAppUserService userService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode is not HttpStatusCode.Unauthorized) return response;

            var refreshToken = await userService.RefreshTokenGetFirstOrDefaultAsync();
            if (refreshToken is null) return new HttpResponseMessage(HttpStatusCode.NotFound);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", refreshToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}