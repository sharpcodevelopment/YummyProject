using Microsoft.AspNetCore.Mvc;

namespace YummyProject.IU.ViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
