using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Models
{
    public class Attendance
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

    }
}
