using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Web.Controllers
{
    [Route("policy")]
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
