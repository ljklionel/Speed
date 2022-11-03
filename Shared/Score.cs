using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Shared
{
    public class Score
    {
        public long Id { get; set; }
        public int Accuracy { get; set; }
        public int WPM { get; set; }
        public int Error { get; set; }
        public string? ApplicationUserId { get; set; }
    }
}
