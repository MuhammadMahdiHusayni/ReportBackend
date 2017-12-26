using System;

namespace ReportBackend.Models
{
    public class AcitivityAttendance
    {
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
