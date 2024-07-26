using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultFAQComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
