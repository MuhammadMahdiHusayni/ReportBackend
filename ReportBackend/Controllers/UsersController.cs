using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportBackend.Models;
using ReportBackend.Services;

namespace ReportBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> CheckUser(string email)
        {
            var user = await _userService.GetUserAsync(email);
            return Json(user);
        }

        // POST: api/Users
        [HttpPost]
        [Route("api/Users/addingnewuser")]
        public async Task<IActionResult> PostUser([FromBody]NewUser newUser)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var successful = await _userService.AddUserAsync(newUser);

            if (!successful)
            {
                return BadRequest(new { error = "Could not add item." });
            }

            return Ok();

        }
    }
}