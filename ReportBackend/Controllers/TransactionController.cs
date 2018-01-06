using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportBackend.Models;
using ReportBackend.Services;

namespace ReportBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {

        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var transaction = await _transactionService.GetAllTransactionAsync();
            return Json(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]IEnumerable<NewTransaction> transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var successful = await _transactionService.AddTransactionAsync(transaction);
            if (!successful)
            {
                return BadRequest(new { error = "Could not add item." });
            }

            return Ok(successful);
        }

        [HttpGet]
        [Route("treasure")]
        public async Task<IActionResult> GetAllAccount()
        {
            var account = await _transactionService.GetAllAccountAsync();
            return Json(account);
        }

        [HttpPost]
        [Route("treasure")]
        public async Task<IActionResult> CreateNewAccount([FromBody]Treasury treasury)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var successful = await _transactionService.AddAccountAsync(treasury);
            if (!successful)
            {
                return BadRequest(new { error = "Could not add item." });
            }

            return Ok(successful);
        }
    }
}