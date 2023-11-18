using CookingCoolR5.Data.Interfaces;
using CookingCoolR5.Helpers.SteamApi;
using SteamApi;
using System.Threading.Tasks;

namespace CookingCoolR5.Services
{
    public class SteamApiService : ISteamApiService
    {
        private readonly SteamHelper SteamHelper = new SteamHelper();
        public async Task<SteamGameInfoVm> GetGameInfoByName(string name)
        {
            return await SteamHelper.GetGameByNameAsync(name);
        }
    }
}
