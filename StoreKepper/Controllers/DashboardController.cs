using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreKepper.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController()
        {

        }
        public IActionResult Home()
        {
            return View();
        }
    }
}