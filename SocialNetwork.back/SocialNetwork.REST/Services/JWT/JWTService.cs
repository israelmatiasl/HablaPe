using Microsoft.IdentityModel.Tokens;
using SocialNetwork.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Rest.Helpers;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace SocialNetwork.Rest.Services.JWT
{
    public class JWTService
    {
        public String JwtBuilder(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.key_jwt));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.id),
                new Claim("email_address", user.email),
                new Claim("status", user.status),
                new Claim("role", user.role),
                new Claim("creation", DateTime.Now.ToLongDateString())
            };

            var jwtToken = new JwtSecurityToken(
                issuer: Constants.issuer_jwt,
                audience: Constants.audience_jwt,
                signingCredentials: credentials,
                expires: DateTime.Now.AddHours(4),
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public String JwtActivate(String userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.key_jwt_activation));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim("userId", userId),
                //new Claim("mode", "activation")
                new Claim("mode", "activation"),
                new Claim("userId", userId),
                new Claim("creation", DateTime.Now.ToLongDateString())
            };

            var jwtToken = new JwtSecurityToken(
                issuer: Constants.issuer_jwt,
                audience: Constants.audience_jwt,
                signingCredentials: credentials,
                expires: DateTime.Now.AddHours(4),
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
