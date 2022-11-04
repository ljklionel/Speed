using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Shared
{
    public class User
    {
        public string? Name { get; set; }

        //public bool EmailConfirmed { get; set; }
        public List<string> Role { get; set; } = new List<string>();
    }
}
