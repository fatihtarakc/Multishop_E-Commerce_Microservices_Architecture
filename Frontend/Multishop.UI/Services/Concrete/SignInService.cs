using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Multishop.UI.Models.ViewModels.JwtVMs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Multishop.UI.Services.Abstract;

namespace Multishop.UI.Services.Concrete
{
    public class SignInService : ISignInService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public SignInService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId() => httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        public async Task<bool> SignInAsync(HttpContext httpContext, HttpResponseMessage responseMessage, bool rememberMe)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var jwtVM = System.Text.Json.JsonSerializer.Deserialize<JwtVM>(jsonData, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
            });

            if (jwtVM is null) return false;

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.ReadJwtToken(jwtVM.AccessToken);
            if (token is null) return false;

            var claims = token.Claims.ToList();
            claims.Add(new Claim("MultishopToken", jwtVM.AccessToken));

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties
            {
                ExpiresUtc = jwtVM.ExpirationDate,
                IsPersistent = rememberMe
            };

            await httpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties);

            return true;
        }
    }
}