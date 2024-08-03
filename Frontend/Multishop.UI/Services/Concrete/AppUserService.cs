using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Multishop.UI.Models.ViewModels.AppUserVMs;
using Multishop.UI.Models.ViewModels.JwtVMs;
using Multishop.UI.Services.Abstract;
using System.Net;
using System.Security.Claims;

namespace Multishop.UI.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly Options.ClientOptions clientOptions;
        private readonly Options.RouteOptions routeOptions;
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AppUserService(IOptions<Options.ClientOptions> clientOptions, IOptions<Options.RouteOptions> routeOptions, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            this.clientOptions = clientOptions.Value;
            this.routeOptions = routeOptions.Value;
            this.httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SignInWithTokenAsync(AppUserSignInVM appUserSignInVM)
        {
            var discoveryDocumentResponse = await httpClient.GetDiscoveryDocumentAsync
                (new DiscoveryDocumentRequest { Address = routeOptions.IdentityServer, Policy = new DiscoveryPolicy { RequireHttps = true } });
            if (discoveryDocumentResponse.HttpStatusCode is not HttpStatusCode.OK) return false;

            var passwordTokenRequest = new JwtPaswordTokenRequestVM
            {
                ClientId = clientOptions.Manager.Id,
                ClientSecret = clientOptions.Manager.Secret,
                Email = appUserSignInVM.Email,
                Password = appUserSignInVM.Password,
                Address = discoveryDocumentResponse.TokenEndpoint
            };

            var tokenResponse = await httpClient.RequestPasswordTokenAsync(passwordTokenRequest);
            if (tokenResponse.HttpStatusCode is not HttpStatusCode.OK) return false;

            var userInformationRequest = new UserInfoRequest { Token = tokenResponse.AccessToken, Address = discoveryDocumentResponse.UserInfoEndpoint };

            var userInformationResponse = await httpClient.GetUserInfoAsync(userInformationRequest);
            if (userInformationResponse.HttpStatusCode is not HttpStatusCode.OK) return false;

            var claimsIdentity = new ClaimsIdentity(userInformationResponse.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = tokenResponse.AccessToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = tokenResponse.RefreshToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.ExpiresIn, Value = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn).ToString() }
            });
            authenticationProperties.IsPersistent = appUserSignInVM.RememberMe;

            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext is null) return false;

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            return true;
        }

        public async Task<bool> SignInWithRefreshTokenAsync()
        {
            var discoveryDocumentResponse = await httpClient.GetDiscoveryDocumentAsync
                (new DiscoveryDocumentRequest { Address = routeOptions.IdentityServer, Policy = new DiscoveryPolicy { RequireHttps = true } });
            if (discoveryDocumentResponse.HttpStatusCode is not HttpStatusCode.OK) return false;

            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext is null) return false;

            var refreshToken = await httpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            var refreshTokenRequest = new RefreshTokenRequest
            {
                RefreshToken = refreshToken,
                ClientId = clientOptions.Manager.Id,
                ClientSecret = clientOptions.Manager.Secret,
                Address = discoveryDocumentResponse.TokenEndpoint
            };

            var tokenResponse = await httpClient.RequestRefreshTokenAsync(refreshTokenRequest);
            if (tokenResponse.HttpStatusCode is not HttpStatusCode.OK) return false;

            var authenticationTokens = new List<AuthenticationToken>()
            {
                new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = tokenResponse.AccessToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = tokenResponse.RefreshToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.ExpiresIn, Value = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn).ToString() }
            };

            var authenticationResult = await httpContext.AuthenticateAsync();
            if (!authenticationResult.Succeeded) return false;

            var authenticationProperties = authenticationResult.Properties;
            authenticationProperties.StoreTokens(authenticationTokens);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, authenticationResult.Principal, authenticationProperties);
            
            return true;
        }

        public async Task<AppUserVM> GetFirstOrDefaultAsync()
        {
            return await httpClient.GetFromJsonAsync<AppUserVM>("/api/user/getfirstordefault");
        }

        public async Task<string> TokenGetFirstOrDefaultAsync()
        {
            return null;
        }
    }
}