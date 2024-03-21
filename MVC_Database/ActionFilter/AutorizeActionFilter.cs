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
                    // hakkı olan yer ile girmek istediği yer aynı

                    // bu noktada, kullanın gitmek istediği yere yönlendirelim 

                    var controllerbase = (HomeController)context.Controller;
                    context.Result = controllerbase.RedirectToAction("Hata", "Home");
                }
              

            }

        


        }
    }
}
