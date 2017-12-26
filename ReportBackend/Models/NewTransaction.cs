using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Models
{
    public class NewTransaction
    {
        public int TransactionId { get; set; }

        public DateTimeOffset? TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public string Note { get; set; }

        public string TransactionTypeCode { get; set; }

        public string DepartmentCode { get; set; }

        public IEnumerable<User> User { get; set; }
    }
}
