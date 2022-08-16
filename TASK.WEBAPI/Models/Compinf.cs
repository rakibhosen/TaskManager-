using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TASK.WEBAPI.Models
{
    public partial class Compinf
    {
        public Compinf()
        {
            Ginf = new HashSet<Ginf>();
            Projectinf = new HashSet<Projectinf>();
            Taskinf = new HashSet<Taskinf>();
        }

        public string Comcod { get; set; }
        public string Comnam { get; set; }
        public string Comfnum { get; set; }

        public virtual ICollection<Ginf> Ginf { get; set; }
        public virtual ICollection<Projectinf> Projectinf { get; set; }
        public virtual ICollection<Taskinf> Taskinf { get; set; }
    }
}
