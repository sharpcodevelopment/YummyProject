using Microsoft.AspNetCore.Mvc;

namespace YummyProject.IU.ViewComponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    
}
