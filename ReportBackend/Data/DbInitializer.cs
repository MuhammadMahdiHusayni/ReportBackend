using ReportBackend.Models;
using System;
using System.Linq;

namespace ReportBackend.Data
{
    public class DbInitializer
    {
        public static void Initialize(ReportingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Projects.Any())
            {
                return;   // DB has been seeded
            }

            return;

            //var users = new User[]
            //{
            //    new User
            //    {
            //        UserId = Guid.NewGuid(),
            //        Name = "Muhammad Mahdi",
            //        Email = "mahdi.azizan@mimos.my",
            //        Role = "Administrator",
            //        Resource = "ADMIN"
            //    },
            //    new User
            //    {
            //        UserId = Guid.NewGuid(),
            //        Name = "Muhammad Syahid",
            //        Email = "ayid.gpmm@gmail.com",
            //        Role = "User",
            //        Resource = "REPORT"
            //    }

            //};

            //foreach (User s in users)
            //{
            //    context.Users.Add(s);
            //}

            //context.SaveChanges();




            //var projects = new Project[]
            //{
            //    new Project
            //    {
            //        ProjectId = Guid.NewGuid(),
            //        Title = "Learn ASP.NET Core",
            //        Description = "Learn ASP.NET Core",
            //        CreatedDate = DateTimeOffset.Now,
            //        UpdatedDate = DateTimeOffset.Now,
            //        IsOpen = true,
            //        Fk_UserId = 1

            //    },
            //    new Project
            //    {
            //        ProjectId = Guid.NewGuid(),
            //        Title = "Build awesome apps",
            //        Description = "Build awesome apps",
            //        CreatedDate = DateTimeOffset.Now,
            //        UpdatedDate = DateTimeOffset.Now,
            //        IsOpen = true,
            //        Fk_UserId = 1
            //    }

            //};

            //foreach (Project s in projects)
            //{
            //    context.Projects.Add(s);
            //}

            //context.SaveChanges();

            //var reports = new Report[]
            //{
            //    new Report
            //    {
            //        ProjectId = Guid.NewGuid(),
            //        Description = "Initialize",
            //        CreatedDate = DateTimeOffset.Now,
            //        UpdatedDate = DateTimeOffset.Now,
            //        ReportCount = 1
            //    },
            //    new Report
            //    {
            //        ProjectId = Guid.NewGuid(),
            //        Description = "Initialize 2",
            //        CreatedDate = DateTimeOffset.Now,
            //        UpdatedDate = DateTimeOffset.Now,
            //        ReportCount = 2
            //    }
            //};

            //foreach (Report s in reports)
            //{
            //    context.Reports.Add(s);
            //}

            //context.SaveChanges();
        }
    }
}
