using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
