using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]  //Area controller olduğunu belirtmezsek localhost bulunamıyor hatası alırız
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
