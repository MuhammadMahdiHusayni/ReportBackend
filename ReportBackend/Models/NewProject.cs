using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Models
{
    public class NewProject
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string OverallPlan { get; set; }

        public Guid UserId { get; set; }
        public Guid ProjectId { get; internal set; }
        public DateTimeOffset CreatedDate { get; internal set; }
        public DateTimeOffset UpdatedDate { get; internal set; }
        public bool IsOpen { get; internal set; }
        public IEnumerable<NewProjectMember> NewProjectMembers { get; internal set; }
    }
}
