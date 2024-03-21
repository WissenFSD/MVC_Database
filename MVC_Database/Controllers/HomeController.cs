using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Database.ActionFilter;
using MVC_Database.Models;
using System.Diagnostics;

namespace MVC_Database.Controllers
{
    [AutorizeActionFilter]
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

            // iki tabloyu linq to sql ile birleþtirmek için, yani join yapmak
            var usermodel = _context.Authentications.Include(k => k.Autorizations).Where(s => s.Username == model.Username && s.Password == model.Password).FirstOrDefault();
            if (usermodel != null)
            {
                var controller = usermodel.Autorizations.Select(s => s.Controller).FirstOrDefault();
                var action = usermodel.Autorizations.Select(s => s.Action).FirstOrDefault();

                // yetkileri session içerisine atalým

                HttpContext.Session.SetString("controller", controller);
                HttpContext.Session.SetString("action", action);

                return View("Login");
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Hata()
        {
            return View("Hata");
        }





    }
}
