using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Multishop.UI.Services.Abstract;
using System.Net;
using System.Net.Http.Headers;

namespace Multishop.UI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IAppUserService appUserService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ResourceOwnerPasswordTokenHandler(IAppUserService appUserService, IHttpContextAccessor httpContextAccessor)
        {
            this.appUserService = appUserService;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext is null) return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest }; 

            var accessToken = await httpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var httpResponseMessage = await base.SendAsync(request, cancellationToken);

            if (httpResponseMessage.StatusCode is not HttpStatusCode.Unauthorized) return httpResponseMessage;

            bool response = await appUserService.SignInWithRefreshTokenAsync();
            if (!response) return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}