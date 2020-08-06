using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Areas.Admin.Security;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/Login")]
    public class LoginController : Controller
    {
        private OnlineInsuranceDBContext db;
        private SecurityManager securityManager = new SecurityManager();

        public LoginController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("index")]
        [Route("")]
        public IActionResult Index(Employee employee)
        {
            if (Check(employee.Email, employee.Password) != null)
            {
                var acc = db.Employee.SingleOrDefault(a => a.Email.Equals(employee.Email));
                securityManager.SignIn(HttpContext, acc);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Invalid";
                return View("Index");
            }

        }

        private Employee Check(string email, string password)
        {
            var account = db.Employee.SingleOrDefault(a => a.Email.Equals(email));
            if (account != null)
            {
                if (password.Equals(account.Password))
                {
                    return account;
                }
            }
            return null;
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            securityManager.SignOut(HttpContext);
            return RedirectToAction("Index", "Login");
        }

        [Route("accessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
