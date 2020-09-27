
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JustScan.Models;
using Microsoft.Extensions.Configuration;
using JustScan.Data;

namespace JustScan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _iconfiguration;


        public HomeController(ILogger<HomeController> logger, IConfiguration iconfiguration)
        {
            _logger = logger;
            _iconfiguration = iconfiguration;

        }

        [HttpGet("{name}")]
        public IActionResult Index(string name)
        {
            Database logic = new Database(_iconfiguration);
            return View(logic.getMenu(name));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
