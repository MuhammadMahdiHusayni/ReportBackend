using Microsoft.EntityFrameworkCore;
using ReportBackend.Data;
using ReportBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<bool> AddActivityAsync(NewActivity newActivity)
        {
            bool result = false;
            int actId = 0;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    actId = await SaveActivity(newActivity);
                    result = await SaveActAttendance(newActivity.NewAcitivityAttendances, actId);
                    transaction.Commit();
                }
                catch(Exception)
                {

                }
            }
            return (result && actId != 0);
                
            
        }
        public async Task<IEnumerable<NewActivity>> GetAllActivityAsync()
        {
            return await (from act in _context.Activities
                          select new NewActivity
                          {
                              ActivityId = act.ActivityId,
                              Title = act.Title,
                              Description = act.Description,
                              DateTime = act.DateTime,
                              Location = act.Location,
                              ActivityTypeCode = act.ActivityTypeCode,
                              DepartmentCode = act.DepartmentCode,
                              NewAcitivityAttendances = (from at in _context.AcitivityAttendances
                                                         join u in _context.Users
                                                         on at.UserId equals u.UserId
                                                         where at.ActivityId == act.ActivityId
                                                         select new NewActivityAttendance
                                                         {
                                                             UserId = u.UserId,
                                                             Name = u.Name,
                                                             Email = u.Email
                                                         })
                          }).ToListAsync();
            
        }

        private async Task<int> SaveActivity(NewActivity newActivity)
        {
            var entity = new Activity
            {
                Title = newActivity.Title,
                Description = newActivity.Description,
                DateTime = newActivity.DateTime,
                Location = newActivity.Location,
                ActivityTypeCode = newActivity.ActivityTypeCode,
                DepartmentCode = newActivity.DepartmentCode

            };

            _context.Activities.Add(entity);
            var result = await _context.SaveChangesAsync();
            return entity.ActivityId;
        }

        private async Task<bool> SaveActAttendance(IEnumerable<NewActivityAttendance> newActivityAttendance, int id)
        {
            foreach(NewActivityAttendance a in newActivityAttendance)
            {
                var entity = new AcitivityAttendance
                {
                    UserId = a.UserId,
                    ActivityId = id
                };
                _context.AcitivityAttendances.Add(entity);
            }
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }
    }
}
