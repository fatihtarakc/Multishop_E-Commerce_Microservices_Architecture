﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Multishop.IdentityServer4.Dtos.AppUserDtos;
using Multishop.IdentityServer4.Dtos.TokenDtos;
using Multishop.IdentityServer4.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Multishop.IdentityServer4.Services.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public TokenDto Generator(AppUserDto appUserDto)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(appUserDto.Role)) claims.Add(new Claim(ClaimTypes.Role, appUserDto.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUserDto.Id));

            if (!string.IsNullOrWhiteSpace(appUserDto.Username)) claims.Add(new Claim("username", appUserDto.Username));

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:IssuerSigningKey"]));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var expirationDate = DateTime.UtcNow.AddMinutes(double.Parse(configuration["Token:Lifetime"]));

            var jwtSecurityToken = new JwtSecurityToken(issuer: configuration["Token:Issuer"], audience: configuration["Token:Audience"], claims: claims, notBefore: DateTime.UtcNow, expires: expirationDate, signingCredentials: signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return new TokenDto(jwtSecurityTokenHandler.WriteToken(jwtSecurityToken), expirationDate);
        }
    }
}