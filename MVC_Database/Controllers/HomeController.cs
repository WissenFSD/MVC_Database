using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models;
using System.Diagnostics;

namespace MVC_Database.Controllers
{
    public class HomeController : Controller
    {

        public AuthContext _context;

        public HomeController(AuthContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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
