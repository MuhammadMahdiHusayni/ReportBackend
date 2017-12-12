using System;

namespace ReportBackend.Models
{
    public class Report
    {
        public Guid ReportId { get; set; }

        public Guid ProjectId { get; set; }

        public string Description { get; set; }

        public int ReportCount { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public Project Project { get; set; }
    }
}
