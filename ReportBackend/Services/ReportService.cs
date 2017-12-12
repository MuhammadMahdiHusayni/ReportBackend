using Microsoft.EntityFrameworkCore;
using ReportBackend.Data;
using ReportBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public class ReportService : IReportService
    {
        private readonly ReportingContext _context;

        public ReportService(ReportingContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Report>> GetReportByProjectAsync(Guid id)
        {
            return await _context.Reports
                 .Where(x => x.ProjectId == id)
                 .ToArrayAsync();
        }
        public async Task<bool> AddReportAsync(IEnumerable<NewReport> newReport)
        {
            var count = await _context.Reports
                .Where(x => x.ProjectId == newReport.FirstOrDefault().ProjectId)
                .CountAsync();
            foreach (NewReport s in newReport)
            {
                var entity = new Report
                {
                    ProjectId = s.ProjectId,
                    Description = s.Description,
                    CreatedDate = DateTimeOffset.Now,
                    UpdatedDate = DateTimeOffset.Now,
                    ReportCount = count + 1
                };
                _context.Reports.Add(entity);
            }
            var saveResult = await _context.SaveChangesAsync();
            return saveResult != 0;
        }
    }
}
