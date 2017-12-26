using System;
using System.Collections.Generic;

namespace ReportBackend.Models
{
    public class User
    {

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual ICollection<MeetingAttendance> MeetingAttendances { get; set; }

        public virtual ICollection<AcitivityAttendance> AcitivityAttendances { get; set; }

        public virtual ICollection<UserResource> UserResources { get; set; }

        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
