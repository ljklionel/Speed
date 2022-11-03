using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Speed.Server.Data;
using Speed.Server.Models;
using Speed.Shared;
using System.Security.Claims;

// https://www.youtube.com/watch?v=K_P-qJj_8Bg
namespace Speed.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Another way to do get with usermanager
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            //var user = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null) return NotFound();
            if (User.IsInRole("Admin"))
            {
                Console.WriteLine("test");
            }
            return Ok(user.Scores);
        }
    }
}
