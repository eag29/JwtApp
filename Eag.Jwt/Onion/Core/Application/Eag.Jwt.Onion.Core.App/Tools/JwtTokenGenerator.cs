using Eag.Jwt.Onion.Core.App.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Eag.Jwt.Onion.Core.App.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(dto.Role))
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(dto.Username))
                claims.Add(new Claim("Username", dto.Username));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signInCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
