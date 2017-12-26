using System;
using System.Collections.Generic;

namespace ReportBackend.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public DateTimeOffset? TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public string Note { get; set; }

        public string TransactionTypeCode { get; set; }

        public string DepartmentCode { get; set; }
        
        public Guid UserId { get; set; }

        public int TreasuryId { get; set; }

        public Treasury treasury { get; set; }

        public User User { get; set; }
    }
}
