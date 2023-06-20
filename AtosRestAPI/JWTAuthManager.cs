using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AtosRestAPI
{
    public interface IJWTAuthManager
    {
        string Authenticate(string username, string password);
    }
    public class JWTAuthManager : IJWTAuthManager
    {
        // Dicionário de dados mocados
        Dictionary<string, string> users = new Dictionary<string, string> {
                {"taylor", "123"}, {"alana","456"}
        };

        private readonly string tokenKey;

        public JWTAuthManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        public string Authenticate(string username, string password)
        {
            // Substituir por consulta no banco
            if(!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
