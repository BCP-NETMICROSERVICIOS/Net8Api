using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Venta.Api.Models;

namespace Venta.Api.Seguridad
{
    public class TokenServices
    {
        public const string SECRET = "TomaPedidos9669ass969dd9ffg6g9hh935434235433";
        private const double EXPIRE_HOURS = 1.0;
        public static string CreateToken(LoginModel usuario)
        {
            var key = Encoding.ASCII.GetBytes(SECRET);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.UserName.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usuario.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
        // new Claim(ClaimTypes.Role, usuario.Roles.ToString())
    }
}
