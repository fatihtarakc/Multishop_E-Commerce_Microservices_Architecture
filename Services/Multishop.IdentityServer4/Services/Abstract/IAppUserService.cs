using Multishop.IdentityServer4.Dtos.AppUserDtos;
using Multishop.IdentityServer4.Dtos.TokenDtos;

namespace Multishop.IdentityServer4.Services.Abstract
{
    public interface IAppUserService
    {
        TokenDto TokenGenerator(AppUserDto appUserDto);
    }
}