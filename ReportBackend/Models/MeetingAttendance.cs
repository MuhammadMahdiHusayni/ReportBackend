using System;

namespace ReportBackend.Models
{
    public class MeetingAttendance
    {
        public int MeetingId { get; set; }
        public virtual Meeting Meeting { get; set; }
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
