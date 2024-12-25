using BankingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    public class BankingController : Controller
    {
        private readonly IBankingService _bankingService;

        // The service is injected via the constructor
        public BankingController(IBankingService bankingService)
        {
            _bankingService = bankingService;
        }

        // Home page (Index): displays a simple view
        public IActionResult Index()
        {
            return View();
        }

        // Endpoint to retrieve the balance
        [HttpGet]
        public IActionResult GetBalance()
        {
            var balance = _bankingService.GetBalance();
            return Ok(balance);
        }

        // Endpoint to withdraw money
        [HttpPost]
        public IActionResult Withdraw([FromBody] decimal amount)
        {
            if (_bankingService.Withdraw(amount))
                return Ok("Withdrawal successful.");

            return BadRequest("Insufficient funds.");
        }

        // Endpoint to deposit money
        [HttpPost]
        public IActionResult Deposit([FromBody] decimal amount)
        {
            _bankingService.Deposit(amount);
            return Ok("Deposit successful.");
        }
    }
}
