using BoardGameDB.Data;
using BoardGameDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BoardGameDB.Controllers
{
    public class BaseController : Controller
    {
        protected readonly GameDbContext _dbContext;

        public BaseController(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)  
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var log = new UserLog
                {
                    UserId = userId.Value,
                    Controller = context.RouteData.Values["controller"]?.ToString(),
                    Action = context.RouteData.Values["action"]?.ToString(),
                    LogTime = DateTime.Now,
                    IpAdress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1"
                };

                _dbContext.UserLogs.Add(log);
                _dbContext.SaveChanges();
            }

            base.OnActionExecuting(context);
        }
    }
}