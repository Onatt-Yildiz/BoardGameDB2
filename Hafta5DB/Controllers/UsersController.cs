using BoardGameDB.Data;
using BoardGameDB.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameDB.Controllers
{
    
    public class UsersController : BaseController
    {
        
        public UsersController(GameDbContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
           
            var users = _dbContext.Users.ToList();

            return View(users);
        }
    }
}