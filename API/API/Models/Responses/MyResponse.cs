using Microsoft.IdentityModel.Tokens;

using API.Models.JWT.Tokens;
using API.Models.JWT.Util;

namespace API.Models.Responses
{
    public class MyResponse
    {
        private readonly JWTFactory jwtFactory;
        public string message = "";
        public Dictionary<string, string> tokens = [];

        public MyResponse(RsaSecurityKey key)
        {
            jwtFactory = new JWTFactory(key);
        }

        protected MyResponse(MyResponse response)
        {
            jwtFactory = response.jwtFactory;
            message = response.message;
            tokens = response.tokens;
        }

        public void SetMessage(string value)
        {
            message = value;
        }

        public void AddToken(JWTType type, JWTData userData)
        {
            tokens.Add(type.Value, jwtFactory.CreateJWT(type, userData));
        }
    }
}
