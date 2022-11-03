using Microsoft.AspNetCore.Identity;
using Speed.Shared;

namespace Speed.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Score> Scores { get; set; } = new List<Score>();
    }
}