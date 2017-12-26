using System;

namespace ReportBackend.Models
{
    public class UserResource
    {
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
