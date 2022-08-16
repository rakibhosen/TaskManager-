using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TASK.WEBAPI.Models
{
    public partial class Projectinf
    {
        public Projectinf()
        {
            Taskinf = new HashSet<Taskinf>();
        }

        public int Pcode { get; set; }
        public string Projname { get; set; }
        public string Projectdesc { get; set; }
        public string Comcod { get; set; }
        public string Assignedto { get; set; }

        public virtual AspNetUsers AssignedtoNavigation { get; set; }
        public virtual Compinf ComcodNavigation { get; set; }
        public virtual ICollection<Taskinf> Taskinf { get; set; }
    }
}
