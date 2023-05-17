using CookingCoolR5.Data;
using CookingCoolR5.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CookingCoolR5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly AppDbContext Context;

        public GameController(AppDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGamesWithSalesAsync()
        {
            return Ok(await Context.GameModels.ToListAsync());
        }
    }
}
