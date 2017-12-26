using Microsoft.EntityFrameworkCore;
using ReportBackend.Data;
using ReportBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ReportingContext _context;

        public TransactionService(ReportingContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTransactionAsync(IEnumerable<Transaction> transaction)
        {
            foreach(Transaction t in transaction)
            {
                var entity = new Transaction
                {
                    UserId = t.UserId,
                    TransactionDate = t.TransactionDate,
                    Amount = t.Amount,
                    Note = t.Note,
                    TransactionTypeCode = t.TransactionTypeCode,
                    DepartmentCode = t.DepartmentCode
                };
                _context.Transactions.Add(entity);
            }
            
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionAsync()
        {
            return await _context.Transactions
                .ToListAsync();
        }

        public async Task<bool> AddAccountAsync(Treasury treasury)
        {
            _context.Treasuries.Add(treasury);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<IEnumerable<Treasury>> GetAllAccountAsync()
        {
            return await _context.Treasuries
                .ToListAsync();
        }
    }
}
