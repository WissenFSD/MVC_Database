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
        public IActionResult Login(UserAuthModel model)
        {
            // ekrandan gelen veriler ile databasedeki verilere göre kullanýcý giriþ mekanizmasý yapalým


            var userIsLogin = _context.Authentications.Any(s => s.Username == model.Username && s.Password == model.Password);

            return View("Login");
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
