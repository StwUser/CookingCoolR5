using CookingCoolR5.Data.Interfaces;
using CookingCoolR5.Helpers.Token;

namespace CookingCoolR5.Services
{
    public class TokenService : ITokenService
    {
        public AuthModel AuthModel { get; set; }
        public TokenService(AuthModel authModel)
        {
            AuthModel = authModel;
        }

        public string GetEncodedJwt(string userName, string userRole)
        {
            var tokenHelper = new TokenHelper(AuthModel, userName, userRole);
            return tokenHelper.GetToken();
        }
    }
}
