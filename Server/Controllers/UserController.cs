using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
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
                //var roles = _context.Roles.Where(r => r.Id == _context.Users);
                //var userInRoles = _context.UserRoles.ToList();
                //List<User> users = new List<User>();
                //foreach (var role in userInRoles)
                //{
                //    //User _user = new User();
                //    if (role != null)
                //    {
                //        User _user = new User();

                //    }
                //    name = _userManager.FindByIdAsync(role.UserId);
                //}
                var usersInRoles = await (from u in _context.Users
                                         join userRoles in _context.UserRoles on u.Id equals userRoles.UserId
                                         join role in _context.Roles on userRoles.RoleId equals role.Id
                                         select new { UserName = u.UserName, EmailConfirmed = u.EmailConfirmed, RoleName = role.Name })
                                        .ToListAsync();
                
                List<User> users = new List<User>();
                foreach (var userInRoles in usersInRoles)
                {
                    Console.WriteLine(userInRoles);
                    User _user = new User();
                    _user.Name = userInRoles.UserName;
                    _user.EmailConfirmed = userInRoles.EmailConfirmed;
                    _user.Role.Add(userInRoles.RoleName);
                    users.Add(_user);
                }
                return Ok(users);
            }
            return Ok(user.Scores);
        }
    }
}
