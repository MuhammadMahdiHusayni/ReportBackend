using System;

namespace ReportBackend.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string OverallPlan { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public bool IsOpen { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
