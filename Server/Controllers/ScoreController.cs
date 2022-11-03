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
    public class ScoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ScoreController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //One way to do get
        //[HttpGet]
        //public async Task<ActionResult<List<Score>>> GetScores()
        //{
        //    var user = await _context.Users
        //        .Include(u => u.Scores)
        //        .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)); // User that is authenticated has some claims to the attributes
        //    if (user == null) return NotFound();
        //    return Ok(user.Scores);
        //}

        //Another way to do get with usermanager
        [HttpGet]
        public async Task<ActionResult<List<Score>>> GetScores()
        {
            //var user = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null) return NotFound();
            return Ok(user.Scores);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Score>>> GetSingleUserScores(string name)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(name));
            if (user == null) return NotFound();
            return Ok(user.Scores);
        }

        //Don't have to add[frombody] because we are using a complex type here (Score) as api will assume this comes from body already
        [HttpPost]
        public async Task<ActionResult<Score>> AddScore(Score score)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null) return BadRequest("user not found");
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
