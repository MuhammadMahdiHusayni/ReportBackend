using Microsoft.EntityFrameworkCore;
using ReportBackend.Data;
using ReportBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ReportingContext _context;

        public MeetingService(ReportingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetingAsync()
        {
            return await _context.Meetings
                .ToListAsync();

        }

        public async Task<bool> AddMeetingAsync(NewMeeting newMeeting)
        {
            bool createAction = false;
            bool createAgenda = false;
            bool createAttendance = false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int meetingId = await CreateMeeting(newMeeting);
                    createAgenda = await CreateAgenda(newMeeting, meetingId);
                    createAction = await CreateAction(newMeeting, meetingId);
                    createAttendance = await CreateMeetingAttendance(newMeeting, meetingId);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // TODO: Handle failure
                }
            }
            return (createAction && createAgenda && createAttendance) == true;
        }

        public async Task<NewMeeting> GetMeetingById(int meetingId)
        {

            return await (from m in _context.Meetings
                          where m.MeetingId.Equals(meetingId)
                          select new NewMeeting
                          {
                              Title = m.Title,
                              Note = m.Note,
                              Location = m.Location,
                              DateTime = m.DateTime,
                              Attendance = (from mt in _context.MeetingAttendances
                                            join u in _context.Users
                                            on mt.UserId equals u.UserId
                                            where mt.MeetingId == m.MeetingId
                                            select new Attendance
                                            {
                                                Name = u.Name,
                                                Email = u.Email
                                            }),
                              Action = (from ac in _context.Actions
                                        where ac.MeetingId == m.MeetingId
                                        select new NewAction
                                        {
                                            Description = ac.Description

                                        }),
                              Agenda = (from ag in _context.Agendas
                                        where ag.MeetingId == m.MeetingId
                                        select new NewAgenda
                                        {
                                            Description = ag.Description
                                        })
                          }).FirstOrDefaultAsync();
        }

        private async Task<int> CreateMeeting(NewMeeting newMeeting)
        {

            var entity = new Meeting
            {
                Title = newMeeting.Title,
                Location = newMeeting.Location,
                Note = newMeeting.Note,
                DateTime = newMeeting.DateTime

            };
            _context.Meetings.Add(entity);
            var result = await _context.SaveChangesAsync();
            return entity.MeetingId;
        }

        private async Task<bool> CreateAgenda(NewMeeting newMeeting, int meetingId)
        {

            foreach (NewAgenda s in newMeeting.Agenda)
            {
                var entity = new Agenda
                {
                    Description = s.Description,
                    MeetingId = meetingId

                };
                _context.Agendas.Add(entity);
            }
            var saveResult = await _context.SaveChangesAsync();
            return saveResult != 0;
        }

        private async Task<bool> CreateAction(NewMeeting newMeeting, int meetingId)
        {
            foreach (NewAction s in newMeeting.Action)
            {
                var entity = new Models.Action
                {
                    Description = s.Description,
                    MeetingId = meetingId

                };
                _context.Actions.Add(entity);
            }
            var saveResult = await _context.SaveChangesAsync();
            return saveResult != 0;
        }

        private async Task<bool> CreateMeetingAttendance(NewMeeting newMeeting, int meetingId)
        {
            foreach (Attendance s in newMeeting.Attendance)
            {
                var entity = new MeetingAttendance
                {
                    MeetingId = meetingId,
                    UserId = s.UserId
                };
                _context.MeetingAttendances.Add(entity);
            }
            var saveResult = await _context.SaveChangesAsync();
            return saveResult != 0;
        }

        private bool saveUnusedCode()
        {
            // TODO create a single transaction
            //var meetingEntity = new Meeting
            //{
            //    Title = newMeeting.Title,
            //    Location = newMeeting.Location,
            //    Note = newMeeting.Note,
            //    DateTime = newMeeting.DateTime
            //};
            //_context.Meetings.Add(meetingEntity);

            //foreach (NewAgenda s in newMeeting.Agenda)
            //{
            //    var entity = new Agenda
            //    {
            //        Description = s.Description
            //    };
            //    meetingEntity.Agendas.Add(entity);
            //}

            //foreach (NewAction s in newMeeting.Action)
            //{
            //    var entity = new Models.Action
            //    {
            //        Description = s.Description
            //    };
            //    meetingEntity.Actions.Add(entity);
            //}

            //foreach (Attendance s in newMeeting.Attendance)
            //{
            //    var entity = new MeetingAttendance
            //    {
            //        UserId = s.UserId
            //    };
            //    meetingEntity.MeetingAttendances.Add(entity);
            //}

            //var saveResult = await _context.SaveChangesAsync();
            //return saveResult != 0;


            return true;
        }
    }
}
