using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/home")]
    public class HomeController : Controller
    {
        private OnlineInsuranceDBContext db;

        public HomeController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        [Authorize(Roles = "Manager,Employee")]
        public IActionResult Index()
        {
            ViewBag.emp = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            return View();
        }
    }
}
