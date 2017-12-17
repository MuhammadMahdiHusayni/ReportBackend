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

    }
}
