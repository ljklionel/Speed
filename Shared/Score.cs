﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Shared
{
    public class Score
    {
        public int Id { get; set; }
        public int Accuracy { get; set; }
        public int WPM { get; set; }
        public int Error { get; set; }
    }
}