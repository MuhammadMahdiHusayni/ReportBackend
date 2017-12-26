using ReportBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public interface ITransactionService
    {
        Task<bool> AddTransactionAsync(IEnumerable<Transaction> transaction);
        Task<IEnumerable<Transaction>> GetAllTransactionAsync();

        Task<bool> AddAccountAsync(Treasury treasury);
        Task<IEnumerable<Treasury>> GetAllAccountAsync();
    }
}
