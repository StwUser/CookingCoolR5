using CookingCoolR5.Data;
using CookingCoolR5.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParserHelper.Models;
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
        public async Task<IActionResult> GetGamesWithSalesAsync()
        {
            return Ok(await Context.GameModels.ToListAsync());
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
