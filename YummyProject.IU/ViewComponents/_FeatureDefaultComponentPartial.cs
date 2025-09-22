using Microsoft.AspNetCore.Mvc;

namespace YummyProject.IU.ViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
