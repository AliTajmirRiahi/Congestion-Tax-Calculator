using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Anshan.Framework.Security
{
    public static class JwtTokenGenerator
    {
        public static string Generate(string key, string issuer, IEnumerable<Claim> claims, DateTime expires)
        {
            var encodingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(encodingKey, SecurityAlgorithms.HmacSha256);

            var  token = new JwtSecurityToken(issuer,
                issuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}