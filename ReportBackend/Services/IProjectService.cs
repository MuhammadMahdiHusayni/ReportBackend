using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportBackend.Models;

namespace ReportBackend.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetOpenProjectAsync();
        Task<bool> AddProjectAsync(IEnumerable<NewProject> newProject);
        Task<IEnumerable<Project>> GetProjectByEmailAsync(string email);
    }
}
