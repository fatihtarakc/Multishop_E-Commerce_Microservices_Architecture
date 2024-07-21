namespace Multishop.UI.Services.Abstract
{
    public interface ISignInService
    {
        string GetUserId();
        Task<bool> SignInAsync(HttpContext httpContext, HttpResponseMessage responseMessage, bool rememberMe);
    }
}