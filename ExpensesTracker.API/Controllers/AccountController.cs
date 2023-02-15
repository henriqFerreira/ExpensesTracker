using ExpensesTracker.DAO.Data;
using ExpensesTracker.DAO.IService;
using ExpensesTracker.DAO.Models;
using ExpensesTracker.DAO.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AspNetUser> _userManager;
        private SignInManager<AspNetUser> _signInManager;
        private readonly IServiceToken _serviceToken;

        public AccountController
            (
                UserManager<AspNetUser> userManager,
                SignInManager<AspNetUser> signInManager,
                IServiceToken serviceToken
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serviceToken = serviceToken;
        }

        [AllowAnonymous]
        [HttpGet("Account/SignIn")]
        public IActionResult SignIn()
        {
            return User.Identity.IsAuthenticated ? RedirectToAction("Index", "Dashboard") : View();
        }

        [HttpPost("Account/SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInVM model)
        {
            if (!ModelState.IsValid) return Json(new { Ok = false, Title = "Erro", Message = "Dados inválidos!" });

            var AspNetUser = _userManager.ObterPorEmail(model.Email, "User");

            if (AspNetUser == null) return Json(new { Ok = false, Title = "Erro", Message = "Email ou senha incorretos!" });

            var signInResult = await _signInManager.PasswordSignInAsync(AspNetUser, model.Password, false, false);

            if (!signInResult.Succeeded) return Json(new { Ok = false, Title = "Erro", Message = "Email ou senha incorretos!" });

            var roles = await _userManager.GetRolesAsync(AspNetUser);
            var token = _serviceToken.GenerateToken(AspNetUser, roles.ToList());

            Response.Cookies.Delete("redirectUrl");
            Response.Cookies.Append("access_token", token, _serviceToken.GenerateCookies());

            return Json(new
            {
                Ok = true,
                Title = "Sucesso",
                Message = "Sucesso na autenticação"
            });
        }

        [AllowAnonymous]
        [HttpGet("Account/SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost("Account/SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpVM model)
        {
            if (!ModelState.IsValid) return Json(new { Ok = false, Title = "Erro", Message = "Dados inválidos!", Error = ModelState.Select(x => x.Value.Errors).ToList() });

            var sucesso = false;

            var user = new AspNetUser
            {
                UserName = model.Email,
                Email = model.Email,
                TwoFactorEnabled = false,
                User = new User
                {
                    FirstName = model.Name,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                }
            };

            // TODO: Verificação se o usuário já existe

            var result = await _userManager.CreateAsync(user, model.Password);

            sucesso = result.Succeeded;

            if (sucesso)
            {
                var roles = new List<string>{ "User" };
                result = await _userManager.AddToRolesAsync(user, roles);
                sucesso = result.Succeeded;
            }

            return Json(new
            {
                Ok = sucesso,
                Title = sucesso ? "Sucesso" : "Erro",
                Message = sucesso ? "Usuário criado com sucesso!" : "Falha ao criar usuário!"
            });
        }

        public IActionResult SignOut(string returnUrl)
        {
            foreach (var cookie in Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }

            return RedirectToAction("SignIn", "Account");
        }
    }
}
