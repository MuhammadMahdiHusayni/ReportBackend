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
        public DbSet<Report> Reports { get; set; }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingAttendance> MeetingAttendances { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Action> Actions { get; set; }

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

            modelBuilder.Entity<MeetingAttendance>()
                .HasKey(m => new { m.MeetingId, m.UserId });
        }
    }
}
