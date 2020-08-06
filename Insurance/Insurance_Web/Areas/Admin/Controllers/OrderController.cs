using System;
using System.Collections.Generic;
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

        [Route("")]
        [Route("OrderDetail")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpGet]
        public IActionResult OrderDetail(int idOrder)
        {
            ViewBag.orderDetail = db.OrderDetail.Find(idOrder);
            var typePayments = new List<string>() {"Paypal","Crash","Momo","Visa","ZaloPay"};
            ViewBag.typePayments = typePayments;

            return View();
        }

        [Route("")]
        [Route("OrderDetail")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        public IActionResult OrderDetail(OrderDetail orderDetail)
        {
            return View();
        }
    }
}
