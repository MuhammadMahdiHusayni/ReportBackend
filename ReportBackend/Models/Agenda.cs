using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Models
{
    public class Agenda
    {
        public int AgendaId { get; set; }

        public string Description { get; set; }

        public int MeetingId { get; set; }

        public Meeting Meeting { get; set; }
    }
}
