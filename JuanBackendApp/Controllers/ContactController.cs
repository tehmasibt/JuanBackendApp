using JuanBackendApp.App_Data;
using Microsoft.AspNetCore.Mvc;

namespace JuanBackendApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly JuanAppDbContext juanAppDbContext;
        public ContactController(JuanAppDbContext juanAppDbContext)
        {
            this.juanAppDbContext = juanAppDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
