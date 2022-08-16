using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TASK.WEBAPI.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            ChatlogFrom = new HashSet<Chatlog>();
            ChatlogTo = new HashSet<Chatlog>();
            Projectinf = new HashSet<Projectinf>();
            TaskinfAssignedbyNavigation = new HashSet<Taskinf>();
            TaskinfAssignedtoNavigation = new HashSet<Taskinf>();
            TaskinfCreatedbyNavigation = new HashSet<Taskinf>();
            TaskinfEdited = new HashSet<Taskinf>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Chatlog> ChatlogFrom { get; set; }
        public virtual ICollection<Chatlog> ChatlogTo { get; set; }
        public virtual ICollection<Projectinf> Projectinf { get; set; }
        public virtual ICollection<Taskinf> TaskinfAssignedbyNavigation { get; set; }
        public virtual ICollection<Taskinf> TaskinfAssignedtoNavigation { get; set; }
        public virtual ICollection<Taskinf> TaskinfCreatedbyNavigation { get; set; }
        public virtual ICollection<Taskinf> TaskinfEdited { get; set; }
    }
}
