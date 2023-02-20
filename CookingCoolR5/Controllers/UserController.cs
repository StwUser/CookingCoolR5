using CookingCoolR5.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CookingCoolR5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext Context;
        public UserController(AppDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            if(Context.Users.Count() == 0) 
            { 
                Context.Users.Add(new Data.Models.User { Email = "mickn7@mail.ru", IsEmailConfirmed = true, Login = "admin", Password = "admin", Name = "StWolf", Role = "Admin" });
                Context.SaveChanges();
            }
            return Ok(await Context.Users.ToListAsync());
        }
    }
}
