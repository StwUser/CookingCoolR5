namespace CookingCoolR5.Data.Interfaces
{
    public interface ITokenService
    {
        public string GetEncodedJwt(string userName, string userRole);
    }
}
