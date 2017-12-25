using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Models
{
    public class NewMeeting
    {
        public string Title { get; set; }

        public string Note { get; set; }

        public string Location { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public IEnumerable<Attendance> Attendance { get; set; }

        public IEnumerable<NewAgenda> Agenda { get; set; }

        public IEnumerable<NewAction> Action { get; set; }

    }
}
