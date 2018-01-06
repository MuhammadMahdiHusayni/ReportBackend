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
                 .Where(x => x.IsOpen == true)
                 .ToArrayAsync();
        }

        public async Task<bool> AddProjectAsync(NewProject newProject)
        {
            bool saveResult = false;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var projectMember = await AddProject(newProject);
                    saveResult = await AddMemberPrivate(projectMember);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    // TODO: Handle failure
                }
            }
            return saveResult;
        }

        public async Task<IEnumerable<NewProject>> GetProjectByEmailAsync(string email)
        {
            return await (from u in _context.Users
                          where u.Email.Equals(email)
                          join p in _context.Projects
                          on u.UserId equals p.UserId
                          select new NewProject
                          {
                              ProjectId = p.ProjectId,
                              Title = p.Title,
                              Description = p.Description,
                              OverallPlan = p.OverallPlan,
                              IsOpen = p.IsOpen,
                              UserId = p.UserId,
                              NewProjectMembers = (from pm in _context.ProjectMembers
                                                where pm.ProjectId == p.ProjectId
                                                select new NewProjectMember
                                                {
                                                    UserId = pm.UserId,
                                                    ProjectId = pm.ProjectId,
                                                    ProjectPositionCode = pm.ProjectPositionCode
                                                })
                          }).ToListAsync();
            //return await _context.Users
            //    .Where(x => x.Email == email)
            //    .Join(_context.Projects, u => u.UserId, p => p.UserId, (u, p) => new { u, p })
            //    .Where(a => a.p.IsOpen == true)
            //    .Join(_context.ProjectMembers, )
            //    .Select(m => m.p)
            //    .ToListAsync();
        }

        public async Task<bool> AddMemberAsync(IEnumerable<NewProjectMember> newMember)
        {
            foreach (NewProjectMember s in newMember)
            {
                var entity = new ProjectMember
                {
                    ProjectId = s.ProjectId,
                    UserId = s.UserId,
                    ProjectPositionCode = s.ProjectPositionCode
                };
                _context.ProjectMembers.Add(entity);
            }
            var saveResult = await _context.SaveChangesAsync();
            return saveResult != 0;
        }

        private async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                 .Where(x => x.Email == email)
                 .SingleOrDefaultAsync();
        }

        private async Task<ProjectMember> AddProject(NewProject newProject)
        {
            var entity = new Project
            {
                ProjectId = Guid.NewGuid(),
                Title = newProject.Title,
                Description = newProject.Description,
                OverallPlan = newProject.OverallPlan,
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = DateTimeOffset.Now,
                IsOpen = true,
                UserId = newProject.UserId

            };
            _context.Projects.Add(entity);
            var saveResult = await _context.SaveChangesAsync();
            return new ProjectMember
            {
                UserId = newProject.UserId,
                ProjectId = entity.ProjectId
            };
        }

        private async Task<bool> AddMemberPrivate(ProjectMember projectMember)
        {
            var entity = new ProjectMember
            {
                ProjectId = projectMember.ProjectId,
                UserId = projectMember.UserId,
                ProjectPositionCode = "001"

            };
            _context.ProjectMembers.Add(entity);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult != 0;
        }
    }
}
