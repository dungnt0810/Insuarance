using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/orderdetail")]
    public class OrderDetailController : Controller
    {
        private OnlineInsuranceDBContext db;

        public OrderDetailController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        [HttpGet]
        [Authorize(Roles = "Manager,Employee")]
        public IActionResult Index(int idOrder)
        {
            var orderDetail = db.OrderDetail.Find(idOrder);
            var typePayments = new List<string>() { "Paypal", "Crash", "Momo", "Visa", "ZaloPay" };
            ViewBag.typePayments = typePayments;
            return View(orderDetail);
        }

        [Route("Edit")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        public IActionResult Edit(OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = db.OrderDetail.Find(orderDetail.Id);
                    data.Price = orderDetail.Price;
                    data.Payment = orderDetail.Payment;
                    data.Created = orderDetail.Created;
                    db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Order");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            var dataEdit = db.OrderDetail.Find(orderDetail.Id);
            return View("Index", dataEdit);
        }
    }
}
