namespace Multishop.UI.Services.Abstract
{
    public interface ISignInService
    {
        Task<bool> SignInAsync(HttpContext httpContext, HttpResponseMessage responseMessage, bool rememberMe);
    }
}