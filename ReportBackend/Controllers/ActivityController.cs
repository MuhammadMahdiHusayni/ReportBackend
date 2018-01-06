using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportBackend.Models;
using ReportBackend.Services;

namespace ReportBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Activity")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var activity = await _activityService.GetAllActivityAsync();
            return Json(activity);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateAsync([FromBody]NewActivity newActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var successful = await _activityService.AddActivityAsync(newActivity);
            if (!successful)
            {
                return BadRequest(new { error = "Could not add item." });
            }

            return Ok(successful);
        }
    }
}