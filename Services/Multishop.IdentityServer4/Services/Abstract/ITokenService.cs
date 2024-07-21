﻿using Multishop.IdentityServer4.Dtos.AppUserDtos;
using Multishop.IdentityServer4.Dtos.TokenDtos;

namespace Multishop.IdentityServer4.Services.Abstract
{
    public interface ITokenService
    {
        TokenDto Generator(AppUserDto appUserDto);
    }
}