using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportBackend.Services;
using ReportBackend.Models;

namespace ReportBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var project = await _projectService.GetOpenProjectAsync();
            return Json(project);
        }

        // GET: api/Project/5
        [HttpGet("{email}", Name = "Get")]
        public async Task<IActionResult> Get(string email)
        {
            var project = await _projectService.GetProjectByEmailAsync(email);
            return Json(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]IEnumerable<NewProject> newProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var successful = await _projectService.AddProjectAsync(newProject);
            if (!successful)
            {
                return BadRequest(new { error = "Could not add item." });
            }

            return Ok();
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
