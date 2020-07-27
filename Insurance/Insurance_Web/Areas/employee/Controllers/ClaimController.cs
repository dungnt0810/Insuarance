using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurance_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Web.Areas.employee.Controllers
{
    [Area("employee")]
    [Route("employee/claim")]
    public class ClaimController : Controller
    {
        private OnlineInsuranceDBContext db;

        public ClaimController(OnlineInsuranceDBContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
