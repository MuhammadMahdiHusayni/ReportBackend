using Microsoft.AspNetCore.Mvc;
using ReportBackend.Models;
using ReportBackend.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Report")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{id}", Name = "GetReport")]
        public async Task<IActionResult> GetReport(Guid id)
        {
            var project = await _reportService.GetReportByProjectAsync(id);
            return Json(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]IEnumerable<NewReport> newReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var successful = await _reportService.AddReportAsync(newReport);
            if (!successful)
            {
                return BadRequest(new { error = "Could not add item." });
            }

            return Ok();
        }

    }
}