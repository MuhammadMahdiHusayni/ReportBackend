using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportBackend.Models;
using ReportBackend.Services;

namespace ReportBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Meeting")]
    public class MeetingController : Controller
    {
        private readonly IMeetingService _meetingService;
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var meeting = await _meetingService.GetAllMeetingAsync();
            return Json(meeting);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var meeting = await _meetingService.GetMeetingById(id);
            return Json(meeting);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateAsync([FromBody]NewMeeting newMeeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var successful = await _meetingService.AddMeetingAsync(newMeeting);
            if (!successful)
            {
                return BadRequest(new { error = "Could not add item." });
            }

            return Ok(successful);
        }
    }
}