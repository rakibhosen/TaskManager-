using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TASK.WEBAPI.Models
{
    public partial class Smtpinf
    {
        public int Smtpid { get; set; }
        public string Sendermail { get; set; }
        public string Mailport { get; set; }
        public string Host { get; set; }
        public string Pass { get; set; }
    }
}
