using BoardGameDB.Data;
using BoardGameDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameDB.Controllers
{
    public class LoginController : Controller
    {
        private readonly GameDbContext _dbContext;

        public LoginController(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Index(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = _dbContext.Users
                .Include(u => u.UserRole)
                .FirstOrDefault(x =>
                    x.UserName == vm.UserName &&
                    x.Password == vm.Password);

            if (user != null)
            {
                
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetInt32("RoleId", user.UserRole.Id);
                HttpContext.Session.SetString("UserFullName", user.FullName);

                
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı";
            return View(vm);
        }
        
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
