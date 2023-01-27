using ExpensesTracker.DAO.Data;
using ExpensesTracker.DAO.Models.Views;
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

        [HttpPost("Account/SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Ok = false, Title = "Erro", Message = "Dados inválidos!" });
            }
            else
            {
                return Json(new { Ok = true, Title = "Correto", Message = "Dados corretos!" });
            }
        }

        [AllowAnonymous]
        [HttpGet("Account/SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
