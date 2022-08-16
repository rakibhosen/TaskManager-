using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TASK.WEBAPI.Models
{
    public partial class Taskinf
    {
        public int Taskcode { get; set; }
        public string Title { get; set; }
        public string Taskdesc { get; set; }
        public string Taskstatus { get; set; }
        public string Priority { get; set; }

        public string Createdby { get; set; }
        public string Assignedby { get; set; }
        public string Assignedto { get; set; }
        public string Editedid { get; set; }
        public string Comcod { get; set; }
        public int Pcode { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Posteddate { get; set; }
        public int? Estmtime { get; set; }
        public string Remarks { get; set; }

        public virtual AspNetUsers AssignedbyNavigation { get; set; }
        public virtual AspNetUsers AssignedtoNavigation { get; set; }
        public virtual Compinf ComcodNavigation { get; set; }
        public virtual AspNetUsers CreatedbyNavigation { get; set; }
        public virtual AspNetUsers Edited { get; set; }
        public virtual Projectinf PcodeNavigation { get; set; }
        public virtual Ginf TaskstatusNavigation { get; set; }
    }
}
