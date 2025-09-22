using Microsoft.AspNetCore.Mvc;

namespace YummyProject.IU.ViewComponents
{
    public class _HeadDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
