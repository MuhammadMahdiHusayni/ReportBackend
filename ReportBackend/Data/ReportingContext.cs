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
        public DbSet<Logging> Loggings { get; set; }

        //doesnt pluralize db name
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Report>().ToTable("Report");
            modelBuilder.Entity<Logging>().ToTable("Logging");
        }
    }
}
