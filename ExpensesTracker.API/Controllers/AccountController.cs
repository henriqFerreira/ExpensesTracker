﻿using ExpensesTracker.DAO.Data;
using ExpensesTracker.DAO.Models;
using ExpensesTracker.DAO.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AspNetUser> _userManager;
        public SignInManager<AspNetUser> _signInManager;

        public AccountController
            (
                UserManager<AspNetUser> userManager,
                SignInManager<AspNetUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet("Account/SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost("Account/SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInVM model)
        {
            if (!ModelState.IsValid) return Json(new { Ok = false, Title = "Erro", Message = "Dados inválidos!" });

            var AspNetUser = _userManager.ObterPorEmail(model.Email);

            if (AspNetUser == null) return Json(new { Ok = false, Title = "Erro", Message = "Email ou senha incorretos!" });

            var signInResult = await _signInManager.PasswordSignInAsync(AspNetUser, model.Password, false, false);

            if (!signInResult.Succeeded) return Json(new { Ok = false, Title = "Erro", Message = "Email ou senha incorretos!" });

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

        [AllowAnonymous]
        [HttpPost("Account/SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpVM model)
        {
            return Json(new { Ok = false, Title = "Erro", Message = "Não implementado" });
        }
    }
}
