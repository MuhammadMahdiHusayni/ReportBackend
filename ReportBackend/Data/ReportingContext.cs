using Microsoft.EntityFrameworkCore;
using ReportBackend.Models;

namespace ReportBackend.Data
{
    public class ReportingContext : DbContext
    {
        public ReportingContext(DbContextOptions<ReportingContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<ProjectPosition> ProjectPositions { get; set; }
        public DbSet<Report> Reports { get; set; }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingAttendance> MeetingAttendances { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Action> Actions { get; set; }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<AcitivityAttendance> AcitivityAttendances { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }


        public DbSet<Treasury> Treasuries { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<UserResource> UserResources { get; set; }

        public DbSet<Logging> Loggings { get; set; }

        //doesnt pluralize db name
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Report>().ToTable("Report");

            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<MeetingAttendance>().ToTable("MeetingAttendance");
            modelBuilder.Entity<Agenda>().ToTable("Agenda");
            modelBuilder.Entity<Action>().ToTable("Action");

            modelBuilder.Entity<AcitivityAttendance>().ToTable("AcitivityAttendance");
            modelBuilder.Entity<Activity>().ToTable("Activity");
            modelBuilder.Entity<ActivityType>().ToTable("ActivityType");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<ProjectMember>().ToTable("ProjectMember");
            modelBuilder.Entity<ProjectPosition>().ToTable("ProjectPosition");
            modelBuilder.Entity<Resource>().ToTable("Resource");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<TransactionType>().ToTable("TransactionType");
            modelBuilder.Entity<Treasury>().ToTable("Treasury");
            modelBuilder.Entity<UserResource>().ToTable("UserResource");
            



            modelBuilder.Entity<MeetingAttendance>()
                    .HasKey(m => new { m.MeetingId, m.UserId });

            modelBuilder.Entity<ProjectMember>()
                .HasKey(m => new { m.ProjectId, m.UserId });

            modelBuilder.Entity<UserResource>()
                .HasKey(m => new { m.UserId, m.ResourceId });

            modelBuilder.Entity<AcitivityAttendance>()
                .HasKey(m => new { m.UserId, m.ActivityId });
            
        }
    }
}
