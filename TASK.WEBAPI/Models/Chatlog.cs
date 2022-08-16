using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TASK.WEBAPI.Models
{
    public partial class Chatlog
    {
        public int Chatlogid { get; set; }
        public string Fromid { get; set; }
        public string Toid { get; set; }
        public string Txtbody { get; set; }
        public DateTime? Postdat { get; set; }

        public virtual AspNetUsers From { get; set; }
        public virtual AspNetUsers To { get; set; }
    }
}
