using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Models
{
    public class Logging
    {
        public Guid LoggingId { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public string AffectedId { get; set; }

        public string AffectedTable { get; set; }

        public string Model { get; set; }

        public string DeviceUuid { get; set; }

        public string Manufacturer { get; set; }

        public string IsVirtual { get; set; }

        public string Platform { get; set; }

        public string Serial { get; set; }
    }
}
