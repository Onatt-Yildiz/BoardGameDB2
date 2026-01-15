using BoardGameDB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace BoardGameDB.Filters
{
    public class SecurityActionFilter : IActionFilter
    {
        private readonly GameDbContext _context;

        public SecurityActionFilter(GameDbContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controllerName = context.RouteData.Values["controller"]?.ToString();
            string actionName = context.RouteData.Values["action"]?.ToString();

            
            if (controllerName == "Login" || actionName == "Logout")
                return;

            int? userId = context.HttpContext.Session.GetInt32("UserId");
            int? roleId = context.HttpContext.Session.GetInt32("RoleId");

            if (!userId.HasValue || !roleId.HasValue)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "Index" }
                    });
                return;
            }

            string roleName = _context.Roles
                .Where(r => r.Id == roleId)
                .Select(r => r.Name)
                .FirstOrDefault();

            if (roleName == "Admin")
                return;

            bool hasPermission = _context.RolePages.Any(x =>
                x.RoleId == roleId &&
                x.Page.ControllerName != null &&
                x.Page.ActionName != null &&
                x.Page.ControllerName.ToLower() == controllerName.ToLower() &&
                x.Page.ActionName.ToLower() == actionName.ToLower()
            );

            if (!hasPermission)
            {
                context.Result = new ContentResult
                {
                    Content = @"<div style='text-align:center; margin-top:50px;'>
                    <h1 style='color:red;'>Bu sayfaya giriş yetkiniz yok!</h1>
                    <p>Erişmeye çalıştığınız sayfa yetki sınırlarınız dışındadır.</p>
                    <a href='/Login/Logout'
                       style='padding:10px 20px;
                              background:#0d6efd;
                              color:white;
                              text-decoration:none;
                              border-radius:6px;'>
                        Çıkış Yap
                    </a>
                </div>",
                    ContentType = "text/html; charset=utf-8"
                };

            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
