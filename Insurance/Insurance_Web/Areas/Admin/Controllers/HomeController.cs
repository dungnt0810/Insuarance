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
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
