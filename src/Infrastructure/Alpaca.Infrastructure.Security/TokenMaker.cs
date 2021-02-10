using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Security
{
    public class TokenMaker
    {
        public const string SECRET_KEY = "doddgu.alpaca@github";

        public static string GetJWT(int userID, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim("sub", userID.ToString()),
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMonths(1)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Iss, "API"),
                new Claim(JwtRegisteredClaimNames.Aud, "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            var jwt = new JwtSecurityToken(new JwtHeader(new SigningCredentials(key, SecurityAlgorithms.HmacSha256)), new JwtPayload(claims));
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}
