using JustScan.Data;
using JustScan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JustScan.Controllers
{
    public class DemoController : Controller
    {
        private readonly IConfiguration _iconfiguration;

        public DemoController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public ActionResult Index()
        { 

            Database logic = new Database(_iconfiguration);
            return View();
        }

       
    }
}
