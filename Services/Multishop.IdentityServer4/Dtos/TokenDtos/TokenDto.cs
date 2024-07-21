using System;

namespace Multishop.IdentityServer4.Dtos.TokenDtos
{
    public class TokenDto
    {
        public TokenDto(string accessToken, DateTime expirationDate)
        {
            AccessToken = accessToken;
            ExpirationDate = expirationDate;
        }
        
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}