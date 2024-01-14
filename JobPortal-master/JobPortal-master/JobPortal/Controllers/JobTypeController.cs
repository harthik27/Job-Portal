using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class JobTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
