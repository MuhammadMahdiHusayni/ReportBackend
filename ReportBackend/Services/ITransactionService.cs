using ReportBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public interface ITransactionService
    {
        Task<bool> AddTransactionAsync(IEnumerable<NewTransaction> transaction);
        Task<IEnumerable<NewTransaction>> GetAllTransactionAsync();

        Task<bool> AddAccountAsync(Treasury treasury);
        Task<IEnumerable<Treasury>> GetAllAccountAsync();
    }
}
