using System;
using System.Collections.Generic;

namespace ReportBackend.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public string Location { get; set; }

        public virtual ICollection<MeetingAttendance> MeetingAttendances { get; set; }

        public ICollection<Agenda> Agendas { get; set; }

        public ICollection<Action> Actions { get; set; }

    }
}
