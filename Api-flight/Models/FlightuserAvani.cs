using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiflight.Models
{
    public partial class FlightuserAvani
    {
        [Required(ErrorMessage ="*")]
        public int Userid { get; set; }
        public string? Username { get; set; }
       
        [MinLength(4)]
        [Required(ErrorMessage ="Password must contain minimum 4 characters")]
        public string? Userpass { get; set; }
    }
}
