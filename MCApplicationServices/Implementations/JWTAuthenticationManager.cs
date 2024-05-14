using MCApplicationServices.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MCApplicationServices.Implementations
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly Dictionary<string, string> _clients = new Dictionary<string, string>()
        {
            { "fmi", "fmi" }
        };
        private readonly string _tokenKey;
        public JWTAuthenticationManager(string tokenKey)
        {
            _tokenKey = tokenKey;
        }
        public string? Authenticate(string clientId, string secret)
        {
            if (!_clients.Any(x => x.Key == clientId && x.Value == secret))
            {
                return null;
            }
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenKey);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, clientId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
