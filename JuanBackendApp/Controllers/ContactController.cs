using JuanBackendApp.Models;
using JuanBackendApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JuanBackendApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
