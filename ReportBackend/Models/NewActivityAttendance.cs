using System;

namespace ReportBackend.Models
{
    public class NewActivityAttendance
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
