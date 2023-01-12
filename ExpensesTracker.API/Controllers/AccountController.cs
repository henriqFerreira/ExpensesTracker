using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet("Account/SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet("Account/SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
