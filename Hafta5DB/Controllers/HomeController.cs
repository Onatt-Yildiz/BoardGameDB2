using Microsoft.AspNetCore.Mvc;

namespace BoardGameDB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Error()
        {
            return View();
        }
    }
}