using System;
using System.Collections.Generic;

namespace apiflight.Models
{
    public partial class CourseArpit
    {
        public CourseArpit()
        {
            StudentArpits = new HashSet<StudentArpit>();
        }

        public int Cid { get; set; }
        public string? Cname { get; set; }

        public virtual ICollection<StudentArpit> StudentArpits { get; set; }
    }
}
