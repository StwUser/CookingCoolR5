using CookingCoolR5.Data;
using CookingCoolR5.Data.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CookingCoolR5.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly AppDbContext Context;

        public GameController(AppDbContext context)
        {
            Context = context;
        }

        [HttpGet("games")]
        public async Task<IActionResult> GetGamesWithSalesAsync([FromQuery] int? discount, double? priceFrom, double? priceTo, bool showGamesFromGog, bool showGamesFromSteam, bool showGamesFromEpicGames,  bool getDuplicates)
        {
            // get query
            var request = Context.GameModels.AsQueryable();

            // filtering
            if (discount != null) 
            { 
                request = request.Where(g => g.DiscountInt >= discount);
            }
            if (priceFrom != null) 
            { 
                request = request.Where(g => g.PriceDouble >= priceFrom);
            }
            if (priceTo != null) 
            { 
                request = request.Where(g => g.PriceDouble <= priceTo);
            }

            // filter by stores
            if (showGamesFromGog || showGamesFromSteam || showGamesFromEpicGames)
            {
                var gog = showGamesFromGog ? StoresNames.GOG : string.Empty;
                var steam = showGamesFromSteam ? StoresNames.Steam : string.Empty;
                var epic = showGamesFromEpicGames ? StoresNames.EpicGames : string.Empty;

                request = request.Where(g => g.Site == gog || g.Site == steam || g.Site == epic);
            }

            // get duplicates
            if (getDuplicates == true)
            {
                var names = request.GroupBy(x => x.Name).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
                request = request.Where(x => names.Contains(x.Name)).OrderBy(g => g.Name);
            }

            var result = await request.ToListAsync();
            return Ok(result);
        }

        [HttpGet("game/{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var result = await Context.GameModels.FirstOrDefaultAsync(g => g.Id == id);
            return Ok(result);
        }

        [HttpGet("games/duplicates")]
        public async Task<IActionResult> GetDublicatedGamesAsync()
        {
            var collection = await Context.GameModels.Select(g => g.Name).ToListAsync();
            var anyDuplicates = collection.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            var result = await Context.GameModels.Where(g => anyDuplicates.Contains(g.Name)).OrderBy(g => g.Name).ToListAsync();
            return Ok(result);
        }

        [HttpGet("games/allduplicates")]
        public async Task<IActionResult> GetAllDublicatedGamesAsync()
        {
            var collection = await Context.GameModels.Select(g => g.Name).ToListAsync();
            var anyDuplicates = collection.GroupBy(x => x).Where(g => g.Count() > 2).Select(g => g.Key).ToList();
            var result = await Context.GameModels.Where(g => anyDuplicates.Contains(g.Name)).OrderBy(g => g.Name).ToListAsync();
            return Ok(result);
        }

    }
}
