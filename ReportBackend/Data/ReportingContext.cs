using Microsoft.EntityFrameworkCore;
using ReportBackend.Models;

namespace ReportBackend.Data
{
    public class ReportingContext : DbContext
    {
        public ReportingContext(DbContextOptions<ReportingContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Report> Reports { get; set; }

        //doesnt pluralize db name
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Report>().ToTable("Report");
        }
    }
}
