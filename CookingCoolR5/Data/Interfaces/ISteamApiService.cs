using SteamApi;
using System.Threading.Tasks;

namespace CookingCoolR5.Data.Interfaces
{
    public interface ISteamApiService
    {
        Task<SteamGameInfoVm> GetGameInfoByName(string name);
    }
}
