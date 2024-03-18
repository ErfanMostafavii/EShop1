using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ResumeShop.Data.Repositories;
using ResumeShop.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ResumeShop.Controllers
{
    public class AccountController : Controller
    {
        #region Register
        private IUserRepository _userRepository { get; set; }
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_userRepository.isExistUserByEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "این ایمیل قبلا ثبت شده است");
                return View(register);
            }

            Users User = new Users()
            {
                Email = register.Email.ToLower(),
                password = register.Password,
                RegisterDate = DateTime.Now,
                IsAdmin = false,
            };


            _userRepository.AddUser(User);
            return View("successRegister", register);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _userRepository.GetUserForLogin(login.Email.ToLower(), login.Password.ToLower());
            if (user == null)
            {
                ModelState.AddModelError("Email", "اطلاعات صحیح نیست");
                return View(login);
            }

            #region Authentication

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Email.ToString()),
                 new Claim("IsAdmin", user.IsAdmin.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

             HttpContext.SignInAsync(principal, properties);


            #endregion


            return Redirect("/");

        }
        #endregion

        public  IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
    }
}
