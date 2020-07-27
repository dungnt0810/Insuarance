using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Insurance_Web.Controllers
{
    [Route("account")]
    public class LoginController : Controller
    {
        private OnlineInsuranceDBContext db;

        public LoginController(OnlineInsuranceDBContext _db)
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
            var acc = Check(account.Email, account.Password);
            if (acc != null)
            {
                HttpContext.Session.SetString("username", acc.Email);
                if (acc.isEmployee == true)
                {
                    HttpContext.Session.SetString("role", "employee");
                    return RedirectToAction("index", "home", new { area = "employee" });
                }
                else
                {
                    HttpContext.Session.SetString("role", "customer");
                    return View("welcome");
                }
            }
            else
            {
                return View("Index");
            }

        }

        private Account Check(string email, string password)
        {
            var customer = db.Customer.SingleOrDefault(a => a.Email.Equals(email));
            var employee = db.Employee.SingleOrDefault(a => a.Email.Equals(email));
            
            if (employee != null)
            {
                if (employee.Password == password)
                {
                    var account = new Account { Email = employee.Email, Password = employee.Password, isEmployee = true };
                    return account;
                }
            }
            if (customer != null)
            {
                if (customer.Password == password)
                {
                    var account = new Account { Email = customer.Email, Password = customer.Password, isEmployee = false};
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
