using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportBackend.Models;

namespace ReportBackend.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetOpenProjectAsync();
        Task<bool> AddProjectAsync(NewProject newProject);
        Task<IEnumerable<Project>> GetProjectByEmailAsync(string email);
        Task<bool> AddMemberAsync(IEnumerable<ProjectMember> newMember);
    }
}
