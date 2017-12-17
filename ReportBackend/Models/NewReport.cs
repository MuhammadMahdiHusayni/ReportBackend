using System;

namespace ReportBackend.Models
{
    public class NewReport
    {
        public Guid ProjectId { get; set; }

        public string Description { get; set; }

        public string NextPlan { get; set; }

    }
}
