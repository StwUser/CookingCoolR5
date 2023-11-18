using CookingCoolR5.Data;
using CookingCoolR5.Data.Interfaces;
using CookingCoolR5.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SteamApi;
using System.Threading.Tasks;

namespace CookingCoolR5.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SteamApiController : ControllerBase
    {
        private readonly AppDbContext Context;
        private readonly ISteamApiService SteamApiService;

        public SteamApiController(AppDbContext context, ISteamApiService steamApiService)
        {
            Context = context;
            SteamApiService = steamApiService;
        }

        [HttpPost("game")]
        public async Task<IActionResult> GetGameByName([FromBody] GetGameByName request)
        {
            var result = await SteamApiService.GetGameInfoByName(request.GameName);
            var jsonRes = JsonConvert.SerializeObject(result);
            //return Ok(jsonRes);
            return Ok(result);
        }
    }
}
