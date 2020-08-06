using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/policy")]
    public class PolicyController : Controller
    {
        private OnlineInsuranceDBContext db;

        public PolicyController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> Index()
        {
            var policies = await db.Policy.ToListAsync();
            ViewBag.policies = policies;
            ViewBag.proviso = await db.Proviso.ToListAsync();
            return View();
        }
    }
}
