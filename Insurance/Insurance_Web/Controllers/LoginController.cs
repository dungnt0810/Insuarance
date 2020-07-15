using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace Insurance_Web.Controllers
{
    [Route("account")]
    public class LoginController : Controller
    {
        private InsuranceContext db;

        public LoginController(InsuranceContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("")]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Account account)
        {
            Debug.WriteLine(account.Email);
            Debug.WriteLine(account.Password);
            if (Check(account.Email, account.Password) != null)
            {
                return View("welcome");
            }
            else
            {
                return View("Index");
            }

        }

        private Account Check(string email, string password)
        {
            var account = db.Account.SingleOrDefault(a => a.Email.Equals(email));
            if (account != null)
            {
                if (account.Password == password)
                {
                    Debug.WriteLine("dacheck");
                    return account;
                }
            }
            return null;
        }


        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login", "Login");
        }
    }
}
