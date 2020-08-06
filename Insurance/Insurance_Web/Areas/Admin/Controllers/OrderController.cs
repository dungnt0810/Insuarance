using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/order")]
    public class OrderController : Controller
    {
        private OnlineInsuranceDBContext db;

        public OrderController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        [Authorize(Roles = "Manager,Employee")]
        public IActionResult Index()
        {
            ViewBag.orders = db.Order.ToList();
            return View();
        }

        [Route("Edit")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = db.Order.Find(id);
            return View("Edit",order);
        }

        [Route("Edit")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        public IActionResult OrderDetail(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = db.Order.Find(order.Id);
                    data.Fullname = order.Fullname;
                    data.Address = order.Address;
                    data.Description = order.Description;
                    data.Phone = order.Phone;
                    data.TimeStart = order.TimeStart;
                    data.TimeEnd = order.TimeEnd;
                    data.Price = order.Price;
                    data.TypePayment = order.TypePayment;
                    db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Order");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            var dataEdit = db.Order.Find(order.Id);
            return View("Edit", dataEdit);
        }

    }
}
