using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TASK.WEBAPI.Models
{
    public partial class PINBOARDContext : DbContext
    {
        public PINBOARDContext()
        {
        }

        public PINBOARDContext(DbContextOptions<PINBOARDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Chatlog> Chatlog { get; set; }
        public virtual DbSet<Compinf> Compinf { get; set; }
        public virtual DbSet<Ginf> Ginf { get; set; }
        public virtual DbSet<Projectinf> Projectinf { get; set; }
        public virtual DbSet<Smtpinf> Smtpinf { get; set; }
        public virtual DbSet<Taskinf> Taskinf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TEAMOS-PC\\SQLEXPRESS;Database=PINBOARD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Chatlog>(entity =>
            {
                entity.ToTable("chatlog");

                entity.Property(e => e.Chatlogid)
                    .HasColumnName("CHATLOGID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fromid)
                    .IsRequired()
                    .HasColumnName("FROMID")
                    .HasMaxLength(450);

                entity.Property(e => e.Postdat)
                    .HasColumnName("POSTDAT")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("('01-01-1900')");

                entity.Property(e => e.Toid)
                    .IsRequired()
                    .HasColumnName("TOID")
                    .HasMaxLength(450);

                entity.Property(e => e.Txtbody)
                    .IsRequired()
                    .HasColumnName("TXTBODY")
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.From)
                    .WithMany(p => p.ChatlogFrom)
                    .HasForeignKey(d => d.Fromid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__chatlog__FROMID__6B24EA82");

                entity.HasOne(d => d.To)
                    .WithMany(p => p.ChatlogTo)
                    .HasForeignKey(d => d.Toid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__chatlog__TOID__6C190EBB");
            });

            modelBuilder.Entity<Compinf>(entity =>
            {
                entity.HasKey(e => e.Comcod)
                    .HasName("PK__compinf__C72BD5CEB201C106");

                entity.ToTable("compinf");

                entity.Property(e => e.Comcod)
                    .HasColumnName("COMCOD")
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.Comfnum)
                    .HasColumnName("COMFNUM")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comnam)
                    .IsRequired()
                    .HasColumnName("COMNAM")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Ginf>(entity =>
            {
                entity.HasKey(e => e.Gcod)
                    .HasName("PK__ginf__593338DBE916061D");

                entity.ToTable("ginf");

                entity.Property(e => e.Gcod)
                    .HasColumnName("GCOD")
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.Comcod)
                    .IsRequired()
                    .HasColumnName("COMCOD")
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.Gdesc)
                    .IsRequired()
                    .HasColumnName("GDESC")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ComcodNavigation)
                    .WithMany(p => p.Ginf)
                    .HasForeignKey(d => d.Comcod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ginf__COMCOD__4D94879B");
            });

            modelBuilder.Entity<Projectinf>(entity =>
            {
                entity.HasKey(e => e.Pcode)
                    .HasName("PK__projecti__7E24F7D20D9D03D8");

                entity.ToTable("projectinf");

                entity.Property(e => e.Pcode).HasColumnName("PCODE");

                entity.Property(e => e.Assignedto)
                    .IsRequired()
                    .HasColumnName("ASSIGNEDTO")
                    .HasMaxLength(450);

                entity.Property(e => e.Comcod)
                    .HasColumnName("COMCOD")
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.Projectdesc)
                    .HasColumnName("PROJECTDESC")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Projname)
                    .IsRequired()
                    .HasColumnName("PROJNAME")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.AssignedtoNavigation)
                    .WithMany(p => p.Projectinf)
                    .HasForeignKey(d => d.Assignedto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__projectin__ASSIG__5441852A");

                entity.HasOne(d => d.ComcodNavigation)
                    .WithMany(p => p.Projectinf)
                    .HasForeignKey(d => d.Comcod)
                    .HasConstraintName("FK__projectin__COMCO__534D60F1");
            });

            modelBuilder.Entity<Smtpinf>(entity =>
            {
                entity.HasKey(e => e.Smtpid)
                    .HasName("PK__smtpinf__5C333998321D1DA2");

                entity.ToTable("smtpinf");

                entity.Property(e => e.Smtpid)
                    .HasColumnName("SMTPID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasColumnName("HOST")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mailport)
                    .IsRequired()
                    .HasColumnName("MAILPORT")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("PASS")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sendermail)
                    .IsRequired()
                    .HasColumnName("SENDERMAIL")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Taskinf>(entity =>
            {
                entity.HasKey(e => e.Taskcode)
                    .HasName("PK__taskinf__2B1F676F5E3C88EC");

                entity.ToTable("taskinf");

                entity.Property(e => e.Taskcode).HasColumnName("TASKCODE");

                entity.Property(e => e.Assignedby)
                    .HasColumnName("ASSIGNEDBY")
                    .HasMaxLength(450);

                entity.Property(e => e.Assignedto)
                    .HasColumnName("ASSIGNEDTO")
                    .HasMaxLength(450);

                entity.Property(e => e.Comcod)
                    .IsRequired()
                    .HasColumnName("COMCOD")
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.Createdby)
                    .HasColumnName("CREATEDBY")
                    .HasMaxLength(450);

                entity.Property(e => e.Createddate)
                    .HasColumnName("CREATEDDATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Editedid)
                    .HasColumnName("EDITEDID")
                    .HasMaxLength(450);

                entity.Property(e => e.Estmtime)
                    .HasColumnName("ESTMTIME")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Pcode).HasColumnName("PCODE");

                entity.Property(e => e.Posteddate)
                    .HasColumnName("POSTEDDATE")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("('01-01-1900')");

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Startdate)
                    .HasColumnName("STARTDATE")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("('01-01-1900')");

                entity.Property(e => e.Taskdesc)
                    .HasColumnName("TASKDESC")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Taskstatus)
                    .HasColumnName("TASKSTATUS")
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.Priority)
               .HasColumnName("PRIORITY")
               .HasMaxLength(7)
               .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TITLE")
                    .HasMaxLength(230)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.AssignedbyNavigation)
                    .WithMany(p => p.TaskinfAssignedbyNavigation)
                    .HasForeignKey(d => d.Assignedby)
                    .HasConstraintName("FK__taskinf__ASSIGNE__5AEE82B9");

                entity.HasOne(d => d.AssignedtoNavigation)
                    .WithMany(p => p.TaskinfAssignedtoNavigation)
                    .HasForeignKey(d => d.Assignedto)
                    .HasConstraintName("FK__taskinf__ASSIGNE__5BE2A6F2");

                entity.HasOne(d => d.ComcodNavigation)
                    .WithMany(p => p.Taskinf)
                    .HasForeignKey(d => d.Comcod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__taskinf__COMCOD__5DCAEF64");

                entity.HasOne(d => d.CreatedbyNavigation)
                    .WithMany(p => p.TaskinfCreatedbyNavigation)
                    .HasForeignKey(d => d.Createdby)
                    .HasConstraintName("FK__taskinf__CREATED__59FA5E80");

                entity.HasOne(d => d.Edited)
                    .WithMany(p => p.TaskinfEdited)
                    .HasForeignKey(d => d.Editedid)
                    .HasConstraintName("FK__taskinf__EDITEDI__5CD6CB2B");

                entity.HasOne(d => d.PcodeNavigation)
                    .WithMany(p => p.Taskinf)
                    .HasForeignKey(d => d.Pcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__taskinf__PCODE__5EBF139D");

                entity.HasOne(d => d.TaskstatusNavigation)
                    .WithMany(p => p.Taskinf)
                    .HasForeignKey(d => d.Taskstatus)
                    .HasConstraintName("FK__taskinf__TASKSTA__59063A47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
