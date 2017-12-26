using System;
using System.Collections.Generic;

namespace ReportBackend.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public string Location { get; set; }

        public string ActivityTypeCode { get; set; }

        public string DepartmentCode { get; set; }

        public virtual ICollection<AcitivityAttendance> AcitivityAttendances { get; set; }
    }
}
