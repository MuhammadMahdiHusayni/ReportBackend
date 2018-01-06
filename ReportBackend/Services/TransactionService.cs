using Microsoft.EntityFrameworkCore;
using ReportBackend.Data;
using ReportBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ReportBackend.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ReportingContext _context;

        public TransactionService(ReportingContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTransactionAsync(IEnumerable<NewTransaction> transaction)
        {

            foreach(NewTransaction t in transaction)
            {
                var treasury = _context.Treasuries.Where(x => x.TreasuryId == t.TreasuryId).FirstOrDefault();
                if(treasury != null)
                {
                    if(t.TransactionTypeCode == "01")
                    {
                        treasury.AccountBalance = treasury.AccountBalance + t.Amount;
                    }else if(t.TransactionTypeCode == "02")
                    {
                        treasury.AccountBalance = treasury.AccountBalance - t.Amount;
                    }
                    _context.Treasuries.Update(treasury);

                    var entity = new Transaction
                    {
                        UserId = t.UserId,
                        TransactionDate = t.TransactionDate,
                        Amount = t.Amount,
                        Note = t.Note,
                        TransactionTypeCode = t.TransactionTypeCode,
                        DepartmentCode = t.DepartmentCode,
                        TreasuryId = t.TreasuryId
                    };
                    _context.Transactions.Add(entity);
                }                
            }
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<IEnumerable<NewTransaction>> GetAllTransactionAsync()
        {
            return await (from t in _context.Transactions
                          select new NewTransaction
                          {
                              TransactionId = t.TransactionId,
                              TransactionDate = t.TransactionDate,
                              Amount = t.Amount,
                              Note = t.Note,
                              TransactionTypeCode = t.TransactionTypeCode,
                              DepartmentCode = t.DepartmentCode,
                              UserId = t.UserId,
                              TreasuryId = t.TreasuryId
                          }).ToListAsync();
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
