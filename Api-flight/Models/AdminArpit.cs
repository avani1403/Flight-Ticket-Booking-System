﻿using System;
using System.Collections.Generic;

namespace apiflight.Models
{
    public partial class AdminArpit
    {
        public int Userid { get; set; }
        public string? Username { get; set; }
        public string Pwd { get; set; } = null!;
    }
}
