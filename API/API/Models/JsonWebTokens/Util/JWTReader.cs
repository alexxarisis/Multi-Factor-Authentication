using System.IdentityModel.Tokens.Jwt;

namespace API.Models.JWT.Util
{
    public class JWTReader
    {
        private readonly JwtSecurityToken token;

        public JWTReader(HttpRequest request)
        {
            // Removing the Bearer prefix
            string jwt = request.Headers.Authorization.ToString().Split(" ")[1];
            token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
        }

        public int GetID()
        {
            var value = token.Claims.First(c => c.Type == "nameid").Value;

            return Convert.ToInt32(value);
        }
    }
}
