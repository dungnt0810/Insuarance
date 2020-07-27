using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Web.Areas.employee.Controllers
{
    [Area("employee")]
    [Route("employee/order")]
    public class OrderController : Controller
    {
        private OnlineInsuranceDBContext db;

        public OrderController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            
            var username = HttpContext.Session.GetString("username");
            var emp = db.Employee.SingleOrDefault(a => a.Email.Equals(username));
            ViewBag.orders = db.Order.Where(o => o.IdEmployee.Equals(emp.IdEmployee));
            return View();
        }
    }
}
