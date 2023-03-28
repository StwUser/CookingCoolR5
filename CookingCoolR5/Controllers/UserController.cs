using CookingCoolR5.Data;
using CookingCoolR5.Data.Constants;
using CookingCoolR5.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CookingCoolR5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext Context;

        public UserController(AppDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Authorize(Roles = nameof(Roles.Admin))]
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await Context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Roles.Admin))]
        public async Task<IActionResult> PostUserAsync(User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
            return Ok($"User {user.Name} created");
        }

        [HttpPut]
        [Authorize(Roles = nameof(Roles.Admin))]
        public async Task<IActionResult> PutUserAsync(User user)
        {
            var oldUser = await Context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (oldUser == null)
            {
                return NotFound();
            }

            oldUser.Name = user.Name;

            await Context.SaveChangesAsync();
            return Ok($"User {user.Name} updated");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(Roles.Admin))]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                Context.Users.Remove(user);
                await Context.SaveChangesAsync();
            }
            return Ok($"User {id} deleted");
        }
    }
}
