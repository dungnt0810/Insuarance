using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/customer")]
    public class CustomerController : Controller
    {

        private OnlineInsuranceDBContext db;

        public CustomerController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> Index()
        {
            var customers = await db.Customer.ToListAsync();
            ViewBag.customers = customers;
            return View();
        }

        [Route("changepassword")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpGet]
        public async Task<IActionResult> ChangePassword(int idCus)
        {
            var customer = await db.Customer.FindAsync(idCus);
            return View(customer);
        }

        [Route("changepassword")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = db.Customer.Find(customer.Id);
                    var hash = BCrypt.Net.BCrypt.HashPassword(customer.Password);
                    data.Password = hash;
                    db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Customer");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return View("ChangePassword",customer.Id);
        }

        [Route("edit")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpGet]
        public async Task<IActionResult> Edit(int idCus)
        {
            var customer = await db.Customer.FindAsync(idCus);
            return View(customer);
        }

        [Route("edit")]
        [Authorize(Roles = "Manager,Employee")]
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            var data = await db.Customer.FindAsync(customer.Id);
            try
            {
                if (ModelState.IsValid)
                {
                    data.IdCard = customer.IdCard;
                    data.Fullname = customer.Fullname;
                    data.Phone = customer.Phone;
                    data.Email = customer.Email;
                    data.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
                    data.Address = customer.Address;
                    data.Gender = customer.Gender;
                    data.Birthday = customer.Birthday;
                    db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index", "Customer");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return View("Edit", customer.Id);
        }

        [Route("add")]
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View("Add");
        }

        [Route("add")]
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            try
            {
                db.Customer.Add(customer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Customer");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return View("Add");
        }
    }
}
