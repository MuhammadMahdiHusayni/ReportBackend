using System.Collections.Generic;

namespace ReportBackend.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public virtual ICollection<UserResource> UserResources { get; set; }
    }
}
