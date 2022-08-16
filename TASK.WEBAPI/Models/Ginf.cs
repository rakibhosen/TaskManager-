using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TASK.WEBAPI.Models
{
    public partial class Ginf
    {
        public Ginf()
        {
            Taskinf = new HashSet<Taskinf>();
        }

        public string Comcod { get; set; }
        public string Gcod { get; set; }
        public string Gdesc { get; set; }

        public virtual Compinf ComcodNavigation { get; set; }
        public virtual ICollection<Taskinf> Taskinf { get; set; }
    }
}
