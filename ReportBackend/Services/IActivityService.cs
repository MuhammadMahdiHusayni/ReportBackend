using ReportBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public interface IActivityService
    {
        Task<bool> AddActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> GetAllActivityAsync();
    }
}
