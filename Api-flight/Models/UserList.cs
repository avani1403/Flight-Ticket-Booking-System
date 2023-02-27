using System;
using System.Collections.Generic;

namespace apiflight.Models
{
    public partial class UserList
    {
        public string UserId { get; set; } = null!;
        public string? Password { get; set; }
    }
}
