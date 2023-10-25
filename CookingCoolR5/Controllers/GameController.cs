using CookingCoolR5.Data;
using CookingCoolR5.Data.Constants;
using CookingCoolR5.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CookingCoolR5.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly AppDbContext Context;

        public GameController(AppDbContext context)
        {
            Context = context;
        }

        [HttpPost("games")]
        public async Task<IActionResult> GetGamesWithSalesAsync([FromBody] GamesFilterVm gamesFilter)
        {
            // get query
            var request = Context.GameModels.AsQueryable();

            // filtering
            if (gamesFilter.Discount != null) 
            { 
                request = request.Where(g => g.DiscountInt >= gamesFilter.Discount);
            }
            if (gamesFilter.PriceFrom != null) 
            { 
                request = request.Where(g => g.PriceDouble >= gamesFilter.PriceFrom);
                var req = request.ToArray();
            }
            if (gamesFilter.PriceTo != null) 
            { 
                request = request.Where(g => g.PriceDouble <= gamesFilter.PriceTo);
                var req2 = request.ToArray();
            }

            //filter by stores
            if (gamesFilter.ShowGamesFromGog || gamesFilter.ShowGamesFromSteam || gamesFilter.ShowGamesFromEpicGames)
            {
                var gog = gamesFilter.ShowGamesFromGog ? StoresNames.GOG : string.Empty;
                var steam = gamesFilter.ShowGamesFromSteam ? StoresNames.Steam : string.Empty;
                var epic = gamesFilter.ShowGamesFromEpicGames ? StoresNames.EpicGames : string.Empty;

                request = request.Where(g => g.Site == gog || g.Site == steam || g.Site == epic);
            }

            // get duplicates
            if (gamesFilter.GetDuplicates == true)
            {
                var names = request.GroupBy(x => x.Name).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
                request = request.Where(x => names.Contains(x.Name)).OrderBy(g => g.Name);
            }

            // search by word
            if (!string.IsNullOrEmpty(gamesFilter.SearchWord))
            {
                request = request.Where(r => r.Name.Contains(gamesFilter.SearchWord));
            }

            // sort
            if ((int)gamesFilter.SortByPrice != 1)
            {
                request = gamesFilter.SortByPrice == SortType.LowToMax ? request.OrderBy(g => g.PriceDouble) : request.OrderByDescending(g => g.PriceDouble);
            }
            if ((int)gamesFilter.SortByRelevance != 1)
            {
                request = gamesFilter.SortByRelevance == SortType.LowToMax ? request.OrderBy(g => g.Relevance) : request.OrderByDescending(g => g.Relevance);
            }

            var result = await request.ToListAsync();
            return Ok(result);
        }

        [HttpPost("addGame")]
        public async Task<IActionResult> AddGame([FromBody] AddGameToCollection request)
        {
            var user = await Context.Users.Include(u => u.GameModels).FirstOrDefaultAsync(u => u.Id == request.UserId);
            var game = await Context.GameModels.FirstOrDefaultAsync(g => g.Id == request.GameId);

            if(!user.GameModels.Any(g => g.Id == game.Id)) 
            { 
                user.GameModels.Add(game);
                await Context.SaveChangesAsync();
                return Ok($"{user.Name}:</br>Game {game.Name} was added to your collection.");
            }

            return Ok($"{user.Name}:</br>Game {game.Name} already in your collection.");
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
