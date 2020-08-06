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
    [Route("admin/claim")]
    public class ClaimController : Controller
    {
        private OnlineInsuranceDBContext db;

        public ClaimController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index()
        {
            var claims = await db.ClaimInsurance.ToListAsync();
            ViewBag.claims = claims;
            return View();
        }

        [Route("")]
        [Route("unchecked")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UncheckedClaims()
        {
            var claims = await db.ClaimInsurance.Where(c => c.Status == false).ToListAsync();
            ViewBag.claims = claims;
            return View("Index");
        }

        [Route("Edit")]
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Edit(int idClaim)
        {
            ClaimInsurance claim = await db.ClaimInsurance.FindAsync(idClaim);
            return View("Edit",claim);
        }

        [Route("Edit")]
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public  async Task<IActionResult> Edit(ClaimInsurance claim)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = await db.ClaimInsurance.FindAsync(claim.Id);
                    data.Title = claim.Title;
                    data.Price = claim.Price;
                    data.Status = claim.Status;
                    data.Content = claim.Content;
                    data.Created = claim.Created;
                    db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index", "Claim");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            var dataEdit = await db.ClaimInsurance.FindAsync(claim.Id);
            return View("Edit",dataEdit);
        }
    }
}
