using System;

namespace ReportBackend.Models
{
    public class NewProjectMember
    {
        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public string ProjectPositionCode { get; set; }
    }
}
