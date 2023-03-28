using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CookingCoolR5.Helpers.Token
{
    public class AuthModel
    {
        public string Issuer = "";
        public string Consumer = "";
        public string JwtKey = "justTestKeyForExample";
        public int LifeTime = 0;
        public SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtKey));
    }
}
