using Microsoft.EntityFrameworkCore;
using ReportBackend.Data;
using ReportBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ReportingContext _context;

        public ActivityService(ReportingContext context)
        {
            _context = context;
        }
        public async Task<bool> AddActivityAsync(Activity activity)
        {
            var entity = new Activity
            {

            };
            _context.Activities.Add(activity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }
        public async Task<IEnumerable<Activity>> GetAllActivityAsync()
        {
            return await _context.Activities
                .ToListAsync();
        }
    }
}
