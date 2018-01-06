using ReportBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public interface IActivityService
    {
        Task<bool> AddActivityAsync(NewActivity newActivity);
        Task<IEnumerable<NewActivity>> GetAllActivityAsync();
    }
}
