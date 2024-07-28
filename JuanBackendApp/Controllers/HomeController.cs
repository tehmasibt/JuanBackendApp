using JuanBackendApp.App_Data;
using JuanBackendApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JuanBackendApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly JuanAppDbContext _juanAppDbContext;
        public HomeController(JuanAppDbContext juanAppDbContext)
        {
            _juanAppDbContext = juanAppDbContext;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVm = new();
            homeVm.Sliders = await _juanAppDbContext.Sliders.Where(sl => !sl.IsDeleted).ToListAsync();
            homeVm.Settings = await _juanAppDbContext.Settings.Where(s => !s.IsDeleted).ToListAsync();
            homeVm.Products = await _juanAppDbContext.Products.Where(p => !p.IsDeleted).ToArrayAsync();
            return View(homeVm);
        }
    }
}
