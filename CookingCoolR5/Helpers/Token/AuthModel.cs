using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CookingCoolR5.Helpers.Token
{
    public class AuthModel
    {
        public string Issuer { get; set; } = "";
        public string Consumer { get; set; } = "";
        public string JwtKey { get; set; } = "justTestKeyForExample";
        public int LifeTime { get; set; } = 0;
        public SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtKey));
    }
}
