using Speed.Shared;
using Microsoft.AspNetCore.Identity;

namespace Speed.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Score> Scores { get; set; } = new List<Score>();
    }
}