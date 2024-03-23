using Microsoft.AspNetCore.Mvc.Filters;
using MVC_Database.Controllers;

namespace MVC_Database.ActionFilter
{
    public class AutorizeActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // girilen action ve controller'i bulalım.


            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();


            //Sessiondan değerleri alalım
            if (context.HttpContext.Session.Keys.Count() != 0)
            {
                string sessionController = context.HttpContext.Session.GetString("controller");

                string sessionAction = context.HttpContext.Session.GetString("action");

                if (sessionAction != action || sessionController != controller)
                {

                    if (controller != "Home" && action != "Hata")
                    {
                        // hata sayfasına yönlendirdikten sonra, hata sayfasıda açılırken actionfilter kullanıldığı için,
                        // tekrar tekrar hata sayfasına yönlendirme işlemini çömzmek için if koydukl

                        // hakkı olan yer ile girmek istediği yer aynı

                        // bu noktada, kullanın gitmek istediği yere yönlendirelim 

                        var controllerbase = (HomeController)context.Controller;
                        context.Result = controllerbase.RedirectToAction("Hata", "Home");
                    }



                }




            }
        }
    }
