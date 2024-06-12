namespace Multishop.Basket.Services.LoginServices
{
    public class LoginService :ILoginService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}