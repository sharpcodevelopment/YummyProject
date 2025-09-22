using Microsoft.AspNetCore.Mvc;

namespace YummyProject.IU.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
