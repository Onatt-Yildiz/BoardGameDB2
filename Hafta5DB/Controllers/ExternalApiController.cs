using BoardGameDB.Service; 
using Microsoft.AspNetCore.Mvc;

namespace BoardGameDB.Controllers
{
    public class ExternalApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var service = new ExternalApiService();
            var data = await service.GetObjectsAsync();
            return View(data);
        }
    }
}