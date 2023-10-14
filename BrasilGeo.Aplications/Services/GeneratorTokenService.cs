﻿using BrasilGeo.Aplications.Shareds;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BrasilGeo.Aplications.Services
{
    public class GeneratorTokenService : IGeneratorTokenService
    {
        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.SECRET)); 

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = ManageClains(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(5),

            };

            var token = handler.CreateToken(descriptor);

            return handler.WriteToken(token);
        }

        private ClaimsIdentity ManageClains(User user)
        {
            var cli = new ClaimsIdentity();
            cli.AddClaim(new Claim(ClaimTypes.Name, user.Email));

            foreach (var role in user.Roles)
                cli.AddClaim(new Claim(ClaimTypes.Role, role));

            return cli; 
        }
    }
}
