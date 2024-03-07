using Microsoft.AspNetCore.Mvc;
using ResumeShop.Models;

namespace ResumeShop.Controllers
{
    public class AccountController : Controller
    {
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
             return View();
        }
    }
}
