using System.Security.Claims;

namespace API.Models.JWT.Util
{
    public class JWTData
    {
        public List<Claim> Claims { get;}

        public JWTData(int id)
        {
            Claims = [new Claim(ClaimTypes.NameIdentifier, id.ToString())];
        }
    }
}
