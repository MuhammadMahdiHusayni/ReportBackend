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
            return;
        }
    }
}
