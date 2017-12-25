using ReportBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public interface IMeetingService
    {
        Task<bool> AddMeetingAsync(NewMeeting newMeeting);
        Task<IEnumerable<Meeting>> GetAllMeetingAsync();
        Task<NewMeeting> GetMeetingById(int meetingId);
    }
}
