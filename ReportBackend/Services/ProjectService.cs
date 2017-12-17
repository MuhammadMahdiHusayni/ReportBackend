using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportBackend.Data;
using ReportBackend.Models;

namespace ReportBackend.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ReportingContext _context;

        public ProjectService(ReportingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetOpenProjectAsync()
        {
            // need to check against user id
            return await _context.Projects
                 .Where(x => x.IsOpen == true)
                 .ToArrayAsync();
        }

        public async Task<bool> AddProjectAsync(IEnumerable<NewProject> newProject)
        {
            foreach (NewProject s in newProject)
            {
                var entity = new Project
                {
                    ProjectId = Guid.NewGuid(),
                    Title = s.Title,
                    Description = s.Description,
                    OverallPlan = s.OverallPlan,
                    CreatedDate = DateTimeOffset.Now,
                    UpdatedDate = DateTimeOffset.Now,
                    IsOpen = true,
                    UserId = s.UserId

                };
                _context.Projects.Add(entity);
            }
            var saveResult = await _context.SaveChangesAsync();
            return saveResult != 0;
        }

        public async Task<IEnumerable<Project>> GetProjectByIdAsync(Guid id)
        {
            // need to check against user id
            return await _context.Projects
                 .Where(x => x.UserId == id)
                 .ToArrayAsync();
        }
    }
}
