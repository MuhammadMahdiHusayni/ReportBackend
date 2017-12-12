using ReportBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetReportByProjectAsync(Guid id);
        Task<bool> AddReportAsync(IEnumerable<NewReport> newReport);
    }
}
