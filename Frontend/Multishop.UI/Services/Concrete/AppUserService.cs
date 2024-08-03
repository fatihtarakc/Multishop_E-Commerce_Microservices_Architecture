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
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AppUserService(IOptions<Options.ClientOptions> clientOptions, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            this.clientOptions = clientOptions.Value;
            this.httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SignInAsync(AppUserSignInVM appUserSignInVM)
        {
            var discoveryDocumentResponse = await httpClient.GetDiscoveryDocumentAsync
                (new DiscoveryDocumentRequest { Address = "https://localhost:7000", Policy = new DiscoveryPolicy { RequireHttps = true } });
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

        public async Task<AppUserVM> GetFirstOrDefaultAsync()
        {
            return await httpClient.GetFromJsonAsync<AppUserVM>("/api/user/getfirstordefault");
        }

        public async Task<string> TokenGetFirstOrDefaultAsync()
        {
            return null;
        }

        public async Task<string> RefreshTokenGetFirstOrDefaultAsync()
        {
            return null;
        }
    }
}