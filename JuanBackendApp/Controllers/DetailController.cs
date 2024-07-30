using Microsoft.AspNetCore.Mvc;

namespace JuanBackendApp.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
