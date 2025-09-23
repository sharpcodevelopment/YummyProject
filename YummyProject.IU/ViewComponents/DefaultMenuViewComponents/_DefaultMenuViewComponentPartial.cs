using Microsoft.AspNetCore.Mvc;

namespace YummyProject.IU.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentPartial : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
