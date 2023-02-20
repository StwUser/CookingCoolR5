using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CookingCoolR5.Data.AunthModel
{
    public class AunthModel
    {
        public const string Issuer = "CookingCoolR5";
        public const string Consumer = "CookingCoolClient";
        public const string JwtKey = "keyTestNumberSuper1234StringForYou";
        public const int LifeTime = 60;
        public static SymmetricSecurityKey GetSymmetricSecurityKey () => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtKey));
    }
}
