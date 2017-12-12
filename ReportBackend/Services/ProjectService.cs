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
            return await _context.Projects
                 .Where(x => x.IsOpen == true && x.Fk_UserId == 1)
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
                    CreatedDate = DateTimeOffset.Now,
                    UpdatedDate = DateTimeOffset.Now,
                    IsOpen = true,
                    Fk_UserId = 1

                };
                _context.Projects.Add(entity);
            }
            var saveResult = await _context.SaveChangesAsync();
            return saveResult != 0;
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _context.Projects
                 .Where(x => x.ProjectId == id && x.Fk_UserId == 1)
                 .SingleOrDefaultAsync();
        }
    }
}
