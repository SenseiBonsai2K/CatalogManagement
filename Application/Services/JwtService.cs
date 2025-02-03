using Application.Requests;
using CatalogManagement.Models.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JwtService
    {
        private readonly Jwt jwt;

        public JwtService(IOptions<Jwt> jwt)
        {
            this.jwt = jwt.Value;
        }

        public async Task<string> CreateToken(CreateTokenRequest CreateTokenRequest)
        {
            List<Claim> claims = new List<Claim> {
                new Claim("Id", CreateTokenRequest.Id),
                new Claim("Username", CreateTokenRequest.Username),
                new Claim("Email", CreateTokenRequest.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(jwt.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
