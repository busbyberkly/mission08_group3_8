using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission08_group3_8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission08_group3_8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TaskForm()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Quadrant()
        {
            return View();
        }


    }
}
