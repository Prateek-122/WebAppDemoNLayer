using BusinessLayer;

using Microsoft.AspNetCore.Mvc;
using WebAppDemoNLayer.Models;

namespace WebAppDemoNLayer.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(AccountService accountService)
        {
            AccountService = accountService;
        }

        public AccountService AccountService { get; }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            return Redirect (AccountService.Login(login.UserName, login.Password));
        }
    }
}
